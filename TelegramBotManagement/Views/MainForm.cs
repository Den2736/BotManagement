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
        public event EventHandler OnLaunchAllButtonClick;
        public event EventHandler OnStopAllButtonClick;
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
                BotList.Items.Add(GetItemFor(bot));
            }
        }
        public void UpdateBotInfo(OurBot bot)
        {
            var telegramBot = bot.TBot.GetMeAsync().Result;
            var item = BotList.FindItemWithText(telegramBot.Username);
            var newItem = GetItemFor(bot);
            BotList.Items[item.Index] = newItem;
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
        public void ShowProgress(int progress, string status = "")
        {
            ProgressBar.Value = progress;
            ProgressBar.ToolTipText = status;
            StatusLabel.Text = status;
        }

        private ListViewItem GetItemFor(OurBot bot)
        {
            var item = new ListViewItem((BotList.Items.Count + 1).ToString());
            var telegramBot = bot.TBot.GetMeAsync().Result;
            item.SubItems.Add(telegramBot.Username);
            item.SubItems.Add(bot.Owner.Username);
            item.SubItems.Add(bot.Status.ToString());

            item.SubItems[3].ForeColor =
                bot.Status == Models.BotStatus.NotFound ? Color.Red
                : bot.Status == Models.BotStatus.Online ? Color.Red : Color.Black;

            return item;
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            OnClientsButtonClick?.Invoke(this, null);
        }
        private void LaunchAllButton_Click(object sender, EventArgs e)
        {
            OnLaunchAllButtonClick?.Invoke(sender, null);
        }
        private void StopAllButton_Click(object sender, EventArgs e)
        {
            OnStopAllButtonClick?.Invoke(sender, null);
        }
    }
}