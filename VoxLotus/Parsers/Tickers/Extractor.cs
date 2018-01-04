using System;

namespace VoxLotus
{
    public class Extractor
    {
        public readonly string Name;
        protected readonly AbsoluteTicker ticker = new AbsoluteTicker();
        public TimeSpan ProcessingTime { get; }
        public bool IsActive { get; protected set; }
        public DateTime Expiry => ticker.Expiry;
        public TimeSpan TimeLeft => ticker.TimeLeft;

        public event Action OnExtractorFinished;
        public event Action<string> OnExtractorNotification;

        public Extractor(string name, TimeSpan processingTime)
        {
            Name = name;
            ProcessingTime = processingTime;
            ticker.OnStateChanged += OnTickerState;
            IsActive = false;
        }

        public void StartExtractor(bool notify = true)
        {
            ticker.ResetToTimeOffset(ProcessingTime);
            IsActive = true;

            if (notify)
                OnExtractorNotification?.Invoke($"{Name} extractors started, they will complete their resource harvesting in {Utilities.ReadableTimeSpan(ProcessingTime, false)}.");
        }

        public void StopExtractor(bool notify = true)
        {
            IsActive = false;

            if (notify)
                OnExtractorNotification?.Invoke($"{Name} extractor resource harvesting cancelled.");
        }

        public void ResumeExtractor(long ticks, bool notify = true)
        {
            var timeExpiry = new DateTime(ticks);
            ticker.ResetToTimeSpecific(timeExpiry);
            IsActive = timeExpiry > DateTime.UtcNow;

            if (!notify)
                return;

            if (IsActive)
                OnExtractorNotification?.Invoke($"{Name} extractors resumed, they will complete their resource harvesting in {Utilities.ReadableTimeSpan(timeExpiry.Subtract(DateTime.UtcNow), false)}.");
            else
                OnExtractorNotification?.Invoke($"{Name} extractors completed their resource harvesting {Utilities.ReadableTimeSpan(DateTime.UtcNow.Subtract(timeExpiry), false)} ago.");
        }

        public void TickExtractor()
        {
            if (IsActive)
                ticker.Tick();
        }

        protected void OnTickerState(TickerState oldState, TickerState newState)
        {
            switch(newState)
            {
                case TickerState.Disabling:
                    OnExtractorNotification?.Invoke($"{Name} extractors will complete their resource harvesting soon.");
                    break;
                case TickerState.Disabled:
                    OnExtractorNotification?.Invoke($"{Name} extractors have completed their resource harvesting.");
                    IsActive = false;
                    OnExtractorFinished?.Invoke();
                    break;
            }
        }
    }
}
