namespace VoxLotus.Controls
{
    public class LoggedOperationListBoxItem : LoggedListBoxItem
    {
        public LoggedOperationListBoxItem(ParsedOperation operation)
        {
            SetText(operation.Type, operation.Description(DescriptionType.Logged), !operation.Relevant);
            tag = operation.Id;
        }
    }
}
