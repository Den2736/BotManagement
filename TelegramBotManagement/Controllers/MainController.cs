using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotManagement.Helpers;
using Telegram.Bot;
using TelegramBotManagement.Models;
using TelegramBotManagement.Views;

namespace TelegramBotManagement.Controllers
{
    public static class MainController
    {
        private static MainForm Form = new MainForm();
        private static RegisterBotForm registerForm;

        public static event EventHandler OnLaunchButtonClick;
        public static event EventHandler OnRegisterButtonClick;
        public static event EventHandler OnClientsButtonClick;

        public static void Init()
        {
            BotController.Init();
            Form.OnLaunchButtonClick += Form_OnLaunchButtonClick;
            Form.OnRegisterButtonClick += Form_OnRegisterButtonClick;
            Form.OnClientsButtonClick += Form_OnClientsButtonClick;
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

        public static void ReportProgress(int progress, string status = "")
        {
            Form.ShowProgress(progress, status);
        }

        private static void Form_OnLaunchButtonClick(object sender, EventArgs e)
        {
            OnLaunchButtonClick?.Invoke(sender, null);
        }

        private static void Form_OnRegisterButtonClick(object sender, EventArgs e)
        {
            registerForm = new RegisterBotForm();
            registerForm.ShowDialog();
        }

        private static void Form_OnClientsButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
