using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotManagement.Helpers;
using Telegram.Bot;
using TelegramBotManagement.Models;
using TelegramBotManagement.Views;
using TelegramBotManagement.Models.EventArgs;

namespace TelegramBotManagement.Controllers
{
    public static class MainController
    {
        private static MainForm Form;

        public static event EventHandler OnLaunchAllButtonClick;
        public static event EventHandler OnStopAllButtonClick;
        public static event EventHandler OnClientsButtonClick;
        public static event EventHandler<LaunchSeveralBotsArgs> OnLaunchContextMenuItemClick;
        public static event EventHandler<StopSeveralBotsArgs> OnStopContextMenuItemClick;
        public static event EventHandler<BotLaunchedArgs> BotLaunched;
        public static event EventHandler<BotStoppedArgs> BotStopped;
        public static event EventHandler<BotCheckedArgs> BotChecked;

        public static void Init()
        {
            Form = new MainForm();
            Form.OnLaunchAllButtonClick += delegate(object sender, EventArgs e) { OnLaunchAllButtonClick?.Invoke(sender, null); };
            Form.OnClientsButtonClick += delegate(object sender, EventArgs e) { OnClientsButtonClick?.Invoke(sender, null); };
            Form.OnStopAllButtonClick += delegate(object sender, EventArgs e) { OnStopAllButtonClick?.Invoke(sender, null); };
            Form.OnLaunchContextMenuItemClick += delegate (object sender, LaunchSeveralBotsArgs e) { OnLaunchContextMenuItemClick?.Invoke(sender, e); };
            Form.OnStopContextMenuItemClick += delegate (object sender, StopSeveralBotsArgs e) { OnStopContextMenuItemClick?.Invoke(sender, e); };
            Form.Show();

            DBHelper.CheckDB();

            BotController.BotLaunched += delegate(object sender, BotLaunchedArgs e) { BotLaunched?.Invoke(sender, e); };
            BotController.BotStopped += delegate(object sender, BotStoppedArgs e) { BotStopped?.Invoke(sender, e); };
            BotController.BotChecked += delegate(object sender, BotCheckedArgs e) { BotChecked?.Invoke(sender, e); };
            BotController.Init();

            ClientController.Init();

            Form.Hide();
            Form.ShowDialog();
        }

        public static void SetNeutralStatus(string message)
        {
            Form.SetNeutralStatus(message);
        }
        public static void SetSuccessStatus(string message)
        {
            Form.SetSuccessStatus(message);
        }
        public static void SetDangerStatus(string message)
        {
            Form.SetDangerStatus(message);
        }

        public static void UpdateBotInfo(OurBot bot)
        {
            Form.AddOrUpdateBotInfo(bot);
        }
    }
}
