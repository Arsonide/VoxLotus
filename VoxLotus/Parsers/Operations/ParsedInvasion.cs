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

        public override string Description(DescriptionType type)
        {
            switch(type)
            {
                case DescriptionType.Spoken:
                    return $"A new {invasion.Description} rewarding {reward.Description(true, true)} has appeared {node.PlanetDescription(true, true)}.";
                case DescriptionType.Logged:
                    return $"{invasion.Node}: {invasion.Description}. Rewards: {reward.Description(false)}.";
                case DescriptionType.Progress:
                    return $"Completion: {Math.Round(Completion)}%.";
                default:
                    return $"{invasion.Node}: {invasion.Description}. Rewards: {reward.Description(false)}.";

            }
        }
    }
}