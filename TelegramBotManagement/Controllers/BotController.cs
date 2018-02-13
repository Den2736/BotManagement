using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotManagement.Helpers;
using TelegramBotManagement.Models;
using TelegramBotManagement.Models.Shemes;
using TelegramBotManagement.Views;

namespace TelegramBotManagement.Controllers
{
    public static class BotController
    {
        private static Dictionary<TelegramBotClient, OurBot> Bots { get; set; }

        public static void Init()
        {
            MainController.OnLaunchAllButtonClick += LaunchBots;
            MainController.OnStopAllButtonClick += StopBots;
            PrepareBots();
        }

        private static void LaunchBots(object sender, EventArgs e)
        {
            Bots = new Dictionary<TelegramBotClient, OurBot>();
            var ourBots = GetBots();

            int total = ourBots.Count();
            int count = 0;

            foreach (var bot in ourBots)
            {
                LaunchBot(bot);
                MainController.UpdateBotInfo(bot);
                count++;
                MainController.ReportProgress(count / total * 100, "Активация ботов");
            }
            MainController.ShowBots(ourBots);
            MainController.ReportProgress(0, "Активация ботов завершена");
        }
        private static void LaunchBot(OurBot ourBot)
        {
            try
            {
                ourBot.TBot = new TelegramBotClient(ourBot.Token);
                ourBot.Status = BotStatus.Offline;
            }
            catch (ArgumentException)
            {
                ourBot.Status = BotStatus.NotFound;
                return;
            }

            DBHelper.CheckDB(ourBot.TBot.GetMeAsync().Result.Username);
            ourBot.Scheme = SchemeBase.GetShemeFor(ourBot);
            ourBot.TBot.OnCallbackQuery += TBot_OnCallbackQuery;
            ourBot.TBot.OnMessage += TBot_OnMessage;
            ourBot.TBot.StartReceiving();
            ourBot.Status = BotStatus.Online;
            Bots.Add(ourBot.TBot, ourBot);
        }

        private static void StopBots(object sender, EventArgs e)
        {
            int total = Bots.Count();
            int count = 0;

            foreach (var tBot in Bots.Keys)
            {
                tBot.StopReceiving();
                Bots[tBot].Status = BotStatus.Offline;

                count++;
                MainController.ReportProgress(count / total * 100, "Деактивация ботов");
            }
            MainController.ShowBots(Bots.Values);
            MainController.ReportProgress(0, "Деактивация ботов завершена");
        }

        private static void RegisterNewBot(string token, int ownerId, ISheme sheme)
        {

        }

        private static void TBot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var tBot = sender as TelegramBotClient;
            var ourBot = Bots[tBot];
            var message = e.Message;
            if (message.Type == Telegram.Bot.Types.Enums.MessageType.TextMessage && message.Text == "/start")
            {
                DBHelper.AddUser(tBot.GetMeAsync().Result.Username, message.From);
                ourBot.Scheme.Start(e);
            }
            else
            {
                ourBot.Scheme.Next(e);
            }
        }
        private static void TBot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            var tBot = sender as TelegramBotClient;
            var ourBot = Bots[tBot];
            ourBot.Scheme.Next(e);
        }

        private static void PrepareBots()
        {
            var ourBots = GetBots();
            int count = 0;
            int total = ourBots.Count();
            foreach (var ourBot in ourBots)
            {
                try
                {
                    var telegramBot = new TelegramBotClient(ourBot.Token);
                    ourBot.TBot = telegramBot;
                    ourBot.Status = BotStatus.Offline;
                }
                catch (ArgumentException)
                {
                    ourBot.Status = BotStatus.NotFound;
                }
                count++;
                MainController.ReportProgress(count / total * 100, "Проверка ботов");
            }
            MainController.ShowBots(ourBots);
            MainController.ReportProgress(100, "Готово");
        }
        private static IEnumerable<OurBot> GetBots()
        {
            var bots = new List<OurBot>();
            using (var db = DBHelper.GetConnection())
            {
                bots = db.Table<OurBot>().ToList();
                foreach (var bot in bots)
                {
                    bot.Owner = db.Find<Client>(bot.OwnerId);
                }
            }
            return bots;
        }

        private static void OnStopAllButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private static void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainController.ReportProgress(e.ProgressPercentage, e.UserState as string);
        }

        public static bool IsOwner(int userId, TelegramBotClient tBot)
        {
            var ourBot = Bots[tBot];
            return ourBot.OwnerId == userId;
        }
    }
}
