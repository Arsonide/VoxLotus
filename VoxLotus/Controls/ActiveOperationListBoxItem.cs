using VoxLotus.Parsers;

namespace VoxLotus.Controls
{
    public class ActiveOperationListBoxItem : WarframeListBoxItem
    {
        protected readonly ParsedWorld world;
        protected readonly string id;

        protected readonly string missionText;
        protected string progressText = string.Empty;

        protected ParsedOperation operation;

        public ActiveOperationListBoxItem(ParsedWorld world, string id)
        {
            this.world = world;
            this.id = id;

            UpdateOperation();

            if (operation == null)
                return;

            missionText = operation.Description(DescriptionType.Written);
            tag = operation.Id;
            bold = false;

            UpdateText();
        }

        public override void Update()
        {
            UpdateOperation();
            UpdateText();
        }

        protected void UpdateOperation()
        {
            operation = world?.GetOperationById(id);
        }

        protected void UpdateText()
        {
            progressText = operation != null ? operation.Description(DescriptionType.Progress) : string.Empty;
            text = $"{missionText} {progressText}";
        }
    }
}
