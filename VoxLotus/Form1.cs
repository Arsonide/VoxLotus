using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VoxLotus.Controls;
using VoxLotus.Parsers;

namespace VoxLotus
{
    public partial class Form1 : Form
    {
        protected readonly List<CheckBox> planetBoxes;
        protected readonly List<CheckBox> rewardBoxes;

        protected bool eventFreeze;
        protected const string synchingTimer = "--:--:--";

        public event Action OnSaveExtractors;

        public Form1()
        {
            InitializeComponent();

            planetBoxes = new List<CheckBox>();
            rewardBoxes = new List<CheckBox>();

            AddCheckBoxes(ConfigEntryType.Planet, planetTab, planetBoxes);
            AddCheckBoxes(ConfigEntryType.Aura, auraTab, rewardBoxes);
            AddCheckBoxes(ConfigEntryType.Blueprint, blueprintTab, rewardBoxes);
            AddCheckBoxes(ConfigEntryType.Mod, modTab, rewardBoxes);
            AddCheckBoxes(ConfigEntryType.Resource, resourcesTab, rewardBoxes);
            AddCheckBoxes(ConfigEntryType.Weapon, weaponsTab, rewardBoxes);
            AddCheckBoxes(ConfigEntryType.Helmet, helmetsTab, rewardBoxes);
            AddCheckBoxes(ConfigEntryType.Skin, skinsTab, rewardBoxes);
            AddCheckBoxes(ConfigEntryType.Other, otherTab, rewardBoxes);

            FormClosing += Form1_Closing;
            Application.ApplicationExit += Application_Exiting;

            if (ConfigurationManager.Instance == null)
                WriteSettings();
            else
                ReadSettings();

            if (string.IsNullOrWhiteSpace(customSearchBox.Text))
                customSearchBox.Text = ConfigurationSettings.DefaultCustomSearch;
            else
                customSearchBox.ForeColor = SystemColors.ControlText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            Hide();

            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }

        private void Application_Exiting(object sender, EventArgs e)
        {
            WriteSettings();
        }

        public void Popup()
        {
            if (!Visible)
                Show();

            Activate();
        }

        #region Settings

        private void SettingsChanged(object sender, EventArgs e)
        {
            if (eventFreeze)
                return;

            WriteSettings();
        }

        public void ReadSettings()
        {
            eventFreeze = true;

            foreach (CheckBox checkBox in planetBoxes)
            {
                if (ConfigurationManager.Instance.HasEntryName(checkBox.Name))
                    checkBox.CheckState = ConfigurationManager.Instance.GetEntryByName(checkBox.Name).EntryCheckState;
            }

            foreach (CheckBox checkBox in rewardBoxes)
            {
                if (ConfigurationManager.Instance.HasEntryName(checkBox.Name))
                    checkBox.CheckState = ConfigurationManager.Instance.GetEntryByName(checkBox.Name).EntryCheckState;
            }

            popupInGameBox.CheckState = ConfigurationManager.Instance.Settings.PopUpInGame;
            popupOutOfGameBox.CheckState = ConfigurationManager.Instance.Settings.PopUpOutOfGame;
            speakInGameBox.CheckState = ConfigurationManager.Instance.Settings.SpeakInGame;
            speakOutOfGameBox.CheckState = ConfigurationManager.Instance.Settings.SpeakOutOfGame;

            dailyResetBox.CheckState = ConfigurationManager.Instance.Settings.DailyResets;
            missionResetBox.CheckState = ConfigurationManager.Instance.Settings.MissionResets;
            cetusDayBox.CheckState = ConfigurationManager.Instance.Settings.CetusDayNotifications;
            cetusNightBox.CheckState = ConfigurationManager.Instance.Settings.CetusNightNotifications;
            earthDayBox.CheckState = ConfigurationManager.Instance.Settings.EarthDayNotifications;
            earthNightBox.CheckState = ConfigurationManager.Instance.Settings.EarthNightNotifications;

            undefinedCheckbox.CheckState = ConfigurationManager.Instance.Settings.UndefinedInterest;

            creditsCheckbox.CheckState = ConfigurationManager.Instance.Settings.CreditsInterest;
            creditAmount.Value = ConfigurationManager.Instance.Settings.CreditsAmount;

            endoCheckbox.CheckState = ConfigurationManager.Instance.Settings.EndoInterest;
            endoAmount.Value = ConfigurationManager.Instance.Settings.EndoAmount;

            if (!string.IsNullOrWhiteSpace(ConfigurationManager.Instance.Settings.CustomSearch))
                customSearchBox.Text = ConfigurationManager.Instance.Settings.CustomSearch;

            eventFreeze = false;
        }

        public void WriteSettings()
        {
            foreach (CheckBox checkBox in planetBoxes)
            {
                if (ConfigurationManager.Instance.HasEntryName(checkBox.Name))
                    ConfigurationManager.Instance.GetEntryByName(checkBox.Name).EntryCheckState = checkBox.CheckState;
            }

            foreach (CheckBox checkBox in rewardBoxes)
            {
                if (ConfigurationManager.Instance.HasEntryName(checkBox.Name))
                    ConfigurationManager.Instance.GetEntryByName(checkBox.Name).EntryCheckState = checkBox.CheckState;
            }

            ConfigurationManager.Instance.Settings.PopUpInGame = popupInGameBox.CheckState;
            ConfigurationManager.Instance.Settings.PopUpOutOfGame = popupOutOfGameBox.CheckState;
            ConfigurationManager.Instance.Settings.SpeakInGame = speakInGameBox.CheckState;
            ConfigurationManager.Instance.Settings.SpeakOutOfGame = speakOutOfGameBox.CheckState;

            ConfigurationManager.Instance.Settings.DailyResets = dailyResetBox.CheckState;
            ConfigurationManager.Instance.Settings.MissionResets = missionResetBox.CheckState;
            ConfigurationManager.Instance.Settings.CetusDayNotifications = cetusDayBox.CheckState;
            ConfigurationManager.Instance.Settings.CetusNightNotifications = cetusNightBox.CheckState;
            ConfigurationManager.Instance.Settings.EarthDayNotifications = earthDayBox.CheckState;
            ConfigurationManager.Instance.Settings.EarthNightNotifications = earthNightBox.CheckState;

            ConfigurationManager.Instance.Settings.UndefinedInterest = undefinedCheckbox.CheckState;

            ConfigurationManager.Instance.Settings.CreditsInterest = creditsCheckbox.CheckState;
            ConfigurationManager.Instance.Settings.CreditsAmount = creditAmount.Value;

            ConfigurationManager.Instance.Settings.EndoInterest = endoCheckbox.CheckState;
            ConfigurationManager.Instance.Settings.EndoAmount = endoAmount.Value;

            if (!string.IsNullOrWhiteSpace(customSearchBox.Text) && customSearchBox.Text != ConfigurationSettings.DefaultCustomSearch)
                ConfigurationManager.Instance.Settings.CustomSearch = customSearchBox.Text;

            OnSaveExtractors?.Invoke();

            ConfigurationManager.SaveInstance();
        }

        #endregion

        #region UI

        public void AddCheckBoxes(ConfigEntryType type, TabPage tabPage, List<CheckBox> boxList)
        {
            if (!ConfigurationManager.Instance.HasEntriesOfType(type))
                return;

            List<ConfigurationEntry> entries = ConfigurationManager.Instance.GetEntriesOfType(type);

            if (entries == null || entries.Count <= 0)
                return;

            int columnCount = 15;

            if (entries.Count > 42)
            {
                columnCount = 14;
                tabPage.AutoScroll = true;
            }

            for (int i = 0; i < entries.Count; i++)
            {
                var checkBox = new CheckBox
                {
                    Location = new Point(6 + (i / columnCount) * 178, 6 + (i % columnCount) * 23),
                    Size = new Size(175, 17),
                    Name = entries[i].EntryName,
                    Text = entries[i].GetDisplay(),
                    ThreeState = true,
                    CheckState = CheckState.Checked
                };

                checkBox.CheckStateChanged += SettingsChanged;
                toolTip1.SetToolTip(checkBox, "Checked: Always Notify, Unchecked: Never notify, Dotted: Notify if mission is quick and easy.");
                tabPage.Controls.Add(checkBox);
                boxList.Add(checkBox);
            }
        }

        private void Specifics_Enter(object sender, EventArgs e)
        {
            customSearchBox.ForeColor = SystemColors.ControlText;

            if (customSearchBox.Text == ConfigurationSettings.DefaultCustomSearch)
                customSearchBox.Text = string.Empty;
        }

        private void Specifics_Leave(object sender, EventArgs e)
        {
            if (customSearchBox.Text != string.Empty)
                return;

            customSearchBox.ForeColor = SystemColors.GrayText;
            customSearchBox.Text = ConfigurationSettings.DefaultCustomSearch;
        }

        #endregion

        #region Main Tab

        public bool IsMainTabVisible()
        {
            bool visible = this.SafeInvoke(() => Visible);

            if (!visible || Overview == null || mainTab == null)
                return false;

            TabPage selectedTab = Overview.SafeInvoke(() => Overview.SelectedTab);

            return selectedTab == mainTab;
        }

        public void UpdateActiveItems()
        {
            this.SafeInvoke(() =>
            {
                if (activeEvents?.Items == null || activeEvents.Items.Count <= 0)
                    return;

                foreach (WarframeListBoxItem item in activeEvents.Items)
                {
                    item.Update();
                }

                activeEvents.Refresh();
            });
        }

        public void RefreshMainTab(ParsedWorld world)
        {
            this.SafeInvoke(() =>
            {
                RefreshExtractorLabel(world.TitanExtractor, titanExtractorTimerLabel);
                RefreshExtractorLabel(world.DistillingExtractor, distillingExtractorTimerLabel);
                RefreshAbsoluteLabel(world.DailyTicker, dailyTimerLabel);
                RefreshAbsoluteLabel(world.MissionTicker, missionTimerLabel);
                RefreshCyclicLabel(world.CetusTicker, cetusDayTimerLabel, cetusNightTimerLabel);
                RefreshCyclicLabel(world.EarthTicker, earthDayTimerLabel, earthNightTimerLabel);
            });
        }

        protected void RefreshExtractorLabel(Extractor extractor, Label label)
        {
            if (extractor == null || !extractor.IsActive)
            {
                label.Text = string.Empty;
                return;
            }

            TimeSpan span = extractor.TimeLeft;
            label.Text = span.TotalSeconds >= 0 ? span.ToString(@"hh\:mm\:ss") : synchingTimer;
        }

        protected void RefreshAbsoluteLabel(AbsoluteTicker ticker, Label label)
        {
            if (ticker == null)
            {
                label.Text = string.Empty;
                return;
            }

            TimeSpan span = ticker.TimeLeft;
            label.Text = span.TotalSeconds >= 0 ? span.ToString(@"hh\:mm\:ss") : synchingTimer;
        }

        protected void RefreshCyclicLabel(CyclicTicker ticker, Label dayLabel, Label nightLabel)
        {
            if (ticker == null)
            {
                dayLabel.Text = string.Empty;
                nightLabel.Text = string.Empty;
                return;
            }

            bool isDay = ticker.State == TickerState.Enabled || ticker.State == TickerState.Disabling;

            TimeSpan span = ticker.TimeLeft;
            string timeLabel = span.TotalSeconds >= 0 ? span.ToString(@"hh\:mm\:ss") : synchingTimer;

            if (isDay)
            {
                dayLabel.Text = timeLabel;
                nightLabel.Text = string.Empty;
            }
            else
            {
                dayLabel.Text = string.Empty;
                nightLabel.Text = timeLabel;
            }
        }

        #endregion

        #region Operations

        public void AddOperation(ParsedWorld world, ParsedOperation operation)
        {
            if (operation == null)
                return;

            if (operation.Relevant)
                activeEvents.AddItemToBottom(new ActiveOperationListBoxItem(world, operation.Id));

            loggedEvents.AddItemToTop(new LoggedOperationListBoxItem(operation));
        }

        public void RemoveOperation(ParsedWorld world, ParsedOperation operation)
        {
            if (operation != null)
                activeEvents.RemoveItem(operation.Id);
        }

        #endregion

        #region Log

        public void LogMessage(string title, string message, bool bold)
        {
            loggedEvents.AddItemToTop(new LoggedMessageListBoxItem(title, message, bold));
        }

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            loggedEvents.ClearItems();
        }

        #endregion
    }
}
