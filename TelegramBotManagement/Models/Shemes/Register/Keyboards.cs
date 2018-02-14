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
                        new KeyboardButton(Texts.PhoneNumberChangedButton)
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.EmailAddressChangedButton)
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.ItsAnActualDataButton)
                    },
                },
            OneTimeKeyboard = true
        };
        public static ReplyKeyboardMarkup GetPhoneNumberKeyboard => new ReplyKeyboardMarkup
        {
            Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.GetPhoneNumberButton){ RequestContact = true }
                    }
                },
            ResizeKeyboard = true
        };
        public static ReplyKeyboardMarkup UnknownClientGreetingKeyboard => new ReplyKeyboardMarkup
        {
            Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.LetsButton)
                    }
                },
            ResizeKeyboard = true
        };

    }
}