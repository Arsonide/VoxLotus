namespace VoxLotus.Parsers
{
    public abstract class ParsedRewardCurrency : ParsedRewardItem
    {
        public readonly decimal amount;

        protected abstract string Name { get; }
        protected abstract string Prefix { get; }
        protected abstract decimal Minimum { get; }

        protected ParsedRewardCurrency(decimal amount)
        {
            this.amount = amount;
        }

        public override bool Relevant(string missionType) => amount >= Minimum && base.Relevant(missionType);

        public override string Description(bool spoken = false)
        {
            return Utilities.ItemDescription(Name, Prefix, amount);
        }
    }
}