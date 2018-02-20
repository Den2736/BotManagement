namespace TelegramBotManagement
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BotList = new System.Windows.Forms.ListView();
            this.BotNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BotName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BotOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BotStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LaunchAllButton = new System.Windows.Forms.ToolStripButton();
            this.StopAllButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClients = new System.Windows.Forms.ToolStripButton();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LaunchBotContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopBotContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BotToken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BotList
            // 
            this.BotList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BotToken,
            this.BotNumber,
            this.BotName,
            this.BotOwner,
            this.BotStatus});
            this.BotList.FullRowSelect = true;
            this.BotList.GridLines = true;
            this.BotList.HideSelection = false;
            this.BotList.Location = new System.Drawing.Point(12, 28);
            this.BotList.Name = "BotList";
            this.BotList.Size = new System.Drawing.Size(760, 508);
            this.BotList.TabIndex = 1;
            this.BotList.UseCompatibleStateImageBehavior = false;
            this.BotList.View = System.Windows.Forms.View.Details;
            this.BotList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BotList_MouseClick);
            // 
            // BotNumber
            // 
            this.BotNumber.Text = "№";
            this.BotNumber.Width = 49;
            // 
            // BotName
            // 
            this.BotName.Text = "Бот";
            this.BotName.Width = 211;
            // 
            // BotOwner
            // 
            this.BotOwner.Text = "Владелец";
            this.BotOwner.Width = 196;
            // 
            // BotStatus
            // 
            this.BotStatus.Text = "Статус";
            this.BotStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BotStatus.Width = 299;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 539);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(784, 22);
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(66, 17);
            this.StatusLabel.Text = "statusLabel";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaunchAllButton,
            this.StopAllButton,
            this.toolStripSeparator1,
            this.btnClients});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LaunchAllButton
            // 
            this.LaunchAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LaunchAllButton.Image = ((System.Drawing.Image)(resources.GetObject("LaunchAllButton.Image")));
            this.LaunchAllButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LaunchAllButton.Name = "LaunchAllButton";
            this.LaunchAllButton.Size = new System.Drawing.Size(87, 22);
            this.LaunchAllButton.Text = "Запустить все";
            this.LaunchAllButton.Click += new System.EventHandler(this.LaunchAllButton_Click);
            // 
            // StopAllButton
            // 
            this.StopAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopAllButton.Image = ((System.Drawing.Image)(resources.GetObject("StopAllButton.Image")));
            this.StopAllButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopAllButton.Name = "StopAllButton";
            this.StopAllButton.Size = new System.Drawing.Size(96, 22);
            this.StopAllButton.Text = "Остановить все";
            this.StopAllButton.Click += new System.EventHandler(this.StopAllButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClients
            // 
            this.btnClients.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClients.Image = ((System.Drawing.Image)(resources.GetObject("btnClients.Image")));
            this.btnClients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(59, 22);
            this.btnClients.Text = "Клиенты";
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaunchBotContextMenuItem,
            this.StopBotContextMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(139, 48);
            this.ContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenu_ItemClicked);
            // 
            // LaunchBotContextMenuItem
            // 
            this.LaunchBotContextMenuItem.Name = "LaunchBotContextMenuItem";
            this.LaunchBotContextMenuItem.Size = new System.Drawing.Size(138, 22);
            this.LaunchBotContextMenuItem.Text = "Запустить";
            // 
            // StopBotContextMenuItem
            // 
            this.StopBotContextMenuItem.Name = "StopBotContextMenuItem";
            this.StopBotContextMenuItem.Size = new System.Drawing.Size(138, 22);
            this.StopBotContextMenuItem.Text = "Остановить";
            // 
            // BotToken
            // 
            this.BotToken.Text = "";
            this.BotToken.Width = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BotList);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.StatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MLM Bots";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView BotList;
        private System.Windows.Forms.ColumnHeader BotName;
        private System.Windows.Forms.ColumnHeader BotOwner;
        private System.Windows.Forms.ColumnHeader BotStatus;
        private System.Windows.Forms.ColumnHeader BotNumber;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClients;
        private System.Windows.Forms.ToolStripButton LaunchAllButton;
        private System.Windows.Forms.ToolStripButton StopAllButton;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem LaunchBotContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopBotContextMenuItem;
        private System.Windows.Forms.ColumnHeader BotToken;
    }
}

