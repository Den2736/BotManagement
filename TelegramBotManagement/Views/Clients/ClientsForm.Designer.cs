namespace TelegramBotManagement.Views
{
    partial class ClientsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            this.ClientList = new System.Windows.Forms.ListView();
            this.clientId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientTelNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientBotNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuItemChange = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьUsernameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьНомерТелефонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientList
            // 
            this.ClientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clientId,
            this.clientName,
            this.clientUsername,
            this.clientEmail,
            this.clientTelNumber,
            this.clientBotNumber});
            this.ClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientList.FullRowSelect = true;
            this.ClientList.GridLines = true;
            this.ClientList.Location = new System.Drawing.Point(0, 0);
            this.ClientList.MultiSelect = false;
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(684, 361);
            this.ClientList.TabIndex = 1;
            this.ClientList.UseCompatibleStateImageBehavior = false;
            this.ClientList.View = System.Windows.Forms.View.Details;
            this.ClientList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClientList_MouseClick);
            // 
            // clientId
            // 
            this.clientId.Text = "Id";
            this.clientId.Width = 64;
            // 
            // clientName
            // 
            this.clientName.Text = "Имя";
            this.clientName.Width = 92;
            // 
            // clientUsername
            // 
            this.clientUsername.Text = "username";
            this.clientUsername.Width = 141;
            // 
            // clientEmail
            // 
            this.clientEmail.Text = "Email";
            this.clientEmail.Width = 147;
            // 
            // clientTelNumber
            // 
            this.clientTelNumber.Text = "Телефон";
            this.clientTelNumber.Width = 151;
            // 
            // clientBotNumber
            // 
            this.clientBotNumber.Text = "Кол-во ботов";
            this.clientBotNumber.Width = 80;
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuItemChange,
            this.копироватьToolStripMenuItem,
            this.копироватьUsernameToolStripMenuItem,
            this.копироватьНомерТелефонаToolStripMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(235, 114);
            this.ContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenu_ItemClicked);
            // 
            // ContextMenuItemChange
            // 
            this.ContextMenuItemChange.Name = "ContextMenuItemChange";
            this.ContextMenuItemChange.Size = new System.Drawing.Size(234, 22);
            this.ContextMenuItemChange.Text = "Изменить";
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.копироватьToolStripMenuItem.Text = "Копировать почту";
            // 
            // копироватьUsernameToolStripMenuItem
            // 
            this.копироватьUsernameToolStripMenuItem.Name = "копироватьUsernameToolStripMenuItem";
            this.копироватьUsernameToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.копироватьUsernameToolStripMenuItem.Text = "Копировать username";
            // 
            // копироватьНомерТелефонаToolStripMenuItem
            // 
            this.копироватьНомерТелефонаToolStripMenuItem.Name = "копироватьНомерТелефонаToolStripMenuItem";
            this.копироватьНомерТелефонаToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.копироватьНомерТелефонаToolStripMenuItem.Text = "Копировать номер телефона";
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.ClientList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView ClientList;
        private System.Windows.Forms.ColumnHeader clientName;
        private System.Windows.Forms.ColumnHeader clientUsername;
        private System.Windows.Forms.ColumnHeader clientEmail;
        private System.Windows.Forms.ColumnHeader clientTelNumber;
        private System.Windows.Forms.ColumnHeader clientBotNumber;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemChange;
        private System.Windows.Forms.ColumnHeader clientId;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьUsernameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьНомерТелефонаToolStripMenuItem;
    }
}