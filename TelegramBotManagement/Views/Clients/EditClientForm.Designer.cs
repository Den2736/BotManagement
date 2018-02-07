namespace TelegramBotManagement.Views.Clients
{
    partial class EditClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditClientForm));
            this.SaveButton = new System.Windows.Forms.Button();
            this.PhoneNumberTb = new System.Windows.Forms.MaskedTextBox();
            this.PhoneNumberLbl = new System.Windows.Forms.Label();
            this.EmailTb = new System.Windows.Forms.TextBox();
            this.EmailLbl = new System.Windows.Forms.Label();
            this.FirstNameTb = new System.Windows.Forms.TextBox();
            this.FirstNameLbl = new System.Windows.Forms.Label();
            this.UsernameTb = new System.Windows.Forms.TextBox();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.LastNameTb = new System.Windows.Forms.TextBox();
            this.LastNameLbl = new System.Windows.Forms.Label();
            this.IdTb = new System.Windows.Forms.TextBox();
            this.IdLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(106, 181);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 25;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PhoneNumberTb
            // 
            this.PhoneNumberTb.Location = new System.Drawing.Point(86, 146);
            this.PhoneNumberTb.Mask = "+7-000-000-00-00";
            this.PhoneNumberTb.Name = "PhoneNumberTb";
            this.PhoneNumberTb.Size = new System.Drawing.Size(188, 20);
            this.PhoneNumberTb.TabIndex = 24;
            // 
            // PhoneNumberLbl
            // 
            this.PhoneNumberLbl.AutoSize = true;
            this.PhoneNumberLbl.Location = new System.Drawing.Point(11, 149);
            this.PhoneNumberLbl.Name = "PhoneNumberLbl";
            this.PhoneNumberLbl.Size = new System.Drawing.Size(52, 13);
            this.PhoneNumberLbl.TabIndex = 23;
            this.PhoneNumberLbl.Text = "Телефон";
            // 
            // EmailTb
            // 
            this.EmailTb.Location = new System.Drawing.Point(86, 117);
            this.EmailTb.Name = "EmailTb";
            this.EmailTb.Size = new System.Drawing.Size(188, 20);
            this.EmailTb.TabIndex = 22;
            // 
            // EmailLbl
            // 
            this.EmailLbl.AutoSize = true;
            this.EmailLbl.Location = new System.Drawing.Point(31, 120);
            this.EmailLbl.Name = "EmailLbl";
            this.EmailLbl.Size = new System.Drawing.Size(32, 13);
            this.EmailLbl.TabIndex = 21;
            this.EmailLbl.Text = "Email";
            // 
            // FirstNameTb
            // 
            this.FirstNameTb.Location = new System.Drawing.Point(86, 91);
            this.FirstNameTb.Name = "FirstNameTb";
            this.FirstNameTb.Size = new System.Drawing.Size(188, 20);
            this.FirstNameTb.TabIndex = 20;
            // 
            // FirstNameLbl
            // 
            this.FirstNameLbl.AutoSize = true;
            this.FirstNameLbl.Location = new System.Drawing.Point(34, 94);
            this.FirstNameLbl.Name = "FirstNameLbl";
            this.FirstNameLbl.Size = new System.Drawing.Size(29, 13);
            this.FirstNameLbl.TabIndex = 19;
            this.FirstNameLbl.Text = "Имя";
            // 
            // UsernameTb
            // 
            this.UsernameTb.Location = new System.Drawing.Point(86, 39);
            this.UsernameTb.Name = "UsernameTb";
            this.UsernameTb.Size = new System.Drawing.Size(188, 20);
            this.UsernameTb.TabIndex = 18;
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Location = new System.Drawing.Point(8, 42);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(55, 13);
            this.UsernameLbl.TabIndex = 17;
            this.UsernameLbl.Text = "Username";
            // 
            // LastNameTb
            // 
            this.LastNameTb.Location = new System.Drawing.Point(86, 65);
            this.LastNameTb.Name = "LastNameTb";
            this.LastNameTb.Size = new System.Drawing.Size(188, 20);
            this.LastNameTb.TabIndex = 16;
            // 
            // LastNameLbl
            // 
            this.LastNameLbl.AutoSize = true;
            this.LastNameLbl.Location = new System.Drawing.Point(7, 68);
            this.LastNameLbl.Name = "LastNameLbl";
            this.LastNameLbl.Size = new System.Drawing.Size(56, 13);
            this.LastNameLbl.TabIndex = 15;
            this.LastNameLbl.Text = "Фамилия";
            // 
            // IdTb
            // 
            this.IdTb.Enabled = false;
            this.IdTb.Location = new System.Drawing.Point(86, 13);
            this.IdTb.Name = "IdTb";
            this.IdTb.Size = new System.Drawing.Size(188, 20);
            this.IdTb.TabIndex = 14;
            // 
            // IdLbl
            // 
            this.IdLbl.AutoSize = true;
            this.IdLbl.Location = new System.Drawing.Point(47, 16);
            this.IdLbl.Name = "IdLbl";
            this.IdLbl.Size = new System.Drawing.Size(16, 13);
            this.IdLbl.TabIndex = 13;
            this.IdLbl.Text = "Id";
            // 
            // EditClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 216);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PhoneNumberTb);
            this.Controls.Add(this.PhoneNumberLbl);
            this.Controls.Add(this.EmailTb);
            this.Controls.Add(this.EmailLbl);
            this.Controls.Add(this.FirstNameTb);
            this.Controls.Add(this.FirstNameLbl);
            this.Controls.Add(this.UsernameTb);
            this.Controls.Add(this.UsernameLbl);
            this.Controls.Add(this.LastNameTb);
            this.Controls.Add(this.LastNameLbl);
            this.Controls.Add(this.IdTb);
            this.Controls.Add(this.IdLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование клиента";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditClientForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.MaskedTextBox PhoneNumberTb;
        private System.Windows.Forms.Label PhoneNumberLbl;
        private System.Windows.Forms.TextBox EmailTb;
        private System.Windows.Forms.Label EmailLbl;
        private System.Windows.Forms.TextBox FirstNameTb;
        private System.Windows.Forms.Label FirstNameLbl;
        private System.Windows.Forms.TextBox UsernameTb;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.TextBox LastNameTb;
        private System.Windows.Forms.Label LastNameLbl;
        private System.Windows.Forms.TextBox IdTb;
        private System.Windows.Forms.Label IdLbl;
    }
}