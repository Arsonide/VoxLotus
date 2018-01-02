using VoxLotus.Parsers;

namespace VoxLotus
{
    public abstract class ParsedOperation
    {
        public abstract string Id { get; }
        public abstract bool Expired { get; }
        public bool Connected { get; set; }
        public abstract string Type { get; }
        public abstract string Description(DescriptionType type);
        public bool Relevant => reward != null && reward.Relevant;
        protected ParsedNode node;
        protected ParsedReward reward;
    }
}