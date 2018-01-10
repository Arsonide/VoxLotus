using System;
using WarframeNET;

namespace VoxLotus
{
    public class EarthTicker : CyclicTicker
    {
        public EarthTicker() : base(TimeSpan.FromHours(4), TimeSpan.FromHours(4)) { }

        protected override void UpdateAnchorTime(WorldState state)
        {
            if (state?.WS_EarthCycle != null)
            {
                anchorTime = state.WS_EarthCycle.isDay ? state.WS_EarthCycle.expiry + disabledSpan : state.WS_EarthCycle.expiry;
                ConfigurationManager.Instance.Settings.EarthCyclicAnchor = anchorTime.Ticks;
            }
            else
                anchorTime = new DateTime(ConfigurationManager.Instance.Settings.EarthCyclicAnchor);
        }
    }
}
