using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.EventArgs
{
    public class BotLaunchedArgs: System.EventArgs
    {
        public BotLaunchedArgs() { }

        public BotLaunchedArgs(OurBot bot, double? persentage = null)
        {
            Bot = bot;
            Persentage = persentage;
        }

        public OurBot Bot { get; set; }
        public double? Persentage { get; set; }
    }
}
