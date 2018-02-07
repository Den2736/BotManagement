using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models.EventArgs
{
    public class SaveClientArgs: System.EventArgs
    {
        public SaveClientArgs(Client client) => Client = client;

        public Client Client { get; set; }
    }
}
