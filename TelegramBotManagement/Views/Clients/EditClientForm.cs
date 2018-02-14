using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelegramBotManagement.Helpers;
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
            if (FormatHelper.IsEmailAddress(EmailTb.Text))
            {
                email = EmailTb.Text;
            }
            else
            {
                MessageBox.Show("Неверный формат E-Mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTb.SelectAll();
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
