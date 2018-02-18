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
        public static event EventHandler<BotLaunchedArgs> BotLaunched;
        public static event EventHandler<BotStoppedArgs> BotStopped;
        public static event EventHandler<BotCheckedArgs> BotChecked;

        public static void Init()
        {
            Form = new MainForm();
            Form.OnLaunchAllButtonClick += Form_OnLaunchButtonClick;
            Form.OnClientsButtonClick += Form_OnClientsButtonClick;
            Form.OnStopAllButtonClick += Form_OnStopAllButtonClick;
            Form.Show();

            DBHelper.CheckDB();

            BotController.BotLaunched += BotController_BotLaunched;
            BotController.BotStopped += BotController_BotStopped;
            BotController.BotChecked += BotController_BotChecked;
            BotController.Init();

            ClientController.Init();

            Form.Hide();
            Form.ShowDialog();
        }

        private static void BotController_BotChecked(object sender, BotCheckedArgs e)
        {
            BotChecked?.Invoke(sender, e);
        }
        private static void BotController_BotStopped(object sender, BotStoppedArgs e)
        {
            BotStopped?.Invoke(sender, e);
        }
        private static void BotController_BotLaunched(object sender, BotLaunchedArgs e)
        {
            BotLaunched?.Invoke(sender, e);
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

        public static void UpdateBotInfo (OurBot bot)
        {
            Form.AddOrUpdateBotInfo(bot);
        }

        private static void Form_OnStopAllButtonClick(object sender, EventArgs e)
        {
            OnStopAllButtonClick?.Invoke(sender, null);
        }
        private static void Form_OnLaunchButtonClick(object sender, EventArgs e)
        {
            OnLaunchAllButtonClick?.Invoke(sender, null);
        }
        private static void Form_OnClientsButtonClick(object sender, EventArgs e)
        {
            OnClientsButtonClick?.Invoke(sender, null);
        }
    }
}
