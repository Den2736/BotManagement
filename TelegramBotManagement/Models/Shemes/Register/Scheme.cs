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
            Texts = new Texts($"BotsContent/{TBot.GetMeAsync().Result.Username}/Texts.xml");
            Keyboards = new Keyboards(Texts);
            BotUsername = TBot.GetMeAsync().Result.Username;
        }

        public Texts Texts { get; set; }
        public Keyboards Keyboards { get; set; }
        private string BotUsername;

        public async override void Next(CallbackQueryEventArgs e)
        {
            await TBot.SendTextMessageAsync(e.CallbackQuery.From.Id, "CallbackQuery asnwer");
            await TBot.AnswerCallbackQueryAsync(e.CallbackQuery.Id);
        }

        public async override void Next(MessageEventArgs e)
        {
            await TBot.SendTextMessageAsync(e.Message.From.Id, "Message asnwer");
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

        public override void Start(MessageEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
