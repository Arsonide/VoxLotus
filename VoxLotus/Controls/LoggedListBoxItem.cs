using System;

namespace VoxLotus.Controls
{
    public abstract class LoggedListBoxItem : WarframeListBoxItem
    {
        protected void SetText(string message, bool faded = false)
        {
            text = $"[{DateTime.Now:h:mm:ss tt}] {message}";
            this.faded = faded;
        }

        protected void SetText(string title, string message, bool faded = false)
        {
            text = $"[{DateTime.Now:h:mm tt} - {title.ToUpperInvariant()}] {message}";
            this.faded = faded;
        }
    }
}
