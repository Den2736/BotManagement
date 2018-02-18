using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.EventArgs
{
    public class BotStoppedArgs : BotLaunchedArgs
    {
        public BotStoppedArgs(OurBot bot, double? persentage = null) : base(bot, persentage) { }
    }
}
