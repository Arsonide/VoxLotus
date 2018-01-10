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

        protected readonly TimeSpan nightDuration = new TimeSpan(0, 50, 0);

        public readonly AbsoluteTicker DailyTicker = new AbsoluteTicker();
        public readonly AbsoluteTicker MissionTicker = new AbsoluteTicker();

        public readonly CetusTicker CetusTicker = new CetusTicker();
        public readonly EarthTicker EarthTicker = new EarthTicker();

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
            CetusTicker.Tick(state);
            EarthTicker.Tick(state);
            TitanExtractor.TickExtractor();
            DistillingExtractor.TickExtractor();
        }

        protected void Broadcast(string message, bool popup = true, bool speak = true)
        {
            if (string.IsNullOrEmpty(message))
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

        protected void AbsoluteResetBroadcast(Ticker ticker, TickerState oldState, TickerState newState, string tickerDescription, CheckState tickerChecked)
        {
            if (tickerChecked == CheckState.Unchecked)
                return;

            string notification = null;

            if (oldState == TickerState.Uninitialized)
            {
                if (ConfigurationManager.Instance.Settings.ResetBriefingsAllowed)
                {
                    string remainingTime = newState == TickerState.Disabling ? "soon" : $"in {Utilities.ReadableTimeSpan(ticker.TimeLeft, false)}";
                    notification = $"{tickerDescription} will be resetting {remainingTime}.";
                }
            }
            else
            {
                if (newState == TickerState.Disabled)
                {
                    notification = $"{tickerDescription} have reset for the day.";
                    OnLogMessage?.Invoke("Reset", notification);
                }
                else if (newState == TickerState.Disabling)
                    notification = $"{tickerDescription} will be resetting soon.";
            }

            if (!string.IsNullOrEmpty(notification))
                Broadcast(notification);
        }

        protected void OnDailyState(TickerState oldState, TickerState newState)
        {
            AbsoluteResetBroadcast(DailyTicker, oldState, newState, "Daily rewards and faction standing limits", ConfigurationManager.Instance.Settings.DailyResets);

            if (newState == TickerState.Disabled)
                DailyTicker.ResetToTimeSpecific(dailyResetTime);
        }

        protected void OnMissionState(TickerState oldState, TickerState newState)
        {
            AbsoluteResetBroadcast(MissionTicker, oldState, newState, "Sorties and syndicate missions", ConfigurationManager.Instance.Settings.MissionResets);

            if (newState == TickerState.Disabled)
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

        protected string CyclicBroadcastStartString(TickerState state, CyclicBroadcastType broadcastType, string location)
        {
            if (!ConfigurationManager.Instance.Settings.CyclicBriefingsAllowed || broadcastType == CyclicBroadcastType.None)
                return null;

            // For the briefing, context doesn't matter much. It gets weird if you try to make these in the context of only day or only night.
            switch (state)
            {
                case TickerState.Enabled:
                    return $"It is day time {location}.";
                case TickerState.Disabled:
                    return $"It is night time {location}.";
                case TickerState.Disabling:
                    return $"It will be night time {location} soon.";
                case TickerState.Enabling:
                    return $"It will be day time {location} soon.";
                default:
                    return null;
            }
        }

        protected string CyclicBroadcastChangeString(TickerState state, CyclicBroadcastType broadcastType, string location)
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
                            return $"Night time is starting {location} soon.";
                        case TickerState.Enabling:
                            return $"Day time is starting {location} soon.";
                        default:
                            return null;
                    }
                case CyclicBroadcastType.OnlyEnabled:
                    switch (state)
                    {
                        case TickerState.Enabled:
                            return $"Day time is starting {location}.";
                        case TickerState.Disabled:
                            return $"Day time is ending {location}.";
                        case TickerState.Disabling:
                            return $"Day time is ending {location} soon.";
                        case TickerState.Enabling:
                            return $"Day time is starting {location} soon.";
                        default:
                            return null;
                    }
                case CyclicBroadcastType.OnlyDisabled:
                    switch (state)
                    {
                        case TickerState.Enabled:
                            return $"Night time is ending {location}.";
                        case TickerState.Disabled:
                            return $"Night time is starting {location}.";
                        case TickerState.Disabling:
                            return $"Night time is starting {location} soon.";
                        case TickerState.Enabling:
                            return $"Night time is ending {location} soon.";
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }

        protected void OnCetusState(TickerState oldState, TickerState newState)
        {
            string location = "in Cetus";
            CyclicBroadcastType type = GetCyclicBroadcastType(ConfigurationManager.Instance.Settings.CetusDayNotifications, ConfigurationManager.Instance.Settings.CetusNightNotifications);
            string broadcast = oldState == TickerState.Uninitialized ? CyclicBroadcastStartString(newState, type, location) : CyclicBroadcastChangeString(newState, type, location);

            if (!string.IsNullOrEmpty(broadcast))
                Broadcast(broadcast);
        }

        protected void OnEarthState(TickerState oldState, TickerState newState)
        {
            string location = "on Earth";
            CyclicBroadcastType type = GetCyclicBroadcastType(ConfigurationManager.Instance.Settings.EarthDayNotifications, ConfigurationManager.Instance.Settings.EarthNightNotifications);
            string broadcast = oldState == TickerState.Uninitialized ? CyclicBroadcastStartString(newState, type, location) : CyclicBroadcastChangeString(newState, type, location);

            if (!string.IsNullOrEmpty(broadcast))
                Broadcast(broadcast);
        }

        #endregion
    }
}