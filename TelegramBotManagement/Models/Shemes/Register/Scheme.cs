using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
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
        }

        public Texts Texts { get; set; }
        public Keyboards Keyboards { get; set; }

        public async override void Next(CallbackQueryEventArgs e)
        {
            await TBot.SendTextMessageAsync(e.CallbackQuery.From.Id, "CallbackQuery asnwer");
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
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

                        }
                        else if (btnText == Texts.ItsAnActualDataButton)
                        {

                        }
                        break;
                    }
                case State.GetPhoneNumber:
                    {
                        if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.ContactMessage)
                        {
                            var contact = e.Message.Contact;
                            var text = Texts.PhoneNumberSaved;

                            if (DBHelper.IsClient(e.Message.From))
                            {
                                Client client = null;
                                using (var db = DBHelper.GetConnection())
                                {
                                    client = db.Find<Client>(client);
                                    client.PhoneNumber = contact.PhoneNumber;
                                    db.Update(client);
                                }
                                await TBot.SendTextMessageAsync(userId, text);
                                SetCheckContactDataState(e);
                            }
                            else
                            {

                            }
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
    }
}
