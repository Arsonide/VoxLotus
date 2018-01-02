using System;

namespace VoxLotus.Controls
{
    public class LoggedMessageListBoxItem : LoggedListBoxItem
    {
        public LoggedMessageListBoxItem(string message, bool bold = false)
        {
            SetText(message, bold);
            tag = Guid.NewGuid().ToString();
        }

        public LoggedMessageListBoxItem(string title, string message, bool bold = false)
        {
            SetText(title, message, bold);
            tag = Guid.NewGuid().ToString();
        }
    }
}
