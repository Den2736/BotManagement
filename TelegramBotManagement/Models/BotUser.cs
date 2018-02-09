using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotManagement.Models
{
    public class BotUser
    {
        [PrimaryKey, Unique]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotNull]
        public bool LamagnaPassed { get; set; }

        [NotNull]
        public bool TrippierPassed { get; set; }

        [NotNull]
        public bool MainProductPassed { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} (@{UserName})";
        }
    }
}
