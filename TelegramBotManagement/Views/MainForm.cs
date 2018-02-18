using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBotManagement.Controllers;
using TelegramBotManagement.Models;
using TelegramBotManagement.Models.EventArgs;

namespace TelegramBotManagement
{
    public partial class MainForm : Form
    {
        public event EventHandler OnLaunchAllButtonClick;
        public event EventHandler OnStopAllButtonClick;
        public event EventHandler OnClientsButtonClick;

        private delegate void ShowLaunchInfoDelegate(BotLaunchedArgs e);
        private delegate void ShowCheckInfoDelegate(BotCheckedArgs e);
        private delegate void ShowStopInfoDelegate(BotStoppedArgs e);

        public MainForm()
        {
            InitializeComponent();
            MainController.BotLaunched += MainController_BotLaunched;
            MainController.BotStopped += MainController_BotStopped;
            MainController.BotChecked += MainController_BotChecked;
        }

        private void MainController_BotChecked(object sender, BotCheckedArgs e)
        {
            Invoke(new ShowCheckInfoDelegate(ShowCheckInfo), new object[] { e });
        }
        private void MainController_BotStopped(object sender, BotStoppedArgs e)
        {
            Invoke(new ShowStopInfoDelegate(ShowStopInfo), new object[] { e });
        }
        private void MainController_BotLaunched(object sender, BotLaunchedArgs e)
        {
            Invoke(new ShowLaunchInfoDelegate(ShowLaunchInfo), new object[] { e });
        }

        private void ShowLaunchInfo(BotLaunchedArgs e)
        {
            AddOrUpdateBotInfo(e.Bot);
            string status = e.Persentage == null || e.Persentage == 100 ? "Бот(ы) запущен(ы)" : "Запуск ботов...";
            ShowProgress(e.Persentage ?? 100, status);
        }
        private void ShowCheckInfo(BotLaunchedArgs e)
        {
            AddOrUpdateBotInfo(e.Bot);
            string status = e.Persentage == null || e.Persentage == 100 ? "Бот(ы) проверен(ы)" : "Проверка ботов...";
            ShowProgress(e.Persentage ?? 100, status);
        }
        private void ShowStopInfo(BotLaunchedArgs e)
        {
            AddOrUpdateBotInfo(e.Bot);
            string status = e.Persentage == null || e.Persentage == 100 ? "Бот(ы) деактивирован(ы)" : "Деактивация ботов...";
            ShowProgress(e.Persentage ?? 100, status);
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
        public void ShowProgress(double progress, string status = "")
        {
            ProgressBar.Value = (int)progress;
            SetNeutralStatus(status);
        }

        public void AddOrUpdateBotInfo(OurBot bot)
        {
            var telegramBot = bot.TBot.GetMeAsync().Result;
            var item = BotList.FindItemWithText(telegramBot.Username);
            if (item != null)
            {
                var newItem = GetItemFor(bot);
                newItem.Text = item.Text;
                BotList.Items[item.Index] = newItem;
            }
            else
            {
                BotList.Items.Add(GetItemFor(bot));
            }
        }
        private ListViewItem GetItemFor(OurBot bot)
        {
            var item = new ListViewItem((BotList.Items.Count + 1).ToString());
            var telegramBot = bot.TBot.GetMeAsync().Result;
            item.SubItems.Add(telegramBot.Username);
            item.SubItems.Add($"{bot.Owner.Username} ({bot.Owner.FirstName} {bot.Owner.LastName})");
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