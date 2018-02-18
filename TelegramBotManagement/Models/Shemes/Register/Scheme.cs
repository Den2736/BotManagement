using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramBotManagement.Controllers;
using TelegramBotManagement.Helpers;

namespace TelegramBotManagement.Models.Shemes.Register
{
    public class RegisterScheme : SchemeBase
    {
        public RegisterScheme(TelegramBotClient tBot)
        {
            TBot = tBot;
            Texts = new Texts();
            Keyboards = new Keyboards(Texts);
            BotUsername = TBot.GetMeAsync().Result.Username;
            ClientsForRegistration = new Dictionary<int, Client>();
        }

        private static Dictionary<int, Client> ClientsForRegistration { get; set; }  // Id, Client
        public Texts Texts { get; set; }
        public Keyboards Keyboards { get; set; }

        public override void Next(CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }
        public async override void Next(MessageEventArgs e)
        {
            var userId = e.Message.From.Id;
            string btnText = e.Message.Text;
            var state = GetUserState(userId);

            switch (state)
            {
                case State.UnknownClientGreeting:
                    {
                        if (btnText == Texts.LetsButton)
                        {
                            SetGetPhoneNumberState(e);
                        }
                        break;
                    }
                case State.CheckContactData:
                    {
                        if (btnText == Texts.PhoneNumberChangedButton)
                        {
                            SetGetPhoneNumberState(e);
                        }
                        else if (btnText == Texts.EmailAddressChangedButton)
                        {
                            SetGetEmailState(e);
                        }
                        else if (btnText == Texts.ItsAnActualDataButton)
                        {
                            SetGetTokenState(e);
                        }
                        break;
                    }
                case State.GetPhoneNumber:
                    {
                        if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.ContactMessage)
                        {
                            var contact = e.Message.Contact;
                            if (contact.UserId == userId)
                            {
                                SavePhoneNumber(e);
                                await TBot.SendTextMessageAsync(userId, Texts.PhoneNumberSaved);

                                if (DBHelper.IsClient(e.Message.From))
                                {
                                    SetCheckContactDataState(e);
                                }
                                else
                                {
                                    SetGetEmailState(e);
                                }
                            }
                            else
                            {
                                await TBot.SendTextMessageAsync(userId, $"{Emoji.Error} Нет, нам нужен ВАШ номер.");
                            }
                        }
                        else
                        {
                            await TBot.SendTextMessageAsync(userId, "Нажмите на кнопку внизу, чтобы отправить свой номер.");
                        }
                        break;
                    }
                case State.GetEmailAddress:
                    {
                        if (FormatHelper.IsEmailAddress(e.Message.Text))
                        {
                            SaveEmailAddress(e);
                            await TBot.SendTextMessageAsync(userId, Texts.EmailSaved);

                            if (DBHelper.IsClient(userId))
                            {
                                SetCheckContactDataState(e);
                            }
                            else
                            {
                                SaveNewClient(userId);
                                SetGetTokenState(e);
                            }
                        }
                        else
                        {
                            await TBot.SendTextMessageAsync(userId, $"{Emoji.Error} Это не адрес электронный почты.");
                        }
                        break;
                    }
                case State.GetBotToken:
                    {
                        string token = e.Message.Text;
                        if (TokenIsValid(token))
                        {
                            OurBot existedBot = null;
                            using (var db = DBHelper.GetConnection())
                            {
                                existedBot = db.Table<OurBot>().FirstOrDefault(b => b.Token == token);
                            }
                            if (existedBot != null)
                            {
                                var tBotName = new TelegramBotClient(token).GetMeAsync().Result.Username;
                                await TBot.SendTextMessageAsync(userId, $"Данный токен уже используется в Вашем персональном помощнике @{tBotName}");
                            }
                            else
                            {
                                BotController.RegisterNewBot(e.Message.Text, userId, nameof(Scheme1));
                                await TBot.SendTextMessageAsync(userId, $"Поздравляем");
                            }
                        }
                        else
                        {
                            await TBot.SendTextMessageAsync(userId, "Неверный токен");
                            SetGetTokenState(e);
                        }
                        break;
                    }
            }
        }

        private State GetUserState(int userId)
        {
            State state = State.UnknownClientGreeting;
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
        public override void Start(MessageEventArgs e)
        {
            SetStartState(e);
        }

        private async void SetStartState(MessageEventArgs e)
        {
            int userId = e.Message.From.Id;

            if (DBHelper.IsClient(e.Message.From))
            {
                await TBot.SendTextMessageAsync(userId, Texts.KnownClientGreeting);
                SetCheckContactDataState(e);
            }
            else
            {
                var text = Texts.UnknownClientGreeting(e.Message.From);
                var keyboard = Keyboards.UnknownClientGreetingKeyboard;
                await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
                SetState(userId, State.UnknownClientGreeting);
            }
        }
        private async void SetCheckContactDataState(MessageEventArgs e)
        {
            int userId = e.Message.From.Id;
            Client client = null;

            using (var db = DBHelper.GetConnection())
            {
                client = db.Find<Client>(userId);
            }

            var text = Texts.GetCheckContactDataText(client);
            var keyboard = Keyboards.CheckContactDataKeyboard;
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.CheckContactData);
        }
        private async void SetGetPhoneNumberState(MessageEventArgs e)
        {
            int userId = e.Message.From.Id;
            var text = Texts.GetPhoneNumber;
            var keyboard = Keyboards.GetPhoneNumberKeyboard;
            await TBot.SendTextMessageAsync(userId, text, replyMarkup: keyboard);
            SetState(userId, State.GetPhoneNumber);
        }
        private async void SetGetEmailState(MessageEventArgs e)
        {
            int userId = e.Message.From.Id;
            var text = Texts.GetEmailAddress;
            await TBot.SendTextMessageAsync(userId, text);
            SetState(userId, State.GetEmailAddress);
        }
        private void SavePhoneNumber(MessageEventArgs e)
        {
            var user = e.Message.From;
            int userId = user.Id;
            var contact = e.Message.Contact;

            if (DBHelper.IsClient(userId))
            {
                Client client = null;
                using (var db = DBHelper.GetConnection())
                {
                    client = db.Find<Client>(userId);
                    client.PhoneNumber = contact.PhoneNumber;
                    db.Update(client);
                }
            }
            else
            {
                /// TODO save user first and last name
                // save to RAM
                if (!ClientsForRegistration.ContainsKey(userId))
                {
                    ClientsForRegistration.Add(userId,
                        new Client()
                        {
                            Id = userId,
                            PhoneNumber = contact.PhoneNumber,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Username = user.Username
                        });
                }
            }
        }
        private void SaveEmailAddress(MessageEventArgs e)
        {
            int userId = e.Message.From.Id;
            if (DBHelper.IsClient(userId))
            {
                Client client = null;
                using (var db = DBHelper.GetConnection())
                {
                    client = db.Find<Client>(userId);
                    client.Email = e.Message.Text;
                    db.Update(client);
                }
            }
            else
            {
                // save to RAM
                ClientsForRegistration[userId].Email = e.Message.Text;
            }
        }
        private async void SetGetTokenState(MessageEventArgs e)
        {
            int userId = e.Message.From.Id;
            var text = Texts.GetBotToken;
            await TBot.SendTextMessageAsync(userId, text);
            SetState(userId, State.GetBotToken);
        }
        private void SaveNewClient(int userId)
        {
            using (var db = DBHelper.GetConnection())
            {
                db.Insert(ClientsForRegistration[userId]);
            }
        }
        private bool TokenIsValid(string token)
        {
            try
            {
                var bot = new TelegramBotClient(token);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public override void StoreTexts()
        {
            throw new NotImplementedException();
        }
    }
}
