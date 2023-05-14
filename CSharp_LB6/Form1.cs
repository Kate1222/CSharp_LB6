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
        public Form1()
        {
            string userName;
            InitializeComponent();
            comboBoxUsers.Enabled = false;
            buttonSelectUser.Enabled = false;
            if (!File.Exists("username.json"))
            {
                var userNameDialog = new UserNameDialog();
                userNameDialog.ShowDialog();
                userName = userNameDialog.userName;
                var saveUserNameJsonFile = JsonSerializer.Serialize(userName);
                File.WriteAllText("username.json", saveUserNameJsonFile);
            }
            else
            {
                var readUserNameJsonFile = File.ReadAllText("username.json");
                userName = JsonSerializer.Deserialize<string>(readUserNameJsonFile);
            }

            labelName.Text = "Вітаю, " + userName;
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();
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
            UserNameDialog userNameDialog = new UserNameDialog();
            userNameDialog.ShowDialog();
        }
    }
}