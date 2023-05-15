using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSharp_LB6
{
    public partial class Form1 : Form
    {
        private Functions _functions = new Functions();
        private List<UserFile> personalUserFiles;

        public Form1()
        {
            var userName = _functions.GetUserName();
            personalUserFiles = new List<UserFile>();

            InitializeComponent();
            comboBoxUsers.Enabled = false;
            buttonSelectUser.Enabled = false;
            
            labelName.Text = "Вітаю, " + userName;
            
            
            if (File.Exists("UserData.xml"))
            {
                personalUserFiles = _functions.DeserializeXML();
                if (personalUserFiles.Count > 0)
                {
                    _functions.UpdateDataGridView(dataGridView1, personalUserFiles);
                    buttonChangeFileStatus.Enabled = true;
                    buttonRemoveFile.Enabled = true;
                    buttonRemoveFile.Enabled = true;
                }
            }
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            var newFile = _functions.SelectFile(true, personalUserFiles);
            if (newFile != null)
            {
                personalUserFiles.Add(newFile);
                _functions.UpdateDataGridView(dataGridView1, personalUserFiles);
                buttonChangeFileStatus.Enabled = true;
                buttonRemoveFile.Enabled = true;
            }
            _functions.SerializeXML(personalUserFiles);
        }

        private void radioButtonClientFiles_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Enabled = false;
            buttonSelectUser.Enabled = false;
        }

        private void radioButtonOtherFiles_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Enabled = true;
            buttonSelectUser.Enabled = true;
        }

        private void buttonSelectUser_Click(object sender, EventArgs e)
        {
            /*var dialogAboutFile = new DialogAboutFile();
            dialogAboutFile.ShowDialog();*/
        }

        private void changeUserNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userName = _functions.GetUserNameFromDialog();
            labelName.Text = "Вітаю, " + userName;
        }

        private void buttonChangeFileStatus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex == personalUserFiles.Count)
                MessageBox.Show("Неправильно обраний індекс!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var dialogChangeAccessFile =
                    new DialogChangeAccessFile(personalUserFiles, dataGridView1.CurrentCell.RowIndex);
                dialogChangeAccessFile.ShowDialog();
                _functions.UpdateDataGridView(dataGridView1, personalUserFiles);
                _functions.SerializeXML(personalUserFiles);
            }
        }

        private void buttonRemoveFile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex == personalUserFiles.Count)
                MessageBox.Show("Неправильно обраний індекс!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult mb = MessageBox.Show("Ви дійсно бажаєте видалити цей файл?", "Question?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mb == DialogResult.Yes)
                {
                    personalUserFiles.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                    _functions.UpdateDataGridView(dataGridView1, personalUserFiles);
                    if (personalUserFiles.Count == 0)
                    {
                        buttonRemoveFile.Enabled = false;
                        buttonChangeFileStatus.Enabled = false;
                    }
                    _functions.SerializeXML(personalUserFiles);
                }
            }
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}