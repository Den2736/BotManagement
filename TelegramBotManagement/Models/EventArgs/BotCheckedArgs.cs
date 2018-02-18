using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.EventArgs
{
    public class BotCheckedArgs : BotLaunchedArgs
    {
        public BotCheckedArgs(OurBot bot, double? persentage = null) : base(bot, persentage) { }
    }
}
