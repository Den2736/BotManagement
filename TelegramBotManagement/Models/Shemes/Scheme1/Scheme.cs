using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBotManagement.Models.Shemes.Scheme1
{
    public class Scheme : SchemeBase
    {
        public Scheme(TelegramBotClient tBot)
        {
            TBot = tBot;
            Texts = new Text1.Texts($"BotsContent/{TBot.GetMeAsync().Result.Username}/Texts.xml");
            Keyboards = new Keyboards(Texts);
        }

        public Text1.Texts Texts { get; set; }
        public Keyboards Keyboards{ get; set; }

        public async override void Next(CallbackQueryEventArgs e)
        {
            await TBot.SendTextMessageAsync(e.CallbackQuery.From.Id, "CallbackQuery asnwer");
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }

        public async override void Next(MessageEventArgs e)
        {
            await TBot.SendTextMessageAsync(e.Message.From.Id, "Message asnwer");
        }
    }
}
