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
            if (Undefined)
                return Utilities.ItemDescription(Display, Utilities.GuessIndefiniteArticle(Display), amount);

            return Utilities.ItemDescription(spoken ? Entry.GetPronunciation() : Entry.GetDisplay(), Entry.EntryPrefix, amount);
        }
    }
}