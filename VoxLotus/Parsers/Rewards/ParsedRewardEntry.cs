using System;
using System.Windows.Forms;

namespace VoxLotus.Parsers
{
    public abstract class ParsedRewardEntry : ParsedRewardItem
    {
        public ConfigurationEntry entry { get; }

        protected const string blueprintString = " Blueprint";

        protected override CheckState Interest => entry?.EntryCheckState ?? CheckState.Unchecked;

        protected override string TediousTag => entry != null ? entry.TediousTag : string.Empty;

        protected ParsedRewardEntry(string name)
        {
            name = StripBlueprint(name);

            if (ConfigurationManager.Instance.HasEntryName(name))
                entry = ConfigurationManager.Instance.GetEntryByName(name);
        }

        protected string StripBlueprint(string name)
        {
            if (name.EndsWith(blueprintString))
                name = name.Substring(0, name.LastIndexOf(blueprintString, StringComparison.Ordinal));

            return name;
        }

        public override bool Relevant(string missionType)
        {
            return entry != null && base.Relevant(missionType);
        }
    }
}