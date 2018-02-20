using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotManagement.Helpers;
using TelegramBotManagement.Models;
using TelegramBotManagement.Models.EventArgs;
using TelegramBotManagement.Models.Shemes;
using TelegramBotManagement.Views;

namespace TelegramBotManagement.Controllers
{
    public static class BotController
    {
        private static Dictionary<TelegramBotClient, OurBot> Bots { get; set; } = new Dictionary<TelegramBotClient, OurBot>();
        public static event EventHandler<BotLaunchedArgs> BotLaunched;
        public static event EventHandler<BotStoppedArgs> BotStopped;
        public static event EventHandler<BotCheckedArgs> BotChecked;

        public static void Init()
        {
            MainController.OnLaunchAllButtonClick += OnLaunchAll; ;
            MainController.OnStopAllButtonClick += StopAllButton; ;
            MainController.OnLaunchContextMenuItemClick += LaunchSeveralBots;
            MainController.OnStopContextMenuItemClick += StopSeveralBots; ;
            CheckBots();
        }

        public static void RegisterNewBot(string token, int ownerId, string schemeName)
        {
            var bot = new OurBot()
            {
                TBot = new TelegramBotClient(token),
                Token = token,
                OwnerId = ownerId,
                SchemeName = schemeName
            };
            bot.Owner = DBHelper.GetBotOwner(bot);
            SchemeBase.GetShemeFor(bot);  // initialize scheme and store texts
            using (var db = DBHelper.GetConnection())
            {
                db.Insert(bot);
            }
            LaunchBot(bot);
            BotLaunched?.Invoke(null, new BotLaunchedArgs(bot));
        }

        private static void CheckBots()
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
                BotChecked?.Invoke(null, new BotCheckedArgs(ourBot, (double)count / total * 100));
            }
        }
        private static void LaunchBots(IEnumerable<OurBot> ourBots)
        {
            int total = ourBots.Count();
            int count = 0;

            foreach (var bot in ourBots)
            {
                LaunchBot(bot);
                count++;
                BotLaunched?.Invoke(null, new BotLaunchedArgs(bot, (double)count / total * 100));
            }
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
            if (!Bots.ContainsKey(ourBot.TBot))
            {
                Bots.Add(ourBot.TBot, ourBot);
            }
            else
            {
                Bots[ourBot.TBot] = ourBot;
            }
        }
        private static void StopBots(IEnumerable<string> tokens=null)
        {
            int total = Bots.Count();
            int count = 0;

            foreach (var tBot in Bots.Keys)
            {
                tBot.StopReceiving();
                Bots[tBot].Status = BotStatus.Offline;

                count++;
                BotStopped?.Invoke(null, new BotStoppedArgs(Bots[tBot], (double)count / total * 100));
            }
        }

        private static void OnLaunchAll(object sender, EventArgs e)
        {
            LaunchBots(GetBots());
        }
        private static void StopAllButton(object sender, EventArgs e)
        {
            StopBots();
        }
        private static void LaunchSeveralBots(object sender, LaunchSeveralBotsArgs e)
        {
            LaunchBots(GetBots(e.BotsTokens));
        }
        private static void StopSeveralBots(object sender, StopSeveralBotsArgs e)
        {
            StopBots(e.BotsTokens);
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

        private static IEnumerable<OurBot> GetBots(IEnumerable<string> tokens = null)
        {
            var bots = new List<OurBot>();
            using (var db = DBHelper.GetConnection())
            {
                bots = tokens != null? db.Table<OurBot>().Where(b => tokens.Contains(b.Token)).ToList() : db.Table<OurBot>().ToList();
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

        public static bool IsOwner(int userId, TelegramBotClient tBot)
        {
            var ourBot = Bots[tBot];
            return ourBot.OwnerId == userId;
        }
    }
}
