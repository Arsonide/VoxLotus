using System;
using WarframeNET;

namespace VoxLotus.Parsers
{
    public class ParsedAlert : ParsedOperation
    {
        protected readonly Alert alert;

        public ParsedAlert(Alert alert)
        {
            this.alert = alert;
            reward = new ParsedReward(alert);
            node = new ParsedNode(alert);
        }

        public override string Id => alert != null ? alert.Id : string.Empty;

        public override bool Expired => alert == null || alert.EndTime <= DateTime.UtcNow;

        public override string Type => "Alert";

        public override string Description(DescriptionType type)
        {
            switch (type)
            {
                case DescriptionType.Spoken:
                    return $"A new Tenno alert rewarding {reward.Description(true, false, true)} has appeared {node.PlanetDescription(true, true)}.";
                case DescriptionType.Logged:
                    return $"{alert.Mission.Node}: {alert.Mission.Faction} {alert.Mission.Type} Alert. Rewards: {reward.Description(false, true, false)}.";
                case DescriptionType.Progress:
                    return $"Remaining: {Utilities.ReadableTimeSpan(alert.EndTime.Subtract(DateTime.UtcNow), false)}.";
                default:
                    return $"{alert.Mission.Node}: {alert.Mission.Faction} {alert.Mission.Type} Alert. Rewards: {reward.Description(false, true, false)}.";

            }
        }
    }
}