namespace VoxLotus.Parsers
{
    public class ParsedRewardSingular : ParsedRewardEntry
    {
        public ParsedRewardSingular(string name) : base(name) { }

        public override string Description(bool spoken = false)
        {
            if (Undefined)
                return Utilities.ItemDescription(Display, Utilities.GuessIndefiniteArticle(Display));

            return Utilities.ItemDescription(spoken ? Entry.GetPronunciation() : Entry.GetDisplay(), Entry.EntryPrefix);
        }
    }
}