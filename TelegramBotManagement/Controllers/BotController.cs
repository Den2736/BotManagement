using System;
using System.Collections.Generic;
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
            MainController.OnLaunchButtonClick += OnLaunchButtonClick;
            PrepareBots();
        }

        private static void OnLaunchButtonClick(object sender, EventArgs e)
        {
            Bots = new Dictionary<TelegramBotClient, OurBot>();
            var ourBots = GetBots();
            foreach (var bot in ourBots)
            {
                LaunchBot(bot);
            }
            MainController.ShowBots(ourBots);
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

            ourBot.Sheme = SchemeBase.GetShemeFor(ourBot);
            ourBot.TBot.OnCallbackQuery += Bot_OnCallbackQuery;
            ourBot.TBot.OnMessage += TBot_OnMessage;
            ourBot.TBot.StartReceiving();
            ourBot.Status = BotStatus.Online;
            Bots.Add(ourBot.TBot, ourBot);
        }

        private static void TBot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var tBot = sender as TelegramBotClient;
            var ourBot = Bots[tBot];
            ourBot.Sheme.Next(e);
        }

        private static void Bot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            var tBot = sender as TelegramBotClient;
            var ourBot = Bots[tBot];
            ourBot.Sheme.Next(e);
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
    }
}
