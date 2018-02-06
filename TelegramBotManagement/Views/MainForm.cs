using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBotManagement.Models;

namespace TelegramBotManagement
{
    public partial class MainForm : Form
    {
        public event EventHandler OnLaunchButtonClick;
        public event EventHandler OnRegisterButtonClick;
        public event EventHandler OnClientsButtonClick;

        public MainForm()
        {
            InitializeComponent();
        }

        public void AddBot(string botName, string owner, string status)
        {
            var item = new ListViewItem((BotList.Items.Count + 1).ToString());

            item.SubItems.Add(botName);
            item.SubItems.Add(owner);
            item.SubItems.Add(status);
            BotList.Items.Add(item);
            var contextMenu = new List<MenuItem>()
            {
                new MenuItem("click here", LaunchButton_Click)
            };

            BotList.ContextMenu = new ContextMenu(contextMenu.ToArray());
        }

        public void SetNeutralStatus(string message)
        {
            StatusLabel.ForeColor = Color.Black;
            StatusLabel.Text = message;
        }
        public void SetSuccessStatus(string message)
        {
            StatusLabel.ForeColor = Color.Green;
            StatusLabel.Text = message;
        }
        public void SetDangerStatus(string message)
        {
            StatusLabel.ForeColor = Color.Red;
            StatusLabel.Text = message;
        }
        public void ShowProgress(int progress, string status="")
        {
            BackgroundWorker.ReportProgress(progress);
            lblStatus.Visible = true;
            lblStatus.Text = status;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            OnRegisterButtonClick?.Invoke(this, null);
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            ProgressBar.Visible = true;
            ProgressBar.Value = 0;

            if (!BackgroundWorker.IsBusy)
            {
                BackgroundWorker_DoWork(this, null);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            OnLaunchButtonClick?.Invoke(this, null);
        }
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void btnClients_Click(object sender, EventArgs e)
        {

        }
    }
}
