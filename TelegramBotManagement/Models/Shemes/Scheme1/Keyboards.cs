using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotManagement.Models.Shemes.Scheme1
{
    public static class Keyboards
    {
        private static Text1.Texts Texts { get; set; }
        public static void SetTexts(Text1.Texts texts)
        {
            Texts = texts;
        }

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

        public static class Lamagna
        {
            public static InlineKeyboardMarkup GreetingKeyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.Lamagna.Button1)
                    }
                }
            };

            public static InlineKeyboardMarkup ExtendedGreetingKeyboard => new InlineKeyboardMarkup
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

            public static InlineKeyboardMarkup Text1Keyboard => PositiveOfNegativeKeyboard;

            public static InlineKeyboardMarkup Text2Keyboard => PositiveOfNegativeKeyboard;

            public static InlineKeyboardMarkup Text3Keyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.Lamagna.Button2)
                    }
                }
            };

            public static InlineKeyboardMarkup Text4Keyboard => new InlineKeyboardMarkup
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

        public static class Trippier
        {
            public static InlineKeyboardMarkup Text1Keyboard => PositiveOfNegativeKeyboard;
            public static InlineKeyboardMarkup Text2Keyboard => PositiveOfNegativeKeyboard;

            public static InlineKeyboardMarkup Text3Keyboard => new InlineKeyboardMarkup
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

        public static class MainProduct
        {
            public static InlineKeyboardMarkup Text1Keyboard => new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new KeyboardButton(Texts.MainProduct.Button1)
                    }
                }
            };

            public static InlineKeyboardMarkup ContactsKeyboard => new InlineKeyboardMarkup
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

        public static class PersonalAccount
        {
            public static ReplyKeyboardMarkup ChooseSettingKeyboard => new ReplyKeyboardMarkup
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

            public static ReplyKeyboardMarkup ChooseStatisticsKeyboard => new ReplyKeyboardMarkup
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

            public static ReplyKeyboardMarkup ChooseBlockKeyboard => new ReplyKeyboardMarkup
            {
                Keyboard = new KeyboardButton[][]
                {
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.LamagnaBlock),
                        new KeyboardButton(Texts.TrippierBlock),
                        new KeyboardButton(Texts.MainProductBlock),
                        new KeyboardButton(Texts.OtherBlock)
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton(Texts.BackButton),
                        new KeyboardButton(Texts.ToStartButton)
                    }
                },
                OneTimeKeyboard = true,
            };

            public static ReplyKeyboardMarkup ChooseTextKeyboard(string blockName)
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

            public static ReplyKeyboardMarkup EnterNewTextKeyboard => new ReplyKeyboardMarkup
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
}
