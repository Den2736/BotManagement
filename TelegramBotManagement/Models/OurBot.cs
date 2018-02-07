using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models
{
    public class OurBot
    {
        [PrimaryKey, Unique] public string Token { get; set; }

        public int? OwnerId { get; set; }
        [Ignore] public Client Owner { get; set; } 

        [Ignore] public Telegram.Bot.TelegramBotClient Bot { get; set; }

        [Ignore] public BotStatus Status { get; set; }
    }
}
