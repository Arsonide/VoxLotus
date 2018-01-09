using System;

namespace VoxLotus.Controls
{
    public class LoggedMessageListBoxItem : LoggedListBoxItem
    {
        public LoggedMessageListBoxItem(string message, bool faded = false)
        {
            SetText(message, faded);
            tag = Guid.NewGuid().ToString();
        }

        public LoggedMessageListBoxItem(string title, string message, bool faded = false)
        {
            SetText(title, message, faded);
            tag = Guid.NewGuid().ToString();
        }
    }
}
