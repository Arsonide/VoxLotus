﻿using System;

namespace VoxLotus
{
    public class AbsoluteTicker : Ticker
    {
        public void Tick()
        {
            TickerState currentState;

            if (!Expired)
                currentState = !WithinWarningTime ? TickerState.Enabled : TickerState.Disabling;
            else
                currentState = TickerState.Disabled;

            SetState(currentState);
        }

        public void ResetToTimeSpecific(DateTime time)
        {
            Expiry = time;
        }

        public void ResetToTimeSpecific(TimeSpan time)
        {
            DateTime now = DateTime.UtcNow;
            DateTime result = now.Date + time;
            Expiry = (now <= result) ? result : result.AddDays(1);
        }

        public void ResetToTimeOffset(TimeSpan offset)
        {
            Expiry = DateTime.UtcNow + offset;
        }
    }
}
