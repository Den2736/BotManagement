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
        public Texts(string filePath)
        {
            FilePath = filePath;
            Load();
        }

        protected override string FilePath { get; set; }

        public string KnownClientGreeting { get; set; }

        public string CheckContactData { get; set; }
        public string PhoneNumberChanged { get; set; }
        public string EmailAddressChanged { get; set; }
        public string ItsAnActualData { get; set; }

        public string UnknownClientGreeting { get; set; }
        public string GetPhoneNumber { get; set; }
        public string GetEmailAddress { get; set; }
        public string GetBotToken { get; set; }
    }
}
