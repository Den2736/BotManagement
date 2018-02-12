using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.Shemes.Register
{
    public enum State
    {
        KnownClientGreeting,
        CheckContactData,
        UnknownClientGreeting,
        GetPhoneNumber,
        GetEmailAddress,
        GetBotToken
    }
}
