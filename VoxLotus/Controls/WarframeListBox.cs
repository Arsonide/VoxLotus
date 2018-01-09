using System.Drawing;
using System.Windows.Forms;

namespace VoxLotus.Controls
{
    public sealed class WarframeListBox : ListBox
    {
        private bool drawingInitialized;
        private SolidBrush backgroundAlphaBrush;
        private SolidBrush backgroundBetaBrush;
        private SolidBrush textBrushSolid;
        private SolidBrush textBrushFaded;

        public WarframeListBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void DefWndProc(ref Message m)
        {
            if ((m.Msg <= 0x0200 || m.Msg >= 0x020E) && (m.Msg <= 0x0100 || m.Msg >= 0x0109) && m.Msg != 0x2111 && m.Msg != 0x87)
                base.DefWndProc(ref m);
        }

        private void InitializeDrawing(DrawItemEventArgs e)
        {
            backgroundAlphaBrush = new SolidBrush(SystemColors.ControlLightLight);
            backgroundBetaBrush = new SolidBrush(SystemColors.Control);
            textBrushSolid = new SolidBrush(e.ForeColor);
            textBrushFaded = new SolidBrush(Color.FromArgb(e.ForeColor.A / 2, e.ForeColor.R / 2, e.ForeColor.G / 2, e.ForeColor.B / 2));
            drawingInitialized = true;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if (Items.Count <= e.Index)
                return;

            WarframeListBoxItem item = Items[e.Index] as WarframeListBoxItem;

            if (item == null)
                return;

            int realWidth = Width - SystemInformation.VerticalScrollBarWidth;
            e.ItemHeight = (int)e.Graphics.MeasureString(item.text, Font, realWidth).Height;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (Items.Count <= e.Index)
                return;

            WarframeListBoxItem item = Items[e.Index] as WarframeListBoxItem;

            if (item == null)
                return;

            if (!drawingInitialized)
                InitializeDrawing(e);

            SolidBrush backgroundBrush = e.Index % 2 == 0 ? backgroundAlphaBrush : backgroundBetaBrush;
            SolidBrush foregroundBrush = item.faded ? textBrushFaded : textBrushSolid;

            e.DrawBackground();
            e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            e.Graphics.DrawString(item.text, e.Font, foregroundBrush, e.Bounds);
            e.DrawFocusRectangle();
        }

        public void AddItemToBottom(WarframeListBoxItem item)
        {
            this.SafeInvoke(() =>
            {
                Items.Add(item);
            });
        }

        public void AddItemToTop(WarframeListBoxItem item)
        {
            this.SafeInvoke(() =>
            {
                Items.Insert(0, item);
            });
        }

        public void RemoveItem(string tag)
        {
            this.SafeInvoke(() =>
            {
                for (int i = Items.Count - 1; i >= 0; --i)
                {
                    WarframeListBoxItem item = Items[i] as WarframeListBoxItem;

                    if (item == null)
                        continue;

                    if (item.tag == tag)
                        Items.RemoveAt(i);
                }
            });
        }

        public void RemoveItem(WarframeListBoxItem item)
        {
            this.SafeInvoke(() =>
            {
                RemoveItem(item.tag);
            });
        }

        public void ClearItems()
        {
            this.SafeInvoke(() =>
            {
                Items.Clear();
            });
        }
    }
}
