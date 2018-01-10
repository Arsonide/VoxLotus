using System;
using WarframeNET;

namespace VoxLotus.Parsers
{
    public class ParsedInvasion : ParsedOperation
    {
        protected readonly Invasion invasion;

        public ParsedInvasion(Invasion invasion)
        {
            this.invasion = invasion;
            reward = new ParsedReward(invasion);
            node = new ParsedNode(invasion);
        }

        public override string Id => invasion != null ? invasion.Id : string.Empty;

        public override bool Expired => invasion == null || Completion >= 100;

        public override string Type => "Invasion";

        public double Completion
        {
            get
            {
                if (invasion == null || invasion.IsCompleted)
                    return 100;

                return invasion.IsVsInfestation ? 100 - invasion.Completion : Math.Abs(invasion.Completion - 50) * 2;
            }
        }

        public bool TryGetETA(out string eta)
        {
            if (invasion == null)
            {
                eta = string.Empty;
                return false;
            }

            double completion = Completion;
            double minutes = DateTime.UtcNow.Subtract(invasion.StartTime).TotalMinutes;

            // If completion or time elapsed is too low, the estimate won't be very good.
            if (completion < 5 || minutes < 5)
            {
                eta = string.Empty;
                return false;
            }

            double completionRate = completion / minutes;
            double completionLeft = 100 - completion;

            eta = Utilities.ReadableTimeSpan(TimeSpan.FromMinutes(completionLeft / completionRate), false);
            return true;
        }

        public override string Description(DescriptionType type)
        {
            switch(type)
            {
                case DescriptionType.Spoken:
                    return $"A new {invasion.Description} rewarding {reward.Description(true, false, true)} has appeared {node.PlanetDescription(true, true)}.";
                case DescriptionType.Logged:
                    return $"{invasion.Node}: {invasion.Description}. Rewards: {reward.Description(false, true, false)}.";
                case DescriptionType.Progress:
                    return TryGetETA(out string eta) ? $"Completion: {Math.Round(Completion)}%. Estimated Remaining: {eta}." : $"Completion: {Math.Round(Completion)}%.";
                default:
                    return $"{invasion.Node}: {invasion.Description}. Rewards: {reward.Description(false, true, false)}.";

            }
        }
    }
}