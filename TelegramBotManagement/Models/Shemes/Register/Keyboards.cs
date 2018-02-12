using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotManagement.Models.Shemes.Register
{
    public class Keyboards
    {
        public Keyboards(Texts texts)
        {
            Texts = texts;
        }
        private static Texts Texts { get; set; }

        public static ReplyKeyboardMarkup CheckContactDataKeyboard => new ReplyKeyboardMarkup
        {
            Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.PhoneNumberChanged)
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.EmailAddressChanged)
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.ItsAnActualData)
                    },
                }
        };
    }
}
