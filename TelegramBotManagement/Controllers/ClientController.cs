using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBotManagement.Helpers;
using TelegramBotManagement.Models;
using TelegramBotManagement.Models.EventArgs;
using TelegramBotManagement.Views;
using TelegramBotManagement.Views.Clients;

namespace TelegramBotManagement.Controllers
{
    public static class ClientController
    {
        private static ClientsForm Form;
        private static EditClientForm EditForm;

        public static void Init()
        {
            MainController.OnClientsButtonClick += MainController_OnClientsButtonClick;
        }

        private static void MainController_OnClientsButtonClick(object sender, EventArgs e)
        {
            Form = new ClientsForm();
            Form.OnEditClientButtonClick += ClientsForm_OnEditClientButtonClick;
            Form.ShowClients(GetClients());
            Form.ShowDialog();
        }

        private static void ClientsForm_OnEditClientButtonClick(object sender, ContextMenuItemClickArgs e)
        {
            EditForm = new EditClientForm();
            EditForm.SaveButtonClick += UpdateClient;

            int clientId = int.Parse(e.SelectedItem.Text);

            using (var db = DBHelper.GetConnection())
            {
                EditForm.FillForm(db.Find<Client>(clientId));
            }
            EditForm.ShowDialog();
        }

        private static void UpdateClient(object sender, SaveClientArgs e)
        {
            try
            {
                var client = e.Client;
                using (var db = DBHelper.GetConnection())
                {
                    db.Update(client);
                }
                MessageBox.Show("Сохранено", "Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                EditForm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения в базу данных: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>();
            using (var db = DBHelper.GetConnection())
            {
                clients = db.Table<Client>().ToList();

                foreach (var client in clients)
                {
                    client.BotCount = db.Table<OurBot>().Where(b => b.OwnerId == client.Id).Count();
                }
            }
            return clients;
        }
    }
}
