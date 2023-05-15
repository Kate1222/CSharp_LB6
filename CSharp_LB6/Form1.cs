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
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            var newFile = _functions.SelectFile(true);
            if (newFile != null)
            {
                personalUserFiles.Add(newFile);
                _functions.UpdateDataGridView(dataGridView1, personalUserFiles);
            }
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
    }
}