namespace VoxLotus.Parsers
{
    public class ParsedRewardSingular : ParsedRewardEntry
    {
        public ParsedRewardSingular(string name) : base(name) { }

        public override string Description(bool spoken = false)
        {
            return entry != null ? Utilities.ItemDescription(spoken ? entry.GetPronunciation() : entry.GetDisplay(), entry.EntryPrefix) : string.Empty;
        }
    }
}