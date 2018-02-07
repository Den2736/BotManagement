using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotManagement.Helpers;
using TelegramBotManagement.Models;
using TelegramBotManagement.Views;

namespace TelegramBotManagement.Controllers
{
    public static class BotController
    {
        public static void Init()
        {
            MainController.OnLaunchButtonClick += OnLaunchButtonClick;
            PrepareBots();
        }

        private static void OnLaunchButtonClick(object sender, EventArgs e)
        {
           
        }

        private static void LaunchBot(OurBot ourBot)
        {

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
                    ourBot.Bot = telegramBot;
                    ourBot.Owner = DBHelper.GetBotOwner(ourBot);
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
            }
            return bots;
        }
    }
}
