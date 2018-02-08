using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotManagement.Models;

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

        public static void CheckDB()
        {
            if (!File.Exists(FileName))
            {
                using (var db = GetConnection())
                {
                    db.CreateTable<Client>();
                    db.CreateTable<OurBot>();

                    db.Insert(new Client()
                    {
                        Id = 433094062,
                        Username = "Den2736",
                        FirstName = "Denis",
                        LastName = "Babenko"
                    });

                    db.Insert(new OurBot()
                    {
                        Token = "457947516:AAFHOqCs0yU0jtWVNIch-YbaUWsAUU3nk84",
                        OwnerId = 433094062,
                        SchemeName = "Scheme1"
                    });
                }
            }
            else
            {
                Migrate();
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

        public static Client GetBotOwner(OurBot ourBot)
        {
            using (var db = GetConnection())
            {
                return db.Find<Client>(ourBot.OwnerId);
            }
        }
    }
}
