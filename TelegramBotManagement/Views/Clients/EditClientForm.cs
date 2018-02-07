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

namespace TelegramBotManagement.Views.Clients
{
    public partial class EditClientForm : Form
    {
        public event EventHandler<SaveClientArgs> SaveButtonClick;

        public EditClientForm()
        {
            InitializeComponent();
        }

        public void FillForm(Client client)
        {
            IdTb.Text = client.Id.ToString();
            UsernameTb.Text = client.Username;
            LastNameTb.Text = client.LastName;
            FirstNameTb.Text = client.FirstName;
            EmailTb.Text = client.Email;
            PhoneNumberTb.Text = client.PhoneNumber;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string email = "";

            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (EmailTb.Text.Length > 0)
            {
                if (!rEMail.IsMatch(EmailTb.Text))
                {
                    MessageBox.Show("Неверный формат E-Mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmailTb.SelectAll();
                }
                else
                {
                    email = EmailTb.Text;
                }
            }

            var client = new Client()
            {
                Id = int.Parse(IdTb.Text),
                Username = UsernameTb.Text,
                LastName = LastNameTb.Text,
                FirstName = FirstNameTb.Text,
                Email = email,
                PhoneNumber = PhoneNumberTb.Text
            };

            var args = new SaveClientArgs(client);
            SaveButtonClick?.Invoke(this, args);
        }

        private void EditClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveButton.PerformClick();
        }
    }
}
