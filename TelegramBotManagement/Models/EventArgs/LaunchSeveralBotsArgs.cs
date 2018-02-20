using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.EventArgs
{
    public class LaunchSeveralBotsArgs: System.EventArgs
    {
        public IEnumerable<string> BotsTokens { get; set; }
    }
}
