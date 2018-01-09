namespace VoxLotus
{
    partial class Form2
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
            this.readmeLink = new System.Windows.Forms.LinkLabel();
            this.closeAboutButton = new System.Windows.Forms.Button();
            this.wikiLink = new System.Windows.Forms.LinkLabel();
            this.bugLink = new System.Windows.Forms.LinkLabel();
            this.suggestionLink = new System.Windows.Forms.LinkLabel();
            this.releasesLink = new System.Windows.Forms.LinkLabel();
            this.licenseLink = new System.Windows.Forms.LinkLabel();
            this.sourceLink = new System.Windows.Forms.LinkLabel();
            this.versionText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // readmeLink
            // 
            this.readmeLink.Location = new System.Drawing.Point(12, 22);
            this.readmeLink.Name = "readmeLink";
            this.readmeLink.Size = new System.Drawing.Size(255, 13);
            this.readmeLink.TabIndex = 0;
            this.readmeLink.TabStop = true;
            this.readmeLink.Text = "Readme";
            this.readmeLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.readmeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.readmeLink_LinkClicked);
            // 
            // closeAboutButton
            // 
            this.closeAboutButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeAboutButton.Location = new System.Drawing.Point(102, 130);
            this.closeAboutButton.Name = "closeAboutButton";
            this.closeAboutButton.Size = new System.Drawing.Size(75, 23);
            this.closeAboutButton.TabIndex = 1;
            this.closeAboutButton.Text = "OK";
            this.closeAboutButton.UseVisualStyleBackColor = true;
            this.closeAboutButton.Click += new System.EventHandler(this.closeAboutButton_Click);
            // 
            // wikiLink
            // 
            this.wikiLink.Location = new System.Drawing.Point(12, 48);
            this.wikiLink.Name = "wikiLink";
            this.wikiLink.Size = new System.Drawing.Size(255, 13);
            this.wikiLink.TabIndex = 2;
            this.wikiLink.TabStop = true;
            this.wikiLink.Text = "Wiki";
            this.wikiLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wikiLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.wikiLink_LinkClicked);
            // 
            // bugLink
            // 
            this.bugLink.Location = new System.Drawing.Point(12, 74);
            this.bugLink.Name = "bugLink";
            this.bugLink.Size = new System.Drawing.Size(255, 13);
            this.bugLink.TabIndex = 3;
            this.bugLink.TabStop = true;
            this.bugLink.Text = "Bugs";
            this.bugLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bugLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bugLink_LinkClicked);
            // 
            // suggestionLink
            // 
            this.suggestionLink.Location = new System.Drawing.Point(12, 61);
            this.suggestionLink.Name = "suggestionLink";
            this.suggestionLink.Size = new System.Drawing.Size(255, 13);
            this.suggestionLink.TabIndex = 4;
            this.suggestionLink.TabStop = true;
            this.suggestionLink.Text = "Feedback";
            this.suggestionLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.suggestionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.suggestionLink_LinkClicked);
            // 
            // releasesLink
            // 
            this.releasesLink.Location = new System.Drawing.Point(12, 35);
            this.releasesLink.Name = "releasesLink";
            this.releasesLink.Size = new System.Drawing.Size(255, 13);
            this.releasesLink.TabIndex = 5;
            this.releasesLink.TabStop = true;
            this.releasesLink.Text = "Updates";
            this.releasesLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.releasesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.releasesLink_LinkClicked);
            // 
            // licenseLink
            // 
            this.licenseLink.Location = new System.Drawing.Point(12, 87);
            this.licenseLink.Name = "licenseLink";
            this.licenseLink.Size = new System.Drawing.Size(255, 13);
            this.licenseLink.TabIndex = 6;
            this.licenseLink.TabStop = true;
            this.licenseLink.Text = "Licenses";
            this.licenseLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.licenseLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.licenseLink_LinkClicked);
            // 
            // sourceLink
            // 
            this.sourceLink.Location = new System.Drawing.Point(12, 100);
            this.sourceLink.Name = "sourceLink";
            this.sourceLink.Size = new System.Drawing.Size(255, 13);
            this.sourceLink.TabIndex = 7;
            this.sourceLink.TabStop = true;
            this.sourceLink.Text = "Source";
            this.sourceLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sourceLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.sourceLink_LinkClicked);
            // 
            // versionText
            // 
            this.versionText.Location = new System.Drawing.Point(12, 9);
            this.versionText.Name = "versionText";
            this.versionText.Size = new System.Drawing.Size(255, 13);
            this.versionText.TabIndex = 8;
            this.versionText.Text = "Version";
            this.versionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.AcceptButton = this.closeAboutButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeAboutButton;
            this.ClientSize = new System.Drawing.Size(279, 165);
            this.Controls.Add(this.versionText);
            this.Controls.Add(this.sourceLink);
            this.Controls.Add(this.licenseLink);
            this.Controls.Add(this.releasesLink);
            this.Controls.Add(this.suggestionLink);
            this.Controls.Add(this.bugLink);
            this.Controls.Add(this.wikiLink);
            this.Controls.Add(this.closeAboutButton);
            this.Controls.Add(this.readmeLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About Vox Lotus";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel readmeLink;
        private System.Windows.Forms.Button closeAboutButton;
        private System.Windows.Forms.LinkLabel wikiLink;
        private System.Windows.Forms.LinkLabel bugLink;
        private System.Windows.Forms.LinkLabel suggestionLink;
        private System.Windows.Forms.LinkLabel releasesLink;
        private System.Windows.Forms.LinkLabel licenseLink;
        private System.Windows.Forms.LinkLabel sourceLink;
        private System.Windows.Forms.Label versionText;
    }
}