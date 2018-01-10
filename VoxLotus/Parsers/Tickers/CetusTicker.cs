using System;
using WarframeNET;

namespace VoxLotus
{
    public class CetusTicker : CyclicTicker
    {
        public CetusTicker() : base(TimeSpan.FromMinutes(100), TimeSpan.FromMinutes(50)) { }

        protected override void UpdateAnchorTime(WorldState state)
        {
            SyndicateMission bounty = null;

            foreach (SyndicateMission mission in state.WS_SyndicateMissions)
            {
                if (mission.Syndicate != "Ostrons")
                    continue;

                bounty = mission;
                break;
            }

            if (bounty != null)
            {
                anchorTime = bounty.EndTime;
                ConfigurationManager.Instance.Settings.CetusCyclicAnchor = anchorTime.Ticks;
            }
            else
                anchorTime = new DateTime(ConfigurationManager.Instance.Settings.CetusCyclicAnchor);
        }
    }
}
