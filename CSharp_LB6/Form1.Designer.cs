namespace CSharp_LB6
{
    partial class Form1
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
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.radioButtonOtherFiles = new System.Windows.Forms.RadioButton();
            this.radioButtonClientFiles = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.groupBoxUsers = new System.Windows.Forms.GroupBox();
            this.buttonSelectUser = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonChangeFileStatus = new System.Windows.Forms.Button();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileDataCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonRemoveFile = new System.Windows.Forms.Button();
            this.groupBoxMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxUsers.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFile.Location = new System.Drawing.Point(1272, 27);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(91, 56);
            this.buttonAddFile.TabIndex = 0;
            this.buttonAddFile.Text = "Додати файл";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.radioButtonOtherFiles);
            this.groupBoxMode.Controls.Add(this.radioButtonClientFiles);
            this.groupBoxMode.Location = new System.Drawing.Point(39, 27);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(229, 100);
            this.groupBoxMode.TabIndex = 1;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // radioButtonOtherFiles
            // 
            this.radioButtonOtherFiles.Location = new System.Drawing.Point(116, 28);
            this.radioButtonOtherFiles.Name = "radioButtonOtherFiles";
            this.radioButtonOtherFiles.Size = new System.Drawing.Size(104, 56);
            this.radioButtonOtherFiles.TabIndex = 1;
            this.radioButtonOtherFiles.Text = "Файли інших";
            this.radioButtonOtherFiles.UseVisualStyleBackColor = true;
            this.radioButtonOtherFiles.CheckedChanged += new System.EventHandler(this.radioButtonOtherFiles_CheckedChanged);
            // 
            // radioButtonClientFiles
            // 
            this.radioButtonClientFiles.Checked = true;
            this.radioButtonClientFiles.Location = new System.Drawing.Point(6, 28);
            this.radioButtonClientFiles.Name = "radioButtonClientFiles";
            this.radioButtonClientFiles.Size = new System.Drawing.Size(104, 56);
            this.radioButtonClientFiles.TabIndex = 0;
            this.radioButtonClientFiles.TabStop = true;
            this.radioButtonClientFiles.Text = "Свої файли";
            this.radioButtonClientFiles.UseVisualStyleBackColor = true;
            this.radioButtonClientFiles.CheckedChanged += new System.EventHandler(this.radioButtonClientFiles_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Number, this.FileName, this.FileWeight, this.FilePath, this.FileDataCreate, this.IsAvailable });
            this.dataGridView1.Location = new System.Drawing.Point(12, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1351, 616);
            this.dataGridView1.TabIndex = 2;
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(6, 25);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(343, 32);
            this.comboBoxUsers.TabIndex = 3;
            // 
            // groupBoxUsers
            // 
            this.groupBoxUsers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxUsers.Controls.Add(this.buttonSelectUser);
            this.groupBoxUsers.Controls.Add(this.comboBoxUsers);
            this.groupBoxUsers.Location = new System.Drawing.Point(507, 59);
            this.groupBoxUsers.Name = "groupBoxUsers";
            this.groupBoxUsers.Size = new System.Drawing.Size(482, 68);
            this.groupBoxUsers.TabIndex = 2;
            this.groupBoxUsers.TabStop = false;
            this.groupBoxUsers.Text = "Users";
            // 
            // buttonSelectUser
            // 
            this.buttonSelectUser.Location = new System.Drawing.Point(365, 25);
            this.buttonSelectUser.Name = "buttonSelectUser";
            this.buttonSelectUser.Size = new System.Drawing.Size(111, 32);
            this.buttonSelectUser.TabIndex = 4;
            this.buttonSelectUser.Text = "Обрати";
            this.buttonSelectUser.UseVisualStyleBackColor = true;
            this.buttonSelectUser.Click += new System.EventHandler(this.buttonSelectUser_Click);
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelName.Location = new System.Drawing.Point(507, 28);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(482, 26);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Вітаю, ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.файлToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1375, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.changeUserNameToolStripMenuItem });
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // changeUserNameToolStripMenuItem
            // 
            this.changeUserNameToolStripMenuItem.Name = "changeUserNameToolStripMenuItem";
            this.changeUserNameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeUserNameToolStripMenuItem.Text = "Змінити ім\'я";
            this.changeUserNameToolStripMenuItem.Click += new System.EventHandler(this.changeUserNameToolStripMenuItem_Click);
            // 
            // buttonChangeFileStatus
            // 
            this.buttonChangeFileStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeFileStatus.Enabled = false;
            this.buttonChangeFileStatus.Location = new System.Drawing.Point(1175, 27);
            this.buttonChangeFileStatus.Name = "buttonChangeFileStatus";
            this.buttonChangeFileStatus.Size = new System.Drawing.Size(91, 56);
            this.buttonChangeFileStatus.TabIndex = 5;
            this.buttonChangeFileStatus.Text = "Змінити доступ";
            this.buttonChangeFileStatus.UseVisualStyleBackColor = true;
            this.buttonChangeFileStatus.Click += new System.EventHandler(this.buttonChangeFileStatus_Click);
            // 
            // Number
            // 
            this.Number.HeaderText = "№";
            this.Number.MinimumWidth = 70;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 70;
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.HeaderText = "Назва файлу";
            this.FileName.MinimumWidth = 100;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // FileWeight
            // 
            this.FileWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileWeight.HeaderText = "Вага файлу";
            this.FileWeight.MinimumWidth = 100;
            this.FileWeight.Name = "FileWeight";
            this.FileWeight.ReadOnly = true;
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilePath.HeaderText = "Путь";
            this.FilePath.MinimumWidth = 100;
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            // 
            // FileDataCreate
            // 
            this.FileDataCreate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileDataCreate.HeaderText = "Дата створення";
            this.FileDataCreate.MinimumWidth = 100;
            this.FileDataCreate.Name = "FileDataCreate";
            this.FileDataCreate.ReadOnly = true;
            // 
            // IsAvailable
            // 
            this.IsAvailable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsAvailable.HeaderText = "Доступний для передачі?";
            this.IsAvailable.MinimumWidth = 100;
            this.IsAvailable.Name = "IsAvailable";
            this.IsAvailable.ReadOnly = true;
            // 
            // buttonRemoveFile
            // 
            this.buttonRemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveFile.Enabled = false;
            this.buttonRemoveFile.Location = new System.Drawing.Point(1064, 28);
            this.buttonRemoveFile.Name = "buttonRemoveFile";
            this.buttonRemoveFile.Size = new System.Drawing.Size(105, 56);
            this.buttonRemoveFile.TabIndex = 6;
            this.buttonRemoveFile.Text = "Видалити файл";
            this.buttonRemoveFile.UseVisualStyleBackColor = true;
            this.buttonRemoveFile.Click += new System.EventHandler(this.buttonRemoveFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 761);
            this.Controls.Add(this.buttonRemoveFile);
            this.Controls.Add(this.buttonChangeFileStatus);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.groupBoxUsers);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxMode);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Text = "Files";
            this.groupBoxMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxUsers.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonRemoveFile;

        private System.Windows.Forms.Button buttonChangeFileStatus;

        private System.Windows.Forms.DataGridViewTextBoxColumn IsAvailable;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUserNameToolStripMenuItem;

        private System.Windows.Forms.Label labelName;

        private System.Windows.Forms.Button buttonSelectUser;

        private System.Windows.Forms.GroupBox groupBoxUsers;

        private System.Windows.Forms.ComboBox comboBoxUsers;

        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileDataCreate;

        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.RadioButton radioButtonClientFiles;
        private System.Windows.Forms.RadioButton radioButtonOtherFiles;
        private System.Windows.Forms.DataGridView dataGridView1;

        #endregion
    }
}