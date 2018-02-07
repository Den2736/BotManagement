using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBotManagement.Models;
using TelegramBotManagement.Models.EventArgs;

namespace TelegramBotManagement.Views
{
    public partial class ClientsForm : Form
    {
        public event EventHandler<ContextMenuItemClickArgs> OnEditClientButtonClick;

        public ClientsForm()
        {
            InitializeComponent();
        }

        public void ShowClients(IEnumerable<Client> clients)
        {
            foreach (var client in clients)
            {
                var item = new ListViewItem((client.Id).ToString());

                item.SubItems.Add($"{client.LastName} {client.FirstName}");
                item.SubItems.Add(client.Username);
                item.SubItems.Add(client.Email);
                item.SubItems.Add(client.PhoneNumber);
                item.SubItems.Add(client.BotCount.ToString());
                ClientList.Items.Add(item);
            }
        }

        public void UpdateClient(Client client)
        {
            var item = ClientList.SelectedItems[0];
            item.SubItems[1].Text = $"{client.LastName} {client.FirstName}";
            item.SubItems[2].Text = client.Username;
            item.SubItems[3].Text = client.Email;
            item.SubItems[4].Text = client.PhoneNumber;
        }

        private void ClientList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ClientList.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    ContextMenu.Show(Cursor.Position);
                }
            }
        }

        private void ContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectedItem = ClientList.SelectedItems[0];
            switch(e.ClickedItem.Text)
            {
                case "Изменить":
                    {
                        var args = new ContextMenuItemClickArgs()
                        {
                            SelectedItem = ClientList.SelectedItems[0]
                        };
                        OnEditClientButtonClick?.Invoke(sender, args);
                        break;
                    }
                case "Копировать почту":
                    {
                        Clipboard.SetText(selectedItem.SubItems[3].Text);
                        break;
                    }
                case "Копировать username":
                    {
                        Clipboard.SetText(selectedItem.SubItems[2].Text);
                        break;
                    }
                case "Копировать номер телефона":
                    {
                        Clipboard.SetText(selectedItem.SubItems[4].Text);
                        break;
                    }
            }
        }
    }
}