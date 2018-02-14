using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.Shemes.Register
{
    public class Texts : TextsBase
    {
        protected override string FilePath { get; set; }

        public string KnownClientGreeting => $"Старый знакомый! Привет! {Emoji.Hello}";

        public string GetCheckContactDataText(Client client) => 
            $"Ваши контактные данные не поменялись?{Environment.NewLine}" +
            $"{Emoji.Phone} Тел. номер: {client.PhoneNumber}{Environment.NewLine}" +
            $"{Emoji.MailBoxUp} E-mail: {client.Email}";
        public string PhoneNumberChangedButton => $"{Emoji.Phone} Поменялся номер";
        public string EmailAddressChangedButton => $"{Emoji.MailBoxUp} Поменялась почта";
        public string ItsAnActualDataButton => $"{Emoji.Success} Это мои актуальные данные";

        public string UnknownClientGreeting (Telegram.Bot.Types.User user) => $"Здравствуйте, {user.FirstName}! Для начала давайте лучше узнаем друг друга.";
        public string LetsButton => $"Давай!{Emoji.WithCheeks}";
        public string GetPhoneNumber => $"Есть телефон с камерой позвонить?";
        public string GetPhoneNumberButton => $"Отправить мой номер";
        public string PhoneNumberSaved => $"Номер сохранён! {Emoji.Success}";
        public string GetEmailAddress => $"Пришлите мне адрес вашей электронной почты {Emoji.MailBoxUp}";
        public string EmailSaved => $"Email сохранён! {Emoji.Success}";
        public string GetBotToken => $"Пришлите мне токен {Emoji.Key} вашего бота и мы сделаем из него персонального помощника!";
    }
}
