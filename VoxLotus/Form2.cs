using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VoxLotus
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            versionText.Text = Application.ProductVersion;
        }

        private void OpenURL(string url)
        {
            Process.Start(url);
        }

        private void readmeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Arsonide/VoxLotus/blob/master/README.md");
        }

        private void releasesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Arsonide/VoxLotus/releases");
        }

        private void wikiLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Arsonide/VoxLotus/wiki");
        }

        private void suggestionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Arsonide/VoxLotus/issues");
        }

        private void bugLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Arsonide/VoxLotus/issues");
        }

        private void licenseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://raw.githubusercontent.com/Arsonide/VoxLotus/master/LICENSE");
        }

        private void sourceLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/Arsonide/VoxLotus");
        }

        private void closeAboutButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
