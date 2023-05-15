using System.ComponentModel;

namespace CSharp_LB6
{
    partial class DialogChangeAccessFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.labelFileName = new System.Windows.Forms.Label();
            this.checkBoxFileStatus = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFileName
            // 
            this.labelFileName.Location = new System.Drawing.Point(82, 85);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(281, 32);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "label";
            // 
            // checkBoxFileStatus
            // 
            this.checkBoxFileStatus.Location = new System.Drawing.Point(82, 120);
            this.checkBoxFileStatus.Name = "checkBoxFileStatus";
            this.checkBoxFileStatus.Size = new System.Drawing.Size(281, 42);
            this.checkBoxFileStatus.TabIndex = 1;
            this.checkBoxFileStatus.Text = "Доступний для відправки?";
            this.checkBoxFileStatus.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(163, 168);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(124, 35);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // DialogChangeAccessFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 255);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkBoxFileStatus);
            this.Controls.Add(this.labelFileName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogChangeAccessFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogChangeAccessFile";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonSave;

        private System.Windows.Forms.CheckBox checkBoxFileStatus;

        private System.Windows.Forms.Label labelFileName;

        #endregion
    }
}