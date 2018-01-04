using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using VoxLotus.Parsers;
using WarframeNET;

namespace VoxLotus
{
    internal class Context1 : ApplicationContext
    {
        protected readonly Form1 configWindow;
        protected readonly NotifyIcon notifyIcon;

        protected readonly WarframeClient client;
        protected readonly ParsedWorld world;
        protected readonly SpeechSynthesizer voice;

        protected ConnectionStatus status = ConnectionStatus.Connecting;

        protected bool disableTitanExtractorEvents;
        protected bool disableDistillingExtractorEvents;

        public Context1()
        {
            configWindow = new Form1();

            var configMenuItem = new MenuItem("Modify Filter...", ShowConfig);
            var exitMenuItem = new MenuItem("Exit", Exit);

            voice = new SpeechSynthesizer();
            voice.SelectVoiceByHints(VoiceGender.Female);

            notifyIcon = new NotifyIcon
            {
                Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetEntryAssembly().ManifestModule.Name),
                ContextMenu = new ContextMenu(new[] { configMenuItem, exitMenuItem }),
                Visible = true
            };

            notifyIcon.MouseDoubleClick += ShowConfig;

            client = new WarframeClient();

            world = new ParsedWorld();
            world.OnOperationStarted += OnOperationStarted;
            world.OnOperationEnded += OnOperationEnded;
            world.OnOperationsInitialized += OnOperationsInitialized;
            world.OnPopupMessage += Popup;
            world.OnSpeakMessage += Speak;
            world.OnLogMessage += Log;

            OnLoadExtractors();
            configWindow.OnSaveExtractors += OnSaveExtractors;

            world.TitanExtractor.OnExtractorFinished += OnTitanExtractorFinished;
            configWindow.titanExtractorBox.CheckedChanged += TitanExtractorCheckChanged;

            world.DistillingExtractor.OnExtractorFinished += OnDistillingExtractorFinished;
            configWindow.distillingExtractorBox.CheckedChanged += DistillingExtractorCheckChanged;

            var secondTimer = new System.Timers.Timer();
            secondTimer.Elapsed += SecondTimer;
            secondTimer.Interval = 1000;
            secondTimer.Enabled = true;

            var minuteTimer = new System.Timers.Timer();
            minuteTimer.Elapsed += MinuteTimer;
            minuteTimer.Interval = 60000;
            minuteTimer.Enabled = true;

            Log("System", "Connecting...");
            RefreshWorldState();

            configWindow.Show();
        }

        protected void ShowConfig(object sender, EventArgs e)
        {
            configWindow.SafeInvoke(() => { configWindow.Popup(); });
        }

        public void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        public bool AllowIfGameClientRunning(bool inGameAllowed, bool outOfGameAllowed)
        {
            if (inGameAllowed && outOfGameAllowed)
                return true;

            if (!inGameAllowed && !outOfGameAllowed)
                return false;

            foreach (Process process in Process.GetProcesses())
            {
                if (string.IsNullOrEmpty(process.MainWindowTitle))
                    continue;

                if (process.ProcessName == "Warframe.x64" || process.ProcessName == "Warframe")
                    return inGameAllowed;
            }

            return outOfGameAllowed;
        }

        #region Timers

        public void SecondTimer(object source, ElapsedEventArgs e)
        {
            if (world != null && configWindow != null && configWindow.IsMainTabVisible())
                configWindow.RefreshMainTab(world);
        }

        public void MinuteTimer(object source, ElapsedEventArgs e)
        {
            RefreshWorldState();
            configWindow?.UpdateActiveItems();
        }

        protected async void RefreshWorldState()
        {
            Task<WorldState> task;

            try
            {
                task = client.GetWorldStateAsync("pc/");
                await task;
            }
            catch
            {
                if (status != ConnectionStatus.Issue)
                    Log("System", "Having trouble retrieving world state. Will retry every minute.");

                status = ConnectionStatus.Issue;
                return;
            }

            if (status == ConnectionStatus.Connecting)
                Log("System", "Connected. Scanning for alerts matching your filter...");

            if (status == ConnectionStatus.Issue)
                Log("System", "Reconnected.");

            status = ConnectionStatus.Connected;

            world.Tick(task.Result);
        }

        #endregion

        #region Notifications

        protected void Popup(string text)
        {
            if (!AllowIfGameClientRunning(ConfigurationManager.Instance.Settings.PopUpInGame != CheckState.Unchecked, ConfigurationManager.Instance.Settings.PopUpOutOfGame != CheckState.Unchecked))
                return;

            notifyIcon.BalloonTipTitle = @"Vox Lotus";
            notifyIcon.BalloonTipText = text;
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.ShowBalloonTip(10000);
        }

        public void Log(string title, string text)
        {
            configWindow.LogMessage(title, text, false);
        }

        protected void Speak(string text)
        {
            if (AllowIfGameClientRunning(ConfigurationManager.Instance.Settings.SpeakInGame != CheckState.Unchecked, ConfigurationManager.Instance.Settings.SpeakOutOfGame != CheckState.Unchecked))
                voice.SpeakAsync(text);
        }

        #endregion

        #region Operations

        protected void OnOperationStarted(ParsedOperation operation)
        {
            configWindow.AddOperation(world, operation);

            if (world.OperationsInitialized && operation.Relevant)
            {
                Speak(operation.Description(DescriptionType.Spoken));
                Popup(operation.Description(DescriptionType.Written));
            }
        }

        protected void OnOperationEnded(ParsedOperation operation)
        {
            configWindow.RemoveOperation(world, operation);
        }

        protected void OnOperationsInitialized(List<ParsedOperation> operations)
        {
            if (!ConfigurationManager.Instance.Settings.OperationBriefingsAllowed)
                return;

            int relevantOperations = 0;

            foreach (ParsedOperation operation in operations)
            {
                if (operation.Relevant)
                    relevantOperations++;
            }

            string notification;

            if (relevantOperations > 1)
                notification = $"There are currently {relevantOperations} active operations matching your filters.";
            else if (relevantOperations > 0)
                notification = "There is currently one active operation matching your filters.";
            else
                notification = "There are currently no active operations matching your filters.";

            Speak(notification);
            Popup(notification);
        }

        #endregion

        #region Extractors

        protected void OnSaveExtractors()
        {
            ConfigurationManager.Instance.Settings.TitanExtractorsExpiry = configWindow.titanExtractorBox.CheckState != CheckState.Unchecked ? world.TitanExtractor.Expiry.Ticks : 0;
            ConfigurationManager.Instance.Settings.DistillingExtractorsExpiry = configWindow.distillingExtractorBox.CheckState != CheckState.Unchecked ? world.DistillingExtractor.Expiry.Ticks : 0;
        }

        protected void OnLoadExtractors()
        {
            bool titanActive = ConfigurationManager.Instance.Settings.TitanExtractorsExpiry != 0;
            bool distillingActive = ConfigurationManager.Instance.Settings.DistillingExtractorsExpiry != 0;

            if (titanActive)
                world.TitanExtractor.ResumeExtractor(ConfigurationManager.Instance.Settings.TitanExtractorsExpiry, ConfigurationManager.Instance.Settings.ExtractorBriefingsAllowed);
            else
                world.TitanExtractor.StopExtractor(false);

            if (distillingActive)
                world.DistillingExtractor.ResumeExtractor(ConfigurationManager.Instance.Settings.DistillingExtractorsExpiry, ConfigurationManager.Instance.Settings.ExtractorBriefingsAllowed);
            else
                world.DistillingExtractor.StopExtractor(false);

            ForceTitanCheckBox(world.TitanExtractor.IsActive);
            ForceDistillingCheckBox(world.DistillingExtractor.IsActive);
        }

        protected void TitanExtractorCheckChanged(object sender, EventArgs e)
        {
            if (disableTitanExtractorEvents)
                return;

            if (configWindow.titanExtractorBox.Checked)
                world.TitanExtractor.StartExtractor();
            else
                world.TitanExtractor.StopExtractor();
        }

        protected void DistillingExtractorCheckChanged(object sender, EventArgs e)
        {
            if (disableDistillingExtractorEvents)
                return;

            if (configWindow.distillingExtractorBox.Checked)
                world.DistillingExtractor.StartExtractor();
            else
                world.DistillingExtractor.StopExtractor();
        }

        protected void ForceTitanCheckBox(bool active)
        {
            configWindow.titanExtractorBox.SafeInvoke(() =>
            {
                disableTitanExtractorEvents = true;
                configWindow.titanExtractorBox.CheckState = active ? CheckState.Checked : CheckState.Unchecked;
                disableTitanExtractorEvents = false;
            });
        }

        protected void ForceDistillingCheckBox(bool active)
        {
            configWindow.distillingExtractorBox.SafeInvoke(() =>
            {
                disableDistillingExtractorEvents = true;
                configWindow.distillingExtractorBox.CheckState = active ? CheckState.Checked : CheckState.Unchecked;
                disableDistillingExtractorEvents = false;
            });
        }

        protected void OnTitanExtractorFinished()
        {
            ForceTitanCheckBox(false);
        }

        protected void OnDistillingExtractorFinished()
        {
            ForceDistillingCheckBox(false);
        }

        #endregion
    }
}
