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

namespace TelegramBotManagement.Models.Shemes.Scheme1
{
    public class Keyboards
    {
        public Keyboards(Text1.Texts texts)
        {
            Texts = texts;
        }
        private static Text1.Texts Texts { get; set; }

        public static InlineKeyboardMarkup PositiveOfNegativeKeyboard => new InlineKeyboardMarkup
        {
            InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.Other.Negative),
                        new KeyboardButton(Texts.Other.Positive)
                    }
                }
        };

        public class Lamagna
        {
            public InlineKeyboardMarkup GreetingKeyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.Lamagna.Button1)
                    }
                }
            };

            public InlineKeyboardMarkup ExtendedGreetingKeyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.Lamagna.Button1),
                        new KeyboardButton(Texts.PersonalAccount.PersonalAccountButton)
                    }
                }
            };

            public InlineKeyboardMarkup Text1Keyboard => PositiveOfNegativeKeyboard;

            public InlineKeyboardMarkup Text2Keyboard => PositiveOfNegativeKeyboard;

            public InlineKeyboardMarkup Text3Keyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.Lamagna.Button2)
                    }
                }
            };

            public InlineKeyboardMarkup Text4Keyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.Lamagna.Button3)
                    }
                }
            };
        }

        public class Trippier
        {
            public InlineKeyboardMarkup Text1Keyboard => PositiveOfNegativeKeyboard;
            public InlineKeyboardMarkup Text2Keyboard => PositiveOfNegativeKeyboard;

            public InlineKeyboardMarkup Text3Keyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.Lamagna.Button1)
                    }
                }
            };
        }

        public class MainProduct
        {
            public InlineKeyboardMarkup Text1Keyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.MainProduct.Button1)
                    }
                }
            };

            public InlineKeyboardMarkup ContactsKeyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.MainProduct.Button2)
                    }
                }
            };
        }

        public class PersonalAccount
        {
            public ReplyKeyboardMarkup ChooseSettingKeyboard => new ReplyKeyboardMarkup
            {
                Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.PersonalAccount.StatisticsButton),
                        new KeyboardButton(Texts.PersonalAccount.TextsEditingButton)
                    },
                    new KeyboardButton[] { new KeyboardButton(Texts.BackButton) }
                },
                OneTimeKeyboard = true,
            };

            public ReplyKeyboardMarkup ChooseStatisticsKeyboard => new ReplyKeyboardMarkup
            {
                Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.PersonalAccount.AllUsersButton),
                        new KeyboardButton(Texts.PersonalAccount.LamagnaPassedUsersButton),

                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.PersonalAccount.TrippierPassedUsersButton),
                        new KeyboardButton(Texts.PersonalAccount.MainProductPassedUsersButton)
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.BackButton),
                        new KeyboardButton(Texts.ToStartButton)
                    }
                },
                OneTimeKeyboard = true,
            };

            public ReplyKeyboardMarkup ChooseBlockKeyboard => new ReplyKeyboardMarkup
            {
                Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        // Get blocks display names
                        new KeyboardButton(((DisplayNameAttribute) (typeof(Text1.Lamagna).GetCustomAttribute(typeof(DisplayNameAttribute), false))).DisplayName),
                        new KeyboardButton(((DisplayNameAttribute) (typeof(Text1.Trippier).GetCustomAttribute(typeof(DisplayNameAttribute), false))).DisplayName),
                        new KeyboardButton(((DisplayNameAttribute) (typeof(Text1.MainProduct).GetCustomAttribute(typeof(DisplayNameAttribute), false))).DisplayName),
                        new KeyboardButton(((DisplayNameAttribute) (typeof(Text1.Other).GetCustomAttribute(typeof(DisplayNameAttribute), false))).DisplayName),
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.BackButton),
                        new KeyboardButton(Texts.ToStartButton)
                    }
                },
                OneTimeKeyboard = true,
            };

            public ReplyKeyboardMarkup ChooseTextKeyboard(string blockName)
            {
                List<KeyboardButton[]> buttons = new List<KeyboardButton[]>();

                var blockProp = Texts.GetType().GetProperty(blockName);
                if (blockProp != null)
                {
                    var block = blockProp.GetValue(Texts);
                    if (block != null)
                    {
                        foreach (var prop in block.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            DisplayNameAttribute attr = (DisplayNameAttribute)prop.GetCustomAttribute(typeof(DisplayNameAttribute));
                            buttons.Add(new KeyboardButton[] { new KeyboardButton(attr.DisplayName) });
                        }
                    }
                }
                buttons.Add(new KeyboardButton[]
                        {
                            new KeyboardButton(Texts.BackButton),
                            new KeyboardButton(Texts.ToStartButton)
                        });

                return new ReplyKeyboardMarkup
                {
                    Keyboard = buttons.ToArray(),
                    OneTimeKeyboard = true,
                };
            }

            public ReplyKeyboardMarkup EnterNewTextKeyboard => new ReplyKeyboardMarkup
            {
                Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.BackButton),
                        new KeyboardButton(Texts.ToStartButton)
                    }
                },
                OneTimeKeyboard = true,
                ResizeKeyboard = true
            };
        }
    }
}
