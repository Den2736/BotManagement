using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot;

namespace TelegramBotManagement.Models.Shemes
{
    public interface IScheme
    {
        void Next(CallbackQueryEventArgs e);
        void Next(MessageEventArgs e);
        void Start(MessageEventArgs e);
        void StoreTexts();
    }

    public abstract class SchemeBase : IScheme
    {
        public TelegramBotClient TBot { get; set; }

        public string BotUsername { get; set; }

        public abstract void Start(MessageEventArgs e);

        public abstract void Next(CallbackQueryEventArgs e);

        public abstract void Next(MessageEventArgs e);

        public static IScheme GetShemeFor(OurBot ourBot)
        {
            switch (ourBot.SchemeName)
            {
                case "Scheme1": return new Shemes.Scheme1.Scheme(ourBot.TBot);
                case "Register": return new Shemes.Register.RegisterScheme(ourBot.TBot);
            }

            return null;
        }

        public abstract void StoreTexts();
    }
}
