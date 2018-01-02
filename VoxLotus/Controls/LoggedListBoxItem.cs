using System;

namespace VoxLotus.Controls
{
    public abstract class LoggedListBoxItem : WarframeListBoxItem
    {
        protected void SetText(string message, bool bolded = false)
        {
            text = $"[{DateTime.Now:h:mm:ss tt}] {message}";
            bold = bolded;
        }

        protected void SetText(string title, string message, bool bolded = false)
        {
            text = $"[{DateTime.Now:h:mm tt} - {title.ToUpperInvariant()}] {message}";
            bold = bolded;
        }
    }
}
