using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot;

namespace TelegramBotManagement.Models.Shemes
{
    public interface ISheme
    {
        void Next(CallbackQueryEventArgs e);
        void Next(MessageEventArgs e);
    }

    public abstract class SchemeBase : ISheme
    {
        public TelegramBotClient TBot { get; set; }

        public abstract void Next(CallbackQueryEventArgs e);

        public abstract void Next(MessageEventArgs e);

        public static ISheme GetShemeFor(OurBot ourBot)
        {
            switch (ourBot.SchemeName)
            {
                case "Scheme1": return new Shemes.Scheme1.Scheme(ourBot.TBot);
            }

            return null;
        }
    }
}
