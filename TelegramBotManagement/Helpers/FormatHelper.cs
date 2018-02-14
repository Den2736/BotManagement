using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Helpers
{
    public static class FormatHelper
    {
        public static bool IsEmailAddress(string probablyEmailAddress)
        {
            if (probablyEmailAddress.Length > 0)
            {
                System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

                if (rEMail.IsMatch(probablyEmailAddress))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
