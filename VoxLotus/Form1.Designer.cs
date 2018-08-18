using System.Windows.Forms;
using VoxLotus.Controls;

namespace VoxLotus
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Overview = new System.Windows.Forms.TabControl();
            this.mainTab = new System.Windows.Forms.TabPage();
            this.titanExtractorTimerLabel = new System.Windows.Forms.Label();
            this.distillingExtractorTimerLabel = new System.Windows.Forms.Label();
            this.earthNightTimerLabel = new System.Windows.Forms.Label();
            this.earthDayTimerLabel = new System.Windows.Forms.Label();
            this.cetusNightTimerLabel = new System.Windows.Forms.Label();
            this.cetusDayTimerLabel = new System.Windows.Forms.Label();
            this.missionTimerLabel = new System.Windows.Forms.Label();
            this.dailyTimerLabel = new System.Windows.Forms.Label();
            this.speakOutOfGameBox = new System.Windows.Forms.CheckBox();
            this.popupOutOfGameBox = new System.Windows.Forms.CheckBox();
            this.distillingExtractorBox = new System.Windows.Forms.CheckBox();
            this.titanExtractorBox = new System.Windows.Forms.CheckBox();
            this.speakInGameBox = new System.Windows.Forms.CheckBox();
            this.popupInGameBox = new System.Windows.Forms.CheckBox();
            this.missionResetBox = new System.Windows.Forms.CheckBox();
            this.dailyResetBox = new System.Windows.Forms.CheckBox();
            this.cetusNightBox = new System.Windows.Forms.CheckBox();
            this.cetusDayBox = new System.Windows.Forms.CheckBox();
            this.earthNightBox = new System.Windows.Forms.CheckBox();
            this.earthDayBox = new System.Windows.Forms.CheckBox();
            this.logTab = new System.Windows.Forms.TabPage();
            this.clearLogButton = new System.Windows.Forms.Button();
            this.planetTab = new System.Windows.Forms.TabPage();
            this.resourcesTab = new System.Windows.Forms.TabPage();
            this.auraTab = new System.Windows.Forms.TabPage();
            this.modTab = new System.Windows.Forms.TabPage();
            this.blueprintTab = new System.Windows.Forms.TabPage();
            this.helmetsTab = new System.Windows.Forms.TabPage();
            this.weaponsTab = new System.Windows.Forms.TabPage();
            this.skinsTab = new System.Windows.Forms.TabPage();
            this.otherTab = new System.Windows.Forms.TabPage();
            this.undefinedCheckbox = new System.Windows.Forms.CheckBox();
            this.customSearchBox = new System.Windows.Forms.TextBox();
            this.endoAmount = new System.Windows.Forms.NumericUpDown();
            this.creditAmount = new System.Windows.Forms.NumericUpDown();
            this.endoCheckbox = new System.Windows.Forms.CheckBox();
            this.creditsCheckbox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkUncheckDotStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dotStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklyResetBox = new System.Windows.Forms.CheckBox();
            this.weeklyTimerLabel = new System.Windows.Forms.Label();
            this.activeEvents = new VoxLotus.Controls.WarframeListBox();
            this.loggedEvents = new VoxLotus.Controls.WarframeListBox();
            this.Overview.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.logTab.SuspendLayout();
            this.otherTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endoAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditAmount)).BeginInit();
            this.checkUncheckDotStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Overview
            // 
            this.Overview.Controls.Add(this.mainTab);
            this.Overview.Controls.Add(this.logTab);
            this.Overview.Controls.Add(this.planetTab);
            this.Overview.Controls.Add(this.resourcesTab);
            this.Overview.Controls.Add(this.auraTab);
            this.Overview.Controls.Add(this.modTab);
            this.Overview.Controls.Add(this.blueprintTab);
            this.Overview.Controls.Add(this.helmetsTab);
            this.Overview.Controls.Add(this.weaponsTab);
            this.Overview.Controls.Add(this.skinsTab);
            this.Overview.Controls.Add(this.otherTab);
            this.Overview.Location = new System.Drawing.Point(7, 7);
            this.Overview.Name = "Overview";
            this.Overview.SelectedIndex = 0;
            this.Overview.Size = new System.Drawing.Size(556, 398);
            this.Overview.TabIndex = 0;
            this.Overview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Overview_MouseUp);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.weeklyTimerLabel);
            this.mainTab.Controls.Add(this.weeklyResetBox);
            this.mainTab.Controls.Add(this.titanExtractorTimerLabel);
            this.mainTab.Controls.Add(this.distillingExtractorTimerLabel);
            this.mainTab.Controls.Add(this.earthNightTimerLabel);
            this.mainTab.Controls.Add(this.earthDayTimerLabel);
            this.mainTab.Controls.Add(this.cetusNightTimerLabel);
            this.mainTab.Controls.Add(this.cetusDayTimerLabel);
            this.mainTab.Controls.Add(this.missionTimerLabel);
            this.mainTab.Controls.Add(this.dailyTimerLabel);
            this.mainTab.Controls.Add(this.speakOutOfGameBox);
            this.mainTab.Controls.Add(this.popupOutOfGameBox);
            this.mainTab.Controls.Add(this.distillingExtractorBox);
            this.mainTab.Controls.Add(this.titanExtractorBox);
            this.mainTab.Controls.Add(this.speakInGameBox);
            this.mainTab.Controls.Add(this.popupInGameBox);
            this.mainTab.Controls.Add(this.missionResetBox);
            this.mainTab.Controls.Add(this.dailyResetBox);
            this.mainTab.Controls.Add(this.cetusNightBox);
            this.mainTab.Controls.Add(this.cetusDayBox);
            this.mainTab.Controls.Add(this.earthNightBox);
            this.mainTab.Controls.Add(this.earthDayBox);
            this.mainTab.Controls.Add(this.activeEvents);
            this.mainTab.Location = new System.Drawing.Point(4, 22);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainTab.Size = new System.Drawing.Size(548, 372);
            this.mainTab.TabIndex = 1;
            this.mainTab.Text = "Main";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // titanExtractorTimerLabel
            // 
            this.titanExtractorTimerLabel.Location = new System.Drawing.Point(172, 302);
            this.titanExtractorTimerLabel.Name = "titanExtractorTimerLabel";
            this.titanExtractorTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.titanExtractorTimerLabel.TabIndex = 20;
            this.titanExtractorTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // distillingExtractorTimerLabel
            // 
            this.distillingExtractorTimerLabel.Location = new System.Drawing.Point(172, 325);
            this.distillingExtractorTimerLabel.Name = "distillingExtractorTimerLabel";
            this.distillingExtractorTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.distillingExtractorTimerLabel.TabIndex = 19;
            this.distillingExtractorTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // earthNightTimerLabel
            // 
            this.earthNightTimerLabel.Location = new System.Drawing.Point(300, 348);
            this.earthNightTimerLabel.Name = "earthNightTimerLabel";
            this.earthNightTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.earthNightTimerLabel.TabIndex = 18;
            this.earthNightTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // earthDayTimerLabel
            // 
            this.earthDayTimerLabel.Location = new System.Drawing.Point(300, 325);
            this.earthDayTimerLabel.Name = "earthDayTimerLabel";
            this.earthDayTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.earthDayTimerLabel.TabIndex = 17;
            this.earthDayTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cetusNightTimerLabel
            // 
            this.cetusNightTimerLabel.Location = new System.Drawing.Point(300, 302);
            this.cetusNightTimerLabel.Name = "cetusNightTimerLabel";
            this.cetusNightTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.cetusNightTimerLabel.TabIndex = 16;
            this.cetusNightTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cetusDayTimerLabel
            // 
            this.cetusDayTimerLabel.Location = new System.Drawing.Point(300, 279);
            this.cetusDayTimerLabel.Name = "cetusDayTimerLabel";
            this.cetusDayTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.cetusDayTimerLabel.TabIndex = 15;
            this.cetusDayTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // missionTimerLabel
            // 
            this.missionTimerLabel.Location = new System.Drawing.Point(300, 256);
            this.missionTimerLabel.Name = "missionTimerLabel";
            this.missionTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.missionTimerLabel.TabIndex = 14;
            this.missionTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dailyTimerLabel
            // 
            this.dailyTimerLabel.Location = new System.Drawing.Point(300, 233);
            this.dailyTimerLabel.Name = "dailyTimerLabel";
            this.dailyTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.dailyTimerLabel.TabIndex = 13;
            this.dailyTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // speakOutOfGameBox
            // 
            this.speakOutOfGameBox.AutoSize = true;
            this.speakOutOfGameBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.speakOutOfGameBox.Location = new System.Drawing.Point(6, 280);
            this.speakOutOfGameBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.speakOutOfGameBox.Name = "speakOutOfGameBox";
            this.speakOutOfGameBox.Size = new System.Drawing.Size(160, 17);
            this.speakOutOfGameBox.TabIndex = 12;
            this.speakOutOfGameBox.Text = "Speak Out Of Game";
            this.speakOutOfGameBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.speakOutOfGameBox, "Speak notifications with text to speech for events when Warframe is not running.");
            this.speakOutOfGameBox.UseVisualStyleBackColor = true;
            this.speakOutOfGameBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // popupOutOfGameBox
            // 
            this.popupOutOfGameBox.AutoSize = true;
            this.popupOutOfGameBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.popupOutOfGameBox.Checked = true;
            this.popupOutOfGameBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.popupOutOfGameBox.Location = new System.Drawing.Point(6, 234);
            this.popupOutOfGameBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.popupOutOfGameBox.Name = "popupOutOfGameBox";
            this.popupOutOfGameBox.Size = new System.Drawing.Size(160, 17);
            this.popupOutOfGameBox.TabIndex = 11;
            this.popupOutOfGameBox.Text = "Popup Out Of Game";
            this.popupOutOfGameBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.popupOutOfGameBox, "Pop up tray notifications for events when Warframe is not running.");
            this.popupOutOfGameBox.UseVisualStyleBackColor = true;
            this.popupOutOfGameBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // distillingExtractorBox
            // 
            this.distillingExtractorBox.AutoSize = true;
            this.distillingExtractorBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.distillingExtractorBox.Location = new System.Drawing.Point(6, 326);
            this.distillingExtractorBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.distillingExtractorBox.Name = "distillingExtractorBox";
            this.distillingExtractorBox.Size = new System.Drawing.Size(160, 17);
            this.distillingExtractorBox.TabIndex = 10;
            this.distillingExtractorBox.Text = "Distilling Extractors Active";
            this.distillingExtractorBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.distillingExtractorBox, "Start or stop a timer that will notify you when your distilling extractors finish" +
        " harvesting.");
            this.distillingExtractorBox.UseVisualStyleBackColor = true;
            this.distillingExtractorBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // titanExtractorBox
            // 
            this.titanExtractorBox.AutoSize = true;
            this.titanExtractorBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.titanExtractorBox.Location = new System.Drawing.Point(6, 303);
            this.titanExtractorBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.titanExtractorBox.Name = "titanExtractorBox";
            this.titanExtractorBox.Size = new System.Drawing.Size(160, 17);
            this.titanExtractorBox.TabIndex = 9;
            this.titanExtractorBox.Text = "Titan Extractors Active";
            this.titanExtractorBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.titanExtractorBox, "Start or stop a timer that will notify you when your titan extractors finish harv" +
        "esting.");
            this.titanExtractorBox.UseVisualStyleBackColor = true;
            this.titanExtractorBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // speakInGameBox
            // 
            this.speakInGameBox.AutoSize = true;
            this.speakInGameBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.speakInGameBox.Checked = true;
            this.speakInGameBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.speakInGameBox.Location = new System.Drawing.Point(6, 257);
            this.speakInGameBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.speakInGameBox.Name = "speakInGameBox";
            this.speakInGameBox.Size = new System.Drawing.Size(160, 17);
            this.speakInGameBox.TabIndex = 8;
            this.speakInGameBox.Text = "Speak In Game";
            this.speakInGameBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.speakInGameBox, "Speak notifications with text to speech for events when Warframe is running.");
            this.speakInGameBox.UseVisualStyleBackColor = true;
            this.speakInGameBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // popupInGameBox
            // 
            this.popupInGameBox.AutoSize = true;
            this.popupInGameBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.popupInGameBox.Location = new System.Drawing.Point(6, 211);
            this.popupInGameBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.popupInGameBox.Name = "popupInGameBox";
            this.popupInGameBox.Size = new System.Drawing.Size(160, 17);
            this.popupInGameBox.TabIndex = 7;
            this.popupInGameBox.Text = "Popup In Game";
            this.popupInGameBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.popupInGameBox, "Pop up tray notifications for events when Warframe is running.");
            this.popupInGameBox.UseVisualStyleBackColor = true;
            this.popupInGameBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // missionResetBox
            // 
            this.missionResetBox.AutoSize = true;
            this.missionResetBox.Checked = true;
            this.missionResetBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.missionResetBox.Location = new System.Drawing.Point(382, 257);
            this.missionResetBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.missionResetBox.Name = "missionResetBox";
            this.missionResetBox.Size = new System.Drawing.Size(160, 17);
            this.missionResetBox.TabIndex = 6;
            this.missionResetBox.Text = "Mission Reset Notification";
            this.missionResetBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.missionResetBox, "Notifies you when special missions like sorties and syndicate missions reset for " +
        "the day.");
            this.missionResetBox.UseVisualStyleBackColor = true;
            this.missionResetBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // dailyResetBox
            // 
            this.dailyResetBox.AutoSize = true;
            this.dailyResetBox.Checked = true;
            this.dailyResetBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dailyResetBox.Location = new System.Drawing.Point(382, 234);
            this.dailyResetBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.dailyResetBox.Name = "dailyResetBox";
            this.dailyResetBox.Size = new System.Drawing.Size(160, 17);
            this.dailyResetBox.TabIndex = 5;
            this.dailyResetBox.Text = "Daily Reset Notification";
            this.dailyResetBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.dailyResetBox, "Notifies you when the daily rewards and faction standing limits reset for the day" +
        ".");
            this.dailyResetBox.UseVisualStyleBackColor = true;
            this.dailyResetBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // cetusNightBox
            // 
            this.cetusNightBox.AutoSize = true;
            this.cetusNightBox.Checked = true;
            this.cetusNightBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cetusNightBox.Location = new System.Drawing.Point(382, 303);
            this.cetusNightBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.cetusNightBox.Name = "cetusNightBox";
            this.cetusNightBox.Size = new System.Drawing.Size(160, 17);
            this.cetusNightBox.TabIndex = 4;
            this.cetusNightBox.Text = "Cetus Night Notification";
            this.cetusNightBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.cetusNightBox, "Notifies you when night time is starting or stopping in the Plains of Eidolon.");
            this.cetusNightBox.UseVisualStyleBackColor = true;
            this.cetusNightBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // cetusDayBox
            // 
            this.cetusDayBox.AutoSize = true;
            this.cetusDayBox.Checked = true;
            this.cetusDayBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cetusDayBox.Location = new System.Drawing.Point(382, 280);
            this.cetusDayBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.cetusDayBox.Name = "cetusDayBox";
            this.cetusDayBox.Size = new System.Drawing.Size(160, 17);
            this.cetusDayBox.TabIndex = 3;
            this.cetusDayBox.Text = "Cetus Day Notification";
            this.cetusDayBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.cetusDayBox, "Notifies you when day time is starting or stopping in the Plains of Eidolon.");
            this.cetusDayBox.UseVisualStyleBackColor = true;
            this.cetusDayBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // earthNightBox
            // 
            this.earthNightBox.AutoSize = true;
            this.earthNightBox.Location = new System.Drawing.Point(382, 349);
            this.earthNightBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.earthNightBox.Name = "earthNightBox";
            this.earthNightBox.Size = new System.Drawing.Size(160, 17);
            this.earthNightBox.TabIndex = 2;
            this.earthNightBox.Text = "Earth Night Notification";
            this.earthNightBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.earthNightBox, "Notifies you when night time is starting or stopping on Earth.");
            this.earthNightBox.UseVisualStyleBackColor = true;
            this.earthNightBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // earthDayBox
            // 
            this.earthDayBox.AutoSize = true;
            this.earthDayBox.Location = new System.Drawing.Point(382, 326);
            this.earthDayBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.earthDayBox.Name = "earthDayBox";
            this.earthDayBox.Size = new System.Drawing.Size(160, 17);
            this.earthDayBox.TabIndex = 1;
            this.earthDayBox.Text = "Earth Day Notification";
            this.earthDayBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.earthDayBox, "Notifies you when day time is starting or stopping on Earth.");
            this.earthDayBox.UseVisualStyleBackColor = true;
            this.earthDayBox.CheckedChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.clearLogButton);
            this.logTab.Controls.Add(this.loggedEvents);
            this.logTab.Location = new System.Drawing.Point(4, 22);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(548, 372);
            this.logTab.TabIndex = 2;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // clearLogButton
            // 
            this.clearLogButton.Location = new System.Drawing.Point(0, 345);
            this.clearLogButton.Name = "clearLogButton";
            this.clearLogButton.Size = new System.Drawing.Size(548, 23);
            this.clearLogButton.TabIndex = 2;
            this.clearLogButton.Text = "Clear Log";
            this.clearLogButton.UseVisualStyleBackColor = true;
            this.clearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // planetTab
            // 
            this.planetTab.BackColor = System.Drawing.SystemColors.Control;
            this.planetTab.Location = new System.Drawing.Point(4, 22);
            this.planetTab.Name = "planetTab";
            this.planetTab.Padding = new System.Windows.Forms.Padding(3);
            this.planetTab.Size = new System.Drawing.Size(548, 372);
            this.planetTab.TabIndex = 0;
            this.planetTab.Text = "Planets";
            // 
            // resourcesTab
            // 
            this.resourcesTab.BackColor = System.Drawing.SystemColors.Control;
            this.resourcesTab.Location = new System.Drawing.Point(4, 22);
            this.resourcesTab.Name = "resourcesTab";
            this.resourcesTab.Padding = new System.Windows.Forms.Padding(3);
            this.resourcesTab.Size = new System.Drawing.Size(548, 372);
            this.resourcesTab.TabIndex = 4;
            this.resourcesTab.Text = "Resources";
            // 
            // auraTab
            // 
            this.auraTab.BackColor = System.Drawing.SystemColors.Control;
            this.auraTab.Location = new System.Drawing.Point(4, 22);
            this.auraTab.Name = "auraTab";
            this.auraTab.Padding = new System.Windows.Forms.Padding(3);
            this.auraTab.Size = new System.Drawing.Size(548, 372);
            this.auraTab.TabIndex = 3;
            this.auraTab.Text = "Auras";
            // 
            // modTab
            // 
            this.modTab.BackColor = System.Drawing.SystemColors.Control;
            this.modTab.Location = new System.Drawing.Point(4, 22);
            this.modTab.Name = "modTab";
            this.modTab.Padding = new System.Windows.Forms.Padding(3);
            this.modTab.Size = new System.Drawing.Size(548, 372);
            this.modTab.TabIndex = 5;
            this.modTab.Text = "Mods";
            // 
            // blueprintTab
            // 
            this.blueprintTab.BackColor = System.Drawing.SystemColors.Control;
            this.blueprintTab.Location = new System.Drawing.Point(4, 22);
            this.blueprintTab.Name = "blueprintTab";
            this.blueprintTab.Padding = new System.Windows.Forms.Padding(3);
            this.blueprintTab.Size = new System.Drawing.Size(548, 372);
            this.blueprintTab.TabIndex = 6;
            this.blueprintTab.Text = "Blueprints";
            // 
            // helmetsTab
            // 
            this.helmetsTab.BackColor = System.Drawing.SystemColors.Control;
            this.helmetsTab.Location = new System.Drawing.Point(4, 22);
            this.helmetsTab.Name = "helmetsTab";
            this.helmetsTab.Padding = new System.Windows.Forms.Padding(3);
            this.helmetsTab.Size = new System.Drawing.Size(548, 372);
            this.helmetsTab.TabIndex = 9;
            this.helmetsTab.Text = "Helmets";
            // 
            // weaponsTab
            // 
            this.weaponsTab.BackColor = System.Drawing.SystemColors.Control;
            this.weaponsTab.Location = new System.Drawing.Point(4, 22);
            this.weaponsTab.Name = "weaponsTab";
            this.weaponsTab.Padding = new System.Windows.Forms.Padding(3);
            this.weaponsTab.Size = new System.Drawing.Size(548, 372);
            this.weaponsTab.TabIndex = 8;
            this.weaponsTab.Text = "Weapons";
            // 
            // skinsTab
            // 
            this.skinsTab.BackColor = System.Drawing.SystemColors.Control;
            this.skinsTab.Location = new System.Drawing.Point(4, 22);
            this.skinsTab.Name = "skinsTab";
            this.skinsTab.Padding = new System.Windows.Forms.Padding(3);
            this.skinsTab.Size = new System.Drawing.Size(548, 372);
            this.skinsTab.TabIndex = 10;
            this.skinsTab.Text = "Skins";
            // 
            // otherTab
            // 
            this.otherTab.BackColor = System.Drawing.SystemColors.Control;
            this.otherTab.Controls.Add(this.undefinedCheckbox);
            this.otherTab.Controls.Add(this.customSearchBox);
            this.otherTab.Controls.Add(this.endoAmount);
            this.otherTab.Controls.Add(this.creditAmount);
            this.otherTab.Controls.Add(this.endoCheckbox);
            this.otherTab.Controls.Add(this.creditsCheckbox);
            this.otherTab.Location = new System.Drawing.Point(4, 22);
            this.otherTab.Name = "otherTab";
            this.otherTab.Padding = new System.Windows.Forms.Padding(3);
            this.otherTab.Size = new System.Drawing.Size(548, 372);
            this.otherTab.TabIndex = 7;
            this.otherTab.Text = "Other";
            // 
            // undefinedCheckbox
            // 
            this.undefinedCheckbox.Location = new System.Drawing.Point(375, 299);
            this.undefinedCheckbox.Name = "undefinedCheckbox";
            this.undefinedCheckbox.Size = new System.Drawing.Size(167, 17);
            this.undefinedCheckbox.TabIndex = 3;
            this.undefinedCheckbox.Text = "Undefined Items";
            this.undefinedCheckbox.ThreeState = true;
            this.toolTip1.SetToolTip(this.undefinedCheckbox, "Checked: Always Notify, Unchecked: Never notify, Dotted: Notify if mission is qui" +
        "ck and easy.");
            this.undefinedCheckbox.UseVisualStyleBackColor = true;
            this.undefinedCheckbox.CheckStateChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // customSearchBox
            // 
            this.customSearchBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.customSearchBox.Location = new System.Drawing.Point(6, 299);
            this.customSearchBox.Multiline = true;
            this.customSearchBox.Name = "customSearchBox";
            this.customSearchBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.customSearchBox.Size = new System.Drawing.Size(352, 67);
            this.customSearchBox.TabIndex = 2;
            this.customSearchBox.TextChanged += new System.EventHandler(this.SettingsChanged);
            this.customSearchBox.Enter += new System.EventHandler(this.Specifics_Enter);
            this.customSearchBox.Leave += new System.EventHandler(this.Specifics_Leave);
            // 
            // endoAmount
            // 
            this.endoAmount.Location = new System.Drawing.Point(479, 346);
            this.endoAmount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.endoAmount.Name = "endoAmount";
            this.endoAmount.Size = new System.Drawing.Size(63, 20);
            this.endoAmount.TabIndex = 1;
            this.endoAmount.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // creditAmount
            // 
            this.creditAmount.Location = new System.Drawing.Point(479, 322);
            this.creditAmount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.creditAmount.Name = "creditAmount";
            this.creditAmount.Size = new System.Drawing.Size(63, 20);
            this.creditAmount.TabIndex = 1;
            this.creditAmount.ValueChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // endoCheckbox
            // 
            this.endoCheckbox.Location = new System.Drawing.Point(375, 347);
            this.endoCheckbox.Name = "endoCheckbox";
            this.endoCheckbox.Size = new System.Drawing.Size(104, 17);
            this.endoCheckbox.TabIndex = 0;
            this.endoCheckbox.Text = "Endo: At Least";
            this.endoCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.endoCheckbox.ThreeState = true;
            this.toolTip1.SetToolTip(this.endoCheckbox, "Checked: Always Notify, Unchecked: Never notify, Dotted: Notify if mission is qui" +
        "ck and easy.");
            this.endoCheckbox.UseVisualStyleBackColor = true;
            this.endoCheckbox.CheckStateChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // creditsCheckbox
            // 
            this.creditsCheckbox.Location = new System.Drawing.Point(375, 323);
            this.creditsCheckbox.Name = "creditsCheckbox";
            this.creditsCheckbox.Size = new System.Drawing.Size(104, 17);
            this.creditsCheckbox.TabIndex = 0;
            this.creditsCheckbox.Text = "Credits: At Least";
            this.creditsCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.creditsCheckbox.ThreeState = true;
            this.toolTip1.SetToolTip(this.creditsCheckbox, "Checked: Always Notify, Unchecked: Never notify, Dotted: Notify if mission is qui" +
        "ck and easy.");
            this.creditsCheckbox.UseVisualStyleBackColor = true;
            this.creditsCheckbox.CheckStateChanged += new System.EventHandler(this.SettingsChanged);
            // 
            // checkUncheckDotStrip
            // 
            this.checkUncheckDotStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkStripItem,
            this.uncheckStripItem,
            this.dotStripItem});
            this.checkUncheckDotStrip.Name = "checkUncheckDotStrip";
            this.checkUncheckDotStrip.Size = new System.Drawing.Size(138, 70);
            // 
            // checkStripItem
            // 
            this.checkStripItem.Name = "checkStripItem";
            this.checkStripItem.Size = new System.Drawing.Size(137, 22);
            this.checkStripItem.Text = "Check All";
            this.checkStripItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CheckStripItem_MouseUp);
            // 
            // uncheckStripItem
            // 
            this.uncheckStripItem.Name = "uncheckStripItem";
            this.uncheckStripItem.Size = new System.Drawing.Size(137, 22);
            this.uncheckStripItem.Text = "Uncheck All";
            this.uncheckStripItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UncheckStripItem_MouseUp);
            // 
            // dotStripItem
            // 
            this.dotStripItem.Name = "dotStripItem";
            this.dotStripItem.Size = new System.Drawing.Size(137, 22);
            this.dotStripItem.Text = "Dot All";
            this.dotStripItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DotStripItem_MouseUp);
            // 
            // weeklyResetBox
            // 
            this.weeklyResetBox.AutoSize = true;
            this.weeklyResetBox.Checked = true;
            this.weeklyResetBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.weeklyResetBox.Location = new System.Drawing.Point(382, 211);
            this.weeklyResetBox.MinimumSize = new System.Drawing.Size(160, 17);
            this.weeklyResetBox.Name = "weeklyResetBox";
            this.weeklyResetBox.Size = new System.Drawing.Size(160, 17);
            this.weeklyResetBox.TabIndex = 21;
            this.weeklyResetBox.Text = "Weekly Reset Notification";
            this.weeklyResetBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.weeklyResetBox, "Notifies you when the weekly rewards reset for the week.");
            this.weeklyResetBox.UseVisualStyleBackColor = true;
            // 
            // weeklyTimerLabel
            // 
            this.weeklyTimerLabel.Location = new System.Drawing.Point(300, 210);
            this.weeklyTimerLabel.Name = "weeklyTimerLabel";
            this.weeklyTimerLabel.Size = new System.Drawing.Size(76, 17);
            this.weeklyTimerLabel.TabIndex = 22;
            this.weeklyTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // activeEvents
            // 
            this.activeEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.activeEvents.FormattingEnabled = true;
            this.activeEvents.Location = new System.Drawing.Point(0, 0);
            this.activeEvents.Name = "activeEvents";
            this.activeEvents.ScrollAlwaysVisible = true;
            this.activeEvents.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.activeEvents.Size = new System.Drawing.Size(548, 186);
            this.activeEvents.TabIndex = 0;
            // 
            // loggedEvents
            // 
            this.loggedEvents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.loggedEvents.FormattingEnabled = true;
            this.loggedEvents.Location = new System.Drawing.Point(0, 0);
            this.loggedEvents.Name = "loggedEvents";
            this.loggedEvents.ScrollAlwaysVisible = true;
            this.loggedEvents.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.loggedEvents.Size = new System.Drawing.Size(548, 339);
            this.loggedEvents.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(570, 411);
            this.Controls.Add(this.Overview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Vox Lotus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Overview.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            this.logTab.ResumeLayout(false);
            this.otherTab.ResumeLayout(false);
            this.otherTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endoAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditAmount)).EndInit();
            this.checkUncheckDotStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Overview;
        private System.Windows.Forms.TabPage mainTab;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.TabPage auraTab;
        private System.Windows.Forms.TabPage planetTab;
        private System.Windows.Forms.TabPage resourcesTab;
        private System.Windows.Forms.TabPage modTab;
        private System.Windows.Forms.TabPage blueprintTab;
        private System.Windows.Forms.TabPage otherTab;
        private System.Windows.Forms.CheckBox endoCheckbox;
        private System.Windows.Forms.CheckBox creditsCheckbox;
        private System.Windows.Forms.NumericUpDown endoAmount;
        private System.Windows.Forms.NumericUpDown creditAmount;
        private System.Windows.Forms.TabPage weaponsTab;
        private System.Windows.Forms.TextBox customSearchBox;
        private System.Windows.Forms.TabPage helmetsTab;
        private System.Windows.Forms.TabPage skinsTab;
        private System.Windows.Forms.CheckBox missionResetBox;
        private System.Windows.Forms.CheckBox dailyResetBox;
        private System.Windows.Forms.CheckBox cetusNightBox;
        private System.Windows.Forms.CheckBox cetusDayBox;
        private System.Windows.Forms.CheckBox earthNightBox;
        private System.Windows.Forms.CheckBox earthDayBox;
        private WarframeListBox activeEvents;
        public System.Windows.Forms.CheckBox distillingExtractorBox;
        public System.Windows.Forms.CheckBox titanExtractorBox;
        private System.Windows.Forms.CheckBox speakInGameBox;
        private System.Windows.Forms.CheckBox popupInGameBox;
        private System.Windows.Forms.CheckBox speakOutOfGameBox;
        private System.Windows.Forms.CheckBox popupOutOfGameBox;
        private WarframeListBox loggedEvents;
        private System.Windows.Forms.Button clearLogButton;
        private System.Windows.Forms.Label titanExtractorTimerLabel;
        private System.Windows.Forms.Label distillingExtractorTimerLabel;
        private System.Windows.Forms.Label earthNightTimerLabel;
        private System.Windows.Forms.Label earthDayTimerLabel;
        private System.Windows.Forms.Label cetusNightTimerLabel;
        private System.Windows.Forms.Label cetusDayTimerLabel;
        private System.Windows.Forms.Label missionTimerLabel;
        private System.Windows.Forms.Label dailyTimerLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox undefinedCheckbox;
        private System.Windows.Forms.ContextMenuStrip checkUncheckDotStrip;
        private System.Windows.Forms.ToolStripMenuItem checkStripItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckStripItem;
        private System.Windows.Forms.ToolStripMenuItem dotStripItem;
        private CheckBox weeklyResetBox;
        private Label weeklyTimerLabel;
    }
}

