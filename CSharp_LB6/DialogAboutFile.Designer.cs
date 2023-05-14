using System.ComponentModel;

namespace CSharp_LB6
{
    partial class DialogAboutFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxIsAvailable = new System.Windows.Forms.CheckBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelDataCreate = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonChooseAnother = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(138, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(151, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Вага:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(147, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Путь:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(47, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата створення:";
            // 
            // checkBoxIsAvailable
            // 
            this.checkBoxIsAvailable.Location = new System.Drawing.Point(209, 220);
            this.checkBoxIsAvailable.Name = "checkBoxIsAvailable";
            this.checkBoxIsAvailable.Size = new System.Drawing.Size(271, 32);
            this.checkBoxIsAvailable.TabIndex = 5;
            this.checkBoxIsAvailable.Text = "Доступний для відправки?";
            this.checkBoxIsAvailable.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(213, 60);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(267, 24);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Назва";
            // 
            // labelWeight
            // 
            this.labelWeight.Location = new System.Drawing.Point(213, 101);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(267, 24);
            this.labelWeight.TabIndex = 8;
            this.labelWeight.Text = "Вага";
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(213, 145);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(267, 24);
            this.labelPath.TabIndex = 9;
            this.labelPath.Text = "Путь";
            // 
            // labelDataCreate
            // 
            this.labelDataCreate.Location = new System.Drawing.Point(213, 186);
            this.labelDataCreate.Name = "labelDataCreate";
            this.labelDataCreate.Size = new System.Drawing.Size(267, 24);
            this.labelDataCreate.TabIndex = 10;
            this.labelDataCreate.Text = "Дата створення";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(74, 270);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(127, 57);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonChooseAnother
            // 
            this.buttonChooseAnother.Location = new System.Drawing.Point(207, 270);
            this.buttonChooseAnother.Name = "buttonChooseAnother";
            this.buttonChooseAnother.Size = new System.Drawing.Size(127, 57);
            this.buttonChooseAnother.TabIndex = 12;
            this.buttonChooseAnother.Text = "Обрати інший файл";
            this.buttonChooseAnother.UseVisualStyleBackColor = true;
            this.buttonChooseAnother.Click += new System.EventHandler(this.buttonChooseAnother_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(340, 270);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(127, 57);
            this.buttonCansel.TabIndex = 13;
            this.buttonCansel.Text = "Відмінити";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // DialogAboutFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonChooseAnother);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelDataCreate);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.checkBoxIsAvailable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 450);
            this.Name = "DialogAboutFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Інформація про файл";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonCansel;

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonChooseAnother;

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelDataCreate;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxIsAvailable;

        #endregion
    }
}