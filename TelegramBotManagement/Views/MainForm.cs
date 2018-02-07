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
        public event EventHandler OnClientsButtonClick;

        public MainForm()
        {
            InitializeComponent();
        }

        public void ShowBots(IEnumerable<OurBot> bots)
        {
            BotList.Items.Clear();
            foreach (var bot in bots)
            {
                var item = new ListViewItem((BotList.Items.Count + 1).ToString());
                var telegramBot = bot.Bot.GetMeAsync().Result;
                item.SubItems.Add(telegramBot.Username);
                item.SubItems.Add(bot.Owner.Username);
                item.SubItems.Add(bot.Status.ToString());

                item.SubItems[3].ForeColor =
                    bot.Status == Models.BotStatus.NotFound ? Color.Red
                    : bot.Status == Models.BotStatus.Online ? Color.Green : Color.Black;

                BotList.Items.Add(item);
            }
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
            OnClientsButtonClick?.Invoke(this, null);
        }

        private void LaunchAllButton_Click(object sender, EventArgs e)
        {
            if (!BackgroundWorker.IsBusy)
            {
                BackgroundWorker_DoWork(null, null);
            }
        }
    }
}