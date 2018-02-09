using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Helpers
{
    public static class Logger
    {
        public static void Log(string botName, string message)
        {
            File.AppendAllText($"BotsLog/{botName}.txt", $"{Environment.NewLine}{DateTime.Now.ToString("G")}: {message}");
        }
    }
}
