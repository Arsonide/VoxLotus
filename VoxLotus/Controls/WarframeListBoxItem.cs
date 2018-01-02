﻿namespace VoxLotus.Controls
{
    public abstract class WarframeListBoxItem
    {
        public string text { get; protected set; }
        public string tag { get; protected set; }
        public bool bold { get; protected set; }
        public virtual void Update() { }
    }
}
