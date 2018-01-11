using System;
using System.Windows.Forms;

namespace VoxLotus.Parsers
{
    public abstract class ParsedRewardEntry : ParsedRewardItem
    {
        public string Name { get; }
        public string Display { get; }

        public ConfigurationEntry Entry { get; }
        public bool Undefined { get; }

        protected const string blueprintString = " Blueprint";

        protected override CheckState Interest => Undefined ? ConfigurationManager.Instance.Settings.UndefinedInterest : Entry.EntryCheckState;
        protected override string TediousTag => Undefined ? ConfigurationManager.Instance.Settings.UndefinedTediousTag : Entry.TediousTag;

        protected ParsedRewardEntry(string name)
        {
            Display = name;
            Name = StripBlueprint(Display);

            if (ConfigurationManager.Instance.TryGetEntryByName(Name, out ConfigurationEntry entry))
            {
                Entry = entry;
                Undefined = false;
            }
            else
                Undefined = true;
        }

        protected string StripBlueprint(string name)
        {
            if (name.EndsWith(blueprintString))
                name = name.Substring(0, name.LastIndexOf(blueprintString, StringComparison.Ordinal));

            return name;
        }
    }
}