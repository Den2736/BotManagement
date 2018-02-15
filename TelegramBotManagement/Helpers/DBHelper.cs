using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotManagement.Models;
using TelegramBotManagement.Models.Shemes;

namespace TelegramBotManagement.Helpers
{
    public static class DBHelper
    {
        private const string FileName = "database.db";

        /// <summary>
        /// SQLiteConnection has to be opened while you use selected data
        /// </summary>
        /// <returns></returns>
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(FileName);
        }

        public static SQLiteConnection GetConnection(string botName)
        {
            return new SQLiteConnection($"BotsContent/{botName}/{FileName}");
        }


        public static void CheckDB()
        {
            if (!File.Exists(FileName))
            {
                using (var db = GetConnection())
                {
                    db.CreateTable<Client>();
                    db.CreateTable<OurBot>();

                    //db.Insert(new Client()
                    //{
                    //    Id = 433094062,
                    //    Username = "Den2736",
                    //    FirstName = "Denis",
                    //    LastName = "Babenko"
                    //});

                    //db.Insert(new OurBot()
                    //{
                    //    Token = "457947516:AAFHOqCs0yU0jtWVNIch-YbaUWsAUU3nk84",
                    //    OwnerId = 433094062,
                    //    SchemeName = "Scheme1"
                    //});

                    //db.Insert(new OurBot()
                    //{
                    //    Token = "534255060:AAEanDcBLrlT6OAKAjbhNmtXkMISA_jfNXg",
                    //    OwnerId = 433094062,
                    //    SchemeName = "Register"
                    //});
                }
            }
            else
            {
                Migrate();
            }
        }

        public static void CheckDB(string botName)
        {
            if (!File.Exists($"BotsContent/{botName}/{FileName}"))
            {
                CreateBotDB(botName);
            }
            else
            {
                Migrate(botName);
            }
        }


        public static void Migrate()
        {
            using (var db = GetConnection())
            {
                db.CreateTable<Client>();
                db.CreateTable<OurBot>();
            }
        }

        public static void Migrate(string botName)
        {
            CreateBotDB(botName);
        }

        private static void CreateBotDB(string botName)
        {
            using (var db = GetConnection(botName))
            {
                db.CreateTable<BotUser>();
            }
        }


        public static Client GetBotOwner(OurBot ourBot)
        {
            using (var db = GetConnection())
            {
                return db.Find<Client>(ourBot.OwnerId);
            }
        }

        public static void UserPassedTheBlock(string botName, int id, Block block)
        {
            using (var db = GetConnection(botName))
            {
                var user = db.Find<BotUser>(id);
                switch (block)
                {
                    case Block.Lamagna: { user.LamagnaPassed = true; break; }
                    case Block.Trippier: { user.TrippierPassed = true; break; }
                    case Block.MainProduct: { user.MainProductPassed = true; break; }
                }
                db.Update(user);
            }
        }

        public static void AddUser(string botName, Telegram.Bot.Types.User telegramUser)
        {
            using (var db = GetConnection(botName))
            {
                if (db.Find<BotUser>(telegramUser.Id) == null)
                {
                    db.Insert(new BotUser()
                    {
                        Id = telegramUser.Id,
                        UserName = telegramUser.Username,
                        LastName = telegramUser.LastName,
                        FirstName = telegramUser.FirstName
                    });
                }
            }
        }

        public static bool IsClient(Telegram.Bot.Types.User user)
        {
            using (var db = GetConnection())
            {
                return db.Table<Client>().Any(c => c.Id == user.Id);
            }
        }
        public static bool IsClient(int userId)
        {
            using (var db = GetConnection())
            {
                return db.Table<Client>().Any(c => c.Id == userId);
            }
        }
    }
}
