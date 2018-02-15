using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotManagement.Models.Shemes;

namespace TelegramBotManagement.Models
{
    public class OurBot
    {
        // Stored data
        [PrimaryKey, Unique] public string Token { get; set; }
        public int? OwnerId { get; set; }
        public string SchemeName { get; set; }

        [Ignore] public Client Owner { get; set; }
        [Ignore] public IScheme Scheme { get; set; }
        [Ignore] public Telegram.Bot.TelegramBotClient TBot { get; set; }
        [Ignore] public BotStatus Status { get; set; }
    }
}
