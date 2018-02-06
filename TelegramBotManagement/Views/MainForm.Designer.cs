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
            this.RegisterButton = new System.Windows.Forms.Button();
            this.BotList = new System.Windows.Forms.ListView();
            this.BotNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BotName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BotOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BotStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(12, 12);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(120, 30);
            this.RegisterButton.TabIndex = 0;
            this.RegisterButton.Text = "Зарегистрировать";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // BotList
            // 
            this.BotList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BotNumber,
            this.BotName,
            this.BotOwner,
            this.BotStatus});
            this.BotList.FullRowSelect = true;
            this.BotList.HideSelection = false;
            this.BotList.Location = new System.Drawing.Point(12, 48);
            this.BotList.Name = "BotList";
            this.BotList.Size = new System.Drawing.Size(760, 484);
            this.BotList.TabIndex = 1;
            this.BotList.UseCompatibleStateImageBehavior = false;
            this.BotList.View = System.Windows.Forms.View.Details;
            // 
            // BotNumber
            // 
            this.BotNumber.Text = "№";
            this.BotNumber.Width = 49;
            // 
            // BotName
            // 
            this.BotName.Text = "BotName";
            this.BotName.Width = 211;
            // 
            // BotOwner
            // 
            this.BotOwner.Text = "BotOwner";
            this.BotOwner.Width = 196;
            // 
            // BotStatus
            // 
            this.BotStatus.Text = "BotStatus";
            this.BotStatus.Width = 299;
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.Status.Location = new System.Drawing.Point(0, 539);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(784, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // LaunchButton
            // 
            this.LaunchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchButton.Location = new System.Drawing.Point(672, 12);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(100, 30);
            this.LaunchButton.TabIndex = 3;
            this.LaunchButton.Text = "Запустить";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.BotList);
            this.Controls.Add(this.RegisterButton);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление Telegram ботами";
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.ListView BotList;
        private System.Windows.Forms.ColumnHeader BotName;
        private System.Windows.Forms.ColumnHeader BotOwner;
        private System.Windows.Forms.ColumnHeader BotStatus;
        private System.Windows.Forms.ColumnHeader BotNumber;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

