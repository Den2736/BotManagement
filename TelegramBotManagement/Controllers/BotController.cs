using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotManagement.Helpers;
using TelegramBotManagement.Models;

namespace TelegramBotManagement.Controllers
{
    public static class BotController
    {
        public static void Init()
        {
            MainController.OnLaunchButtonClick += OnLaunchButtonClick;
            MainController.OnRegisterButtonClick += OnRegisterButtonClick;
        }

        private static void OnRegisterButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnLaunchButtonClick(object sender, EventArgs e)
        {
            foreach (var bot in GetBots())
            {
                MainController.ShowBot(bot);
            }
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
