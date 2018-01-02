using WarframeNET;

namespace VoxLotus.Parsers
{
    public class ParsedRewardCounted : ParsedRewardEntry
    {
        public readonly decimal amount;

        public ParsedRewardCounted(string name, decimal amount) : base(name)
        {
            this.amount = amount;
        }

        public ParsedRewardCounted(CountedItem item) : base(item.Type)
        {
            amount = item.Count;
        }

        public override string Description(bool spoken = false)
        {
            return entry != null ? Utilities.ItemDescription(spoken ? entry.GetPronunciation() : entry.GetDisplay(), entry.EntryPrefix, amount) : string.Empty;
        }
    }
}