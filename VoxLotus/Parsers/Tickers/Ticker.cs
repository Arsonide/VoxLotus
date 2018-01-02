using System;

namespace VoxLotus
{
    public abstract class Ticker
    {
        public event Action<TickerState> OnStateChanged;
        public TickerState State { get; protected set; }
        public DateTime Expiry { get; protected set; }

        public TimeSpan TimeLeft => Expiry.Subtract(DateTime.UtcNow);
        public bool Expired => Expiry <= DateTime.UtcNow;

        protected bool WithinWarningTime => ConfigurationManager.Instance.Settings.WarningTimeAllowed && (decimal)TimeLeft.TotalMinutes < ConfigurationManager.Instance.Settings.WarningTimeAmount;

        protected void SetState(TickerState newState)
        {
            if (State == newState)
                return;

            State = newState;
            OnStateChanged?.Invoke(State);
        }
    }
}
