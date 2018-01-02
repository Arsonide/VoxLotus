using System;

namespace VoxLotus
{
    public class CyclicTicker : Ticker
    {
        public void Tick(bool isEnabled, DateTime expiry)
        {
            Expiry = expiry;

            TickerState currentState;

            if (!Expired)
            {
                if (!WithinWarningTime)
                    currentState = isEnabled ? TickerState.Enabled : TickerState.Disabled;
                else
                    currentState = isEnabled ? TickerState.Disabling : TickerState.Enabling;
            }
            else
                currentState = isEnabled ? TickerState.Disabled : TickerState.Enabled;

            SetState(currentState);
        }
    }
}
