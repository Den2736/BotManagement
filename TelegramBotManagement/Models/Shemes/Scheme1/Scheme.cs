using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramBotManagement.Controllers;
using TelegramBotManagement.Helpers;

namespace TelegramBotManagement.Models.Shemes.Scheme1
{
    public class Scheme : SchemeBase
    {
        public Scheme(TelegramBotClient tBot)
        {
            TBot = tBot;
            Texts = new Texts(TextsBase.GetFilePathFor(TBot));
            Keyboards = new Keyboards(Texts);
            BotUsername = TBot.GetMeAsync().Result.Username;
        }

        public Texts Texts { get; set; }
        public Keyboards Keyboards { get; set; }

        public override void StoreTexts()
        {
            Texts.Store();
        }

        public override void Start(MessageEventArgs e)
        {
            SetGreetingState(e.Message.From.Id);
        }

        public override void Next(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            string message = e.CallbackQuery.Message.Text;
            string btnText = e.CallbackQuery.Data;

            // LAMAGNA
            if (message == Texts.Lamagna.Greeting)
            {
                if (btnText == Texts.Lamagna.Button1)
                {
                    SetLamagna1State(e);
                }
                else if (btnText == Texts.PersonalAccount.PersonalAccountButton)
                {
                    SetChooseSettingsState(e);
                }
            }
            else if (message == Texts.Lamagna.Text1)
            {
                if (btnText == Texts.Other.Positive)
                {
                    SetLamagna2State(e);
                }
                else if (btnText == Texts.Other.Negative)
                {
                    SetLamagna3State(e);
                }
            }
            else if (message == Texts.Lamagna.Text2)
            {
                if (btnText == Texts.Other.Positive)
                {
                    DBHelper.UserPassedTheBlock(BotUsername, userId, Block.Lamagna);
                    SetTrippier1State(e);
                }
                else if (btnText == Texts.Other.Negative)
                {
                    SetLamagna4State(e);
                }
            }
            else if (message == Texts.Lamagna.Text3)
            {
                if (btnText == Texts.Lamagna.Button2)
                {
                    SetLamagna2State(e);
                }
            }
            else if (message == Texts.Lamagna.Text4)
            {
                if (btnText == Texts.Lamagna.Button3)
                {
                    DBHelper.UserPassedTheBlock(BotUsername, userId, Block.Trippier);
                    SetTrippier1State(e);
                }
            }

            // TRIPPIER
            else if (message == Texts.Trippier.Text1)
            {
                if (btnText == Texts.Other.Positive)
                {
                    DBHelper.UserPassedTheBlock(BotUsername, userId, Block.MainProduct);
                    SetMainProductState(e);
                }
                else if (btnText == Texts.Other.Negative)
                {
                    SetTrippier2State(e);
                }
            }
            else if (message == Texts.Trippier.Text2)
            {
                if (btnText == Texts.Other.Positive)
                {
                    SetTrippier3State(e);
                }
                else if (btnText == Texts.Other.Negative)
                {
                    SetTrippier1State(e);
                }
            }
            else if (message == Texts.Trippier.Text3)
            {
                if (btnText == Texts.Trippier.Button1)
                {
                    SetContactsState(e);
                }
            }

            // MAIN PRODUCT
            else if (message == Texts.MainProduct.Text1)
            {
                if (btnText == Texts.MainProduct.Button1)
                {
                    DBHelper.UserPassedTheBlock(BotUsername, userId, Block.MainProduct);
                    SetContactsState(e);
                }
            }
            else if (message == Texts.Other.Contacts)
            {
                if (btnText == Texts.MainProduct.Button2)
                {
                    SetGreetingState(e.CallbackQuery.From.Id);
                }
            }
        }

        public async override void Next(MessageEventArgs e)
        {
            var userId = e.Message.From.Id;
            string btnText = e.Message.Text;
            var state = GetUserState(userId);

            if (btnText == Texts.ToStartButton)
            {
                SetGreetingState(e.Message.From.Id);
            }
            else
            {
                switch (state)
                {
                    case State.ChooseSettings:
                        {
                            if (btnText == Texts.PersonalAccount.StatisticsButton)
                            {
                                SetChooseStatisticsState(e);
                            }
                            else if (btnText == Texts.PersonalAccount.TextsEditingButton)
                            {
                                SetChooseBlockState(e);
                            }
                            else if (btnText == Texts.BackButton)
                            {
                                SetGreetingState(e.Message.From.Id);
                            }
                            break;
                        }
                    case State.ChooseStatistics:
                        {
                            if (btnText == Texts.PersonalAccount.AllUsersButton)
                            {
                                ShowAllUsers(e);
                            }
                            else if (btnText == Texts.PersonalAccount.LamagnaPassedUsersButton)
                            {
                                ShowLamagnaPassedUsers(e);
                            }
                            else if (btnText == Texts.PersonalAccount.TrippierPassedUsersButton)
                            {
                                ShowTrippierPassedUsers(e);
                            }
                            else if (btnText == Texts.PersonalAccount.MainProductPassedUsersButton)
                            {
                                ShowMainProductPassedUsers(e);
                            }
                            else if (btnText == Texts.BackButton)
                            {
                                SetChooseSettingsState(e);
                            }
                            break;
                        }
                    case State.ChooseBlockToEdit:
                        {
                            if (btnText == Texts.BackButton)
                            {
                                SetChooseSettingsState(e);
                            }
                            else if (Texts.ValidBlockName(e.Message.Text))
                            {
                                SaveBlockChoice(userId, e.Message.Text);
                                SetChooseTextState(e);
                            }
                            else
                            {
                                await TBot.SendTextMessageAsync(userId, $"{Emoji.Error} Нет такого блока.");
                                SetChooseBlockState(e);
                            }
                            break;
                        }
                    case State.ChooseTextToEdit:
                        {
                            if (btnText == Texts.BackButton)
                            {
                                SetChooseBlockState(e);
                            }
                            else
                            {
                                SaveTextChoice(userId, e.Message.Text);
                                SetEnterNewTextState(e);
                            }
                            break;
                        }
                    case State.EnterNewText:
                        {
                            if (btnText == Texts.BackButton)
                            {
                                SetChooseTextState(e);
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(btnText))
                                {
                                    await TBot.SendTextMessageAsync(userId, "Молчание не привлечёт к вам клиентов!");
                                    SetChooseTextState(e);
                                }
                                UpdateText(e);
                            }
                            break;
                        }
                }
            }
        }

        private State GetUserState(int userId)
        {
            State state = State.Greeting;
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            string stateString = cache.StringGet($"Bot{BotUsername}User{userId}State");
            Enum.TryParse(stateString, out state);
            return state;
        }

        private void SetState(int userId, State state)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            cache.StringSet($"Bot{BotUsername}User{userId}State", state.ToString());
        }


        private async void SetGreetingState(int userId)
        {
            var text = Texts.Lamagna.Greeting;
            var keyboard = BotController.IsOwner(userId, TBot) ? Keyboards.Lamagna.ExtendedGreetingKeyboard : Keyboards.Lamagna.GreetingKeyboard;
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Greeting);
        }

        private async void SetLamagna1State(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.Lamagna.Text1;
            var keyboard = Keyboards.Lamagna.Text1Keyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Lamagna1);
        }

        private async void SetLamagna2State(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.Lamagna.Text2;
            var keyboard = Keyboards.Lamagna.Text2Keyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Lamagna2);
        }

        private async void SetLamagna3State(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.Lamagna.Text3;
            var keyboard = Keyboards.Lamagna.Text3Keyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Lamagna3);
        }

        private async void SetLamagna4State(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.Lamagna.Text4;
            var keyboard = Keyboards.Lamagna.Text4Keyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Lamagna4);
        }

        private async void SetTrippier1State(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.Trippier.Text1;
            var keyboard = Keyboards.Trippier.Text1Keyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Trippier1);
        }

        private async void SetTrippier2State(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.Trippier.Text2;
            var keyboard = Keyboards.Trippier.Text2Keyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Trippier2);
        }

        private async void SetTrippier3State(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.Trippier.Text3;
            var keyboard = Keyboards.Trippier.Text3Keyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Trippier3);
        }

        private async void SetMainProductState(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.MainProduct.Text1;
            var keyboard = Keyboards.MainProduct.Text1Keyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.MainProduct);
        }

        private async void SetContactsState(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.Other.Contacts;
            var keyboard = Keyboards.MainProduct.ContactsKeyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.Contacts);
        }

        private async void SetChooseSettingsState(CallbackQueryEventArgs e)
        {
            var userId = e.CallbackQuery.From.Id;
            var text = Texts.PersonalAccount.PersnonalAccountGreeting(e.CallbackQuery.From.FirstName);
            var keyboard = Keyboards.PersonalAccount.ChooseSettingKeyboard;
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, "");
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.ChooseSettings);
        }

        private async void SetChooseSettingsState(MessageEventArgs e)
        {
            var userId = e.Message.From.Id;
            var text = Texts.PersonalAccount.PersnonalAccountGreeting(e.Message.From.FirstName);
            var keyboard = Keyboards.PersonalAccount.ChooseSettingKeyboard;
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.ChooseSettings);
        }


        private async void SetChooseStatisticsState(MessageEventArgs e)
        {
            var userId = e.Message.From.Id;
            var text = Texts.PersonalAccount.ChooseStatistics;
            var keyboard = Keyboards.PersonalAccount.ChooseStatisticsKeyboard;
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.ChooseStatistics);
        }

        private void ShowAllUsers(MessageEventArgs e)
        {
            var newMessage = $"Пользователи бота {BotUsername}:{Environment.NewLine}";

            using (var db = DBHelper.GetConnection())
            {
                var users = db.Table<BotUser>();
                foreach (var user in users)
                {
                    newMessage += $"{Environment.NewLine}{user.ToString()}";
                }
            }
            TBot.SendTextMessageAsync(e.Message.From.Id, newMessage);
            SetChooseStatisticsState(e);
        }

        private void ShowLamagnaPassedUsers(MessageEventArgs e)
        {
            var newMessage = $"Пользователи бота {BotUsername}, прошедшие блок Лидмагнит:{Environment.NewLine}";

            using (var db = DBHelper.GetConnection())
            {
                var users = db.Table<BotUser>().Where(u => u.LamagnaPassed);
                foreach (var user in users)
                {
                    newMessage += $"{Environment.NewLine}{user.ToString()}";
                }
            }
            TBot.SendTextMessageAsync(e.Message.From.Id, newMessage);
            SetChooseStatisticsState(e);
        }

        private void ShowTrippierPassedUsers(MessageEventArgs e)
        {
            var newMessage = $"Пользователи бота {BotUsername}, прошедшие блок Трипвайер:{Environment.NewLine}";

            using (var db = DBHelper.GetConnection())
            {
                var users = db.Table<BotUser>().Where(u => u.TrippierPassed);
                foreach (var user in users)
                {
                    newMessage += $"{Environment.NewLine}{user.ToString()}";
                }
            }
            TBot.SendTextMessageAsync(e.Message.From.Id, newMessage);
            SetChooseStatisticsState(e);
        }

        private void ShowMainProductPassedUsers(MessageEventArgs e)
        {
            var newMessage = $"Пользователи бота {BotUsername}, прошедшие блок Главный продукт:{Environment.NewLine}";

            using (var db = DBHelper.GetConnection())
            {
                var users = db.Table<BotUser>().Where(u => u.MainProductPassed);
                foreach (var user in users)
                {
                    newMessage += $"{Environment.NewLine}{user.ToString()}";
                }
            }
            TBot.SendTextMessageAsync(e.Message.From.Id, newMessage);
            SetChooseStatisticsState(e);
        }

        private async void SetChooseBlockState(MessageEventArgs e)
        {
            var userId = e.Message.From.Id;
            var text = Texts.PersonalAccount.ChooseBlock;
            var keyboard = Keyboards.PersonalAccount.ChooseBlockKeyboard;
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.ChooseBlockToEdit);
        }

        private async void SetChooseTextState(MessageEventArgs e)
        {
            var userId = e.Message.From.Id;
            var text = Texts.PersonalAccount.ChooseText;
            var blockChoice = GetBlockChoice(userId).ToString();
            var keyboard = Keyboards.PersonalAccount.ChooseTextKeyboard(blockChoice);
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.ChooseTextToEdit);
        }

        private async void SetEnterNewTextState(MessageEventArgs e)
        {
            var userId = e.Message.From.Id;
            var block = GetBlockChoice(userId);
            var text =
                $"{Texts.PersonalAccount.YouWantToChange} *{e.Message.Text}* {Environment.NewLine}";
            var currentText = Texts.GetText(block, e.Message.Text);
            if (string.IsNullOrEmpty(currentText))
            {
                text = $"{Emoji.Error} Такого текста не существует.";
                await TBot.SendTextMessageAsync(userId, text);
                SetChooseTextState(e);
            }
            else
            {
                await TBot.SendTextMessageAsync(userId, text, Telegram.Bot.Types.Enums.ParseMode.Markdown);
                text = Texts.PersonalAccount.EnterNewText;
                var keyboard = Keyboards.PersonalAccount.EnterNewTextKeyboard;
                await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
                SetState(userId, State.EnterNewText);
            }
        }

        private async void UpdateText(MessageEventArgs e)
        {
            int userId = e.Message.From.Id;
            var block = GetBlockChoice(userId);
            var fieldName = GetTextChoice(userId);
            Texts.Update(block, fieldName, e.Message.Text);

            string text = Texts.PersonalAccount.NewTextSaved;
            await TBot.SendTextMessageAsync(userId, text);
            SetChooseTextState(e);
        }

        private void SaveBlockChoice(int userId, string block)
        {
            if (block == Texts.GetDisplayName(Texts.Lamagna))
            {
                block = Block.Lamagna.ToString();
            }
            else if (block == Texts.GetDisplayName(Texts.Trippier))
            {
                block = Block.Trippier.ToString();
            }
            else if (block == Texts.GetDisplayName(Texts.MainProduct))
            {
                block = Block.MainProduct.ToString();
            }
            else if (block == Texts.GetDisplayName(Texts.Other))
            {
                block = Block.Other.ToString();
            }

            var cache = RedisConnectorHelper.Connection.GetDatabase();
            cache.StringSet($"Bot{BotUsername}User{userId}BlockChoice", block);
        }
        private Block GetBlockChoice(int userId)
        {
            Block block;
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            string blockString = cache.StringGet($"Bot{BotUsername}User{userId}BlockChoice");
            Enum.TryParse(blockString, out block);
            return block;
        }

        private void SaveTextChoice(int userId, string block)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            cache.StringSet($"Bot{BotUsername}User{userId}TextChoice", block);
        }
        private string GetTextChoice(int userId)
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            return cache.StringGet($"Bot{BotUsername}User{userId}TextChoice");
        }

        
    }
}
