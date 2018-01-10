using System;
using WarframeNET;

namespace VoxLotus
{
    public abstract class CyclicTicker : Ticker
    {
        protected DateTime anchorTime = new DateTime(0);

        protected readonly TimeSpan enabledSpan;
        protected readonly TimeSpan disabledSpan;
        protected readonly TimeSpan totalSpan;

        protected abstract void UpdateAnchorTime(WorldState state);

        protected CyclicTicker(TimeSpan enabledSpan, TimeSpan disabledSpan)
        {
            this.enabledSpan = enabledSpan;
            this.disabledSpan = disabledSpan;
            this.totalSpan = enabledSpan.Add(disabledSpan);
        }

        public void Tick(WorldState state)
        {
            UpdateAnchorTime(state);

            // Anchor time failed to retrieve and has never been cached.
            if (anchorTime.Ticks <= 0)
                return;

            TimeSpan untilCycle = totalSpan - GetMomentInCycle();
            DateTime nextCycle = DateTime.UtcNow + untilCycle;

            bool isEnabled = untilCycle > disabledSpan;
            Expiry = isEnabled ? nextCycle - disabledSpan : nextCycle;

            TickerState currentState;

            if (!WithinWarningTime)
                currentState = isEnabled ? TickerState.Enabled : TickerState.Disabled;
            else
                currentState = isEnabled ? TickerState.Disabling : TickerState.Enabling;

            SetState(currentState);
        }

        protected TimeSpan GetMomentInCycle()
        {
            long difference = Math.Abs(anchorTime.Ticks - DateTime.UtcNow.Ticks);
            long moment = anchorTime <= DateTime.UtcNow ? difference % totalSpan.Ticks : totalSpan.Ticks - (difference % totalSpan.Ticks);
            return new TimeSpan(moment);
        }
    }
}
