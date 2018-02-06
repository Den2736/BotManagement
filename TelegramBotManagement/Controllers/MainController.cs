using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotManagement.Helpers;
using Telegram.Bot;
using TelegramBotManagement.Models;

namespace TelegramBotManagement.Controllers
{
    public static class MainController
    {
        private static MainForm Form = new MainForm();
        public static event EventHandler OnLaunchButtonClick;
        public static event EventHandler OnRegisterButtonClick;

        public static void Init()
        {
            BotController.Init();
            Form.OnLaunchButtonClick += Form_OnLaunchButtonClick;
            Form.OnRegisterButtonClick += Form_OnRegisterButtonClick;
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

        public static void ShowBot(OurBot bot)
        {
            var telegramBot = new TelegramBotClient(bot.Token);
            string botName = telegramBot.GetMeAsync().Result.Username;
            Form.AddBot(botName, "somebody", "statusss");
        }

        private static void Form_OnLaunchButtonClick(object sender, EventArgs e)
        {
            OnLaunchButtonClick?.Invoke(sender, null);
        }

        private static void Form_OnRegisterButtonClick(object sender, EventArgs e)
        {
            OnRegisterButtonClick?.Invoke(sender, null);
        }
    }
}
