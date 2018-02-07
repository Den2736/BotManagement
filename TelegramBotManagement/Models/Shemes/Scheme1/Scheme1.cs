using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBotManagement.Models.Shemes
{
    public class Scheme1 : ShemeBase
    {
        public override TelegramBotClient TBot { get; set; }

        public Text1.Texts Texts { get; set; }

        public override void Next(CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Next(MessageEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
