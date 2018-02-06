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
        }

        private static void OnLaunchButtonClick(object sender, EventArgs e)
        {
            var bots = GetBots();
            int count = 0;
            int total = bots.Count();

            foreach (var bot in bots)
            {
                total = GetBots().Count();
                MainController.ShowBot(bot);
                count++;
                MainController.ReportProgress(count / total * 100, "Запуск ботов.");
            }
            MainController.ReportProgress(100, "Запуск ботов завершён.");
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
