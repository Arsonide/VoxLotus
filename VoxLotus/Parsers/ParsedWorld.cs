using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WarframeNET;

namespace VoxLotus.Parsers
{
    public class ParsedWorld
    {
        public event Action<string> OnSpeakMessage;
        public event Action<string> OnPopupMessage;
        public event Action<string, string> OnLogMessage;

        public event Action<List<ParsedOperation>> OnOperationsInitialized;
        public event Action<ParsedOperation> OnOperationStarted;
        public event Action<ParsedOperation> OnOperationEnded;

        public bool OperationsInitialized { get; protected set; }

        protected readonly Dictionary<string, ParsedOperation> operations = new Dictionary<string, ParsedOperation>();

        protected TimeSpan dailyResetTime = new TimeSpan(0, 0, 0);
        protected TimeSpan missionResetTime = new TimeSpan(16, 0, 0);

        public readonly AbsoluteTicker DailyTicker = new AbsoluteTicker();
        public readonly AbsoluteTicker MissionTicker = new AbsoluteTicker();

        public readonly CyclicTicker CetusTicker = new CyclicTicker();
        public readonly CyclicTicker EarthTicker = new CyclicTicker();

        public readonly Extractor TitanExtractor = new Extractor("Titan", new TimeSpan(4, 0, 0));
        public readonly Extractor DistillingExtractor = new Extractor("Distilling", new TimeSpan(8, 0, 0));

        public ParsedWorld()
        {
            DailyTicker.ResetToTimeSpecific(dailyResetTime);
            MissionTicker.ResetToTimeSpecific(missionResetTime);
            DailyTicker.OnStateChanged += OnDailyState;
            MissionTicker.OnStateChanged += OnMissionState;
            CetusTicker.OnStateChanged += OnCetusState;
            EarthTicker.OnStateChanged += OnEarthState;
            TitanExtractor.OnExtractorNotification += OnExtractorNotification;
            DistillingExtractor.OnExtractorNotification += OnExtractorNotification;
        }

        public void Tick(WorldState state)
        {
            TickOperations(state);
            DailyTicker.Tick();
            MissionTicker.Tick();
            CetusTicker.Tick(state.WS_CetusCycle.isDay, state.WS_CetusCycle.expiry);
            EarthTicker.Tick(state.WS_EarthCycle.isDay, state.WS_EarthCycle.expiry);
            TitanExtractor.TickExtractor();
            DistillingExtractor.TickExtractor();
        }

        protected void Broadcast(string message, bool popup = true, bool speak = true)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            if (popup)
                OnPopupMessage?.Invoke(message);

            if (speak)
                OnSpeakMessage?.Invoke(message);
        }

        protected void OnExtractorNotification(string notification)
        {
            OnPopupMessage?.Invoke(notification);
            OnSpeakMessage?.Invoke(notification);
            OnLogMessage?.Invoke("Extractors", notification);
        }

        #region Operations

        protected void TickOperations(WorldState state)
        {
            RefreshAlerts(state.WS_Alerts);
            RefreshInvasions(state.WS_Invasions);
            CullOperations();

            if (!OperationsInitialized)
            {
                OperationsInitialized = true;
                OnOperationsInitialized?.Invoke(new List<ParsedOperation>(operations.Values));
            }
        }

        protected void RefreshAlerts(IEnumerable<Alert> alerts)
        {
            foreach(Alert alert in alerts)
            {
                RefreshOperation(new ParsedAlert(alert));
            }
        }

        protected void RefreshInvasions(IEnumerable<Invasion> invasions)
        {
            foreach (Invasion invasion in invasions)
            {
                RefreshOperation(new ParsedInvasion(invasion));
            }
        }

        protected void CullOperations()
        {
            var keys = new List<string>(operations.Keys);

            foreach (string key in keys)
            {
                ParsedOperation operation = operations[key];

                if (operation.Expired)
                    RemoveOperation(operation);

                // Connected gets set to true if an operation is being refreshed, so set it false for everything now.
                if (operation.Connected)
                    operation.Connected = false;
                else
                    RemoveOperation(operation);
            }
        }

        protected void RefreshOperation(ParsedOperation operation)
        {
            operation.Connected = true;

            // Update existing operations.
            if (operations.ContainsKey(operation.Id))
            {
                operations[operation.Id] = operation;
                return;
            }

            // Do not add new operations if they are expired.
            if (operation.Expired)
                return;

            // Add new operations.
            operations.Add(operation.Id, operation);
            OnOperationStarted?.Invoke(operation);
        }

        protected void RemoveOperation(ParsedOperation operation)
        {
            if (!operations.ContainsKey(operation.Id))
                return;

            operations.Remove(operation.Id);
            OnOperationEnded?.Invoke(operation);
        }

        public ParsedOperation GetOperationById(string id)
        {
            return operations.ContainsKey(id) ? operations[id] : null;
        }

        #endregion

        #region Absolute Tickers

        protected void AbsoluteResetBroadcast(TickerState state, string ticker, CheckState checkState)
        {
            if (checkState == CheckState.Unchecked)
                return;

            string notification = null;

            switch (state)
            {
                case TickerState.Disabling:
                    notification = $"{ticker} will be resetting soon.";
                    break;
                case TickerState.Disabled:
                    notification = $"{ticker} have reset for the day.";
                    OnLogMessage?.Invoke("Reset", notification);
                    break;
            }

            Broadcast(notification);
        }

        protected void OnDailyState(TickerState state)
        {
            AbsoluteResetBroadcast(state, "Daily rewards and faction standing limits", ConfigurationManager.Instance.Settings.DailyResets);

            if (state == TickerState.Disabled)
                DailyTicker.ResetToTimeSpecific(dailyResetTime);
        }

        protected void OnMissionState(TickerState state)
        {
            AbsoluteResetBroadcast(state, "Sorties and syndicate missions", ConfigurationManager.Instance.Settings.MissionResets);

            if (state == TickerState.Disabled)
                MissionTicker.ResetToTimeSpecific(missionResetTime);
        }

        #endregion

        #region Cyclic Tickers

        protected CyclicBroadcastType GetCyclicBroadcastType(CheckState daySetting, CheckState nightSetting)
        {
            bool allowDay = daySetting != CheckState.Unchecked;
            bool allowNight = nightSetting != CheckState.Unchecked;

            if (allowDay && allowNight)
                return CyclicBroadcastType.All;

            if (allowDay)
                return CyclicBroadcastType.OnlyEnabled;

            if (allowNight)
                return CyclicBroadcastType.OnlyDisabled;

            return CyclicBroadcastType.None;
        }

        protected string GetCyclicBroadcastString(TickerState state, CyclicBroadcastType broadcastType, string location)
        {
            switch (broadcastType)
            {
                case CyclicBroadcastType.All:
                    switch (state)
                    {
                        case TickerState.Enabled:
                            return $"Day time is starting {location}.";
                        case TickerState.Disabled:
                            return $"Night time is starting {location}.";
                        case TickerState.Disabling:
                            return $"Night time is starting soon {location}.";
                        case TickerState.Enabling:
                            return $"Day time is starting soon {location}.";
                        default:
                            return string.Empty;
                    }
                case CyclicBroadcastType.OnlyEnabled:
                    switch (state)
                    {
                        case TickerState.Enabled:
                            return $"Day time is starting {location}.";
                        case TickerState.Disabling:
                            return $"Day time is ending soon {location}.";
                        case TickerState.Enabling:
                            return $"Day time is starting soon {location}.";
                        default:
                            return string.Empty;
                    }
                case CyclicBroadcastType.OnlyDisabled:
                    switch (state)
                    {
                        case TickerState.Disabled:
                            return $"Night time is starting {location}.";
                        case TickerState.Disabling:
                            return $"Night time is starting soon {location}.";
                        case TickerState.Enabling:
                            return $"Night time is ending soon {location}.";
                        default:
                            return string.Empty;
                    }
                default:
                    return string.Empty;
            }
        }

        protected void OnCetusState(TickerState state)
        {
            CyclicBroadcastType type = GetCyclicBroadcastType(ConfigurationManager.Instance.Settings.CetusDayNotifications, ConfigurationManager.Instance.Settings.CetusNightNotifications);
            string broadcast = GetCyclicBroadcastString(state, type, "in Cetus");
            Broadcast(broadcast);
        }

        protected void OnEarthState(TickerState state)
        {
            CyclicBroadcastType type = GetCyclicBroadcastType(ConfigurationManager.Instance.Settings.EarthDayNotifications, ConfigurationManager.Instance.Settings.EarthNightNotifications);
            string broadcast = GetCyclicBroadcastString(state, type, "on Earth");
            Broadcast(broadcast);
        }

        #endregion
    }
}