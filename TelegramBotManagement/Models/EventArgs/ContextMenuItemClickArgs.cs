using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelegramBotManagement.Models.EventArgs
{
    public class ContextMenuItemClickArgs: System.EventArgs
    {
        public ListViewItem SelectedItem { get; set; }
    }
}
