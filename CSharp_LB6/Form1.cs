using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CSharp_LB6
{
    public partial class Form1 : Form
    {
        private static Functions _functions = new Functions();
        private List<UserFile> personalUserFiles;
        private List<string> usersName;
        private string serverStatus = "unknown";
        //private string serverStatus = "Online";
        private Thread threadCheckStatusServer;
        private static string userName;
        
        
        
        private void StartLinkToServer()
        {
            while (true)
            {
                serverStatus = _functions.LinkToServer();
                labelServerStatus.Text = "Server status: " + serverStatus;
                Thread.Sleep(120000);
            }
        }

        private static void StartSendFileInfo()
        {
             _functions.SendFilesInfo(userName);
        }

        public Form1()
        {
            userName = _functions.GetUserName();
            personalUserFiles = new List<UserFile>();

            InitializeComponent();
            comboBoxUsers.Enabled = false;
            buttonSelectUser.Enabled = false;
            
            labelName.Text = "Вітаю, " + userName;
            
            
            if (File.Exists(userName + "UserData.xml"))
            {
                personalUserFiles = _functions.DeserializeXML(userName);
                if (personalUserFiles.Count > 0)
                {
                    _functions.UpdateDataGridView(dataGridView1, personalUserFiles);
                    buttonChangeFileStatus.Enabled = true;
                    buttonRemoveFile.Enabled = true;
                    buttonRemoveFile.Enabled = true;
                }
            }

            ThreadStart threadStartLinkToServer = (StartLinkToServer);
            threadCheckStatusServer = new Thread(threadStartLinkToServer);
            threadCheckStatusServer.Start();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            var newFile = _functions.SelectFile(true, personalUserFiles);
            if (newFile.name != string.Empty)
            {
                personalUserFiles.Add(newFile);
                _functions.UpdateDataGridView(dataGridView1, personalUserFiles);
                buttonChangeFileStatus.Enabled = true;
                buttonRemoveFile.Enabled = true;
                
                _functions.SerializeXML(personalUserFiles, userName);
                
                ThreadStart sendDataFile = new ThreadStart(StartSendFileInfo);
                Thread threadSendDataFile = new Thread(sendDataFile);
                threadSendDataFile.Start();
                //StartSendFileInfo();
            }
        }

        private void radioButtonClientFiles_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxUsers.Enabled = false;
            buttonSelectUser.Enabled = false;
            _functions.UpdateDataGridView(dataGridView1, personalUserFiles);
        }

        private void radioButtonOtherFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (serverStatus == "Offline" || serverStatus == "unknown")
            {
                MessageBox.Show("Зараз сервер недоступний!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButtonClientFiles.Checked = true;
            }
            else
            {
                comboBoxUsers.Enabled = true;
                buttonSelectUser.Enabled = true;
                dataGridView1.Rows.Clear();
            }
        }

        private void buttonSelectUser_Click(object sender, EventArgs e)
        {
            /*var dialogAboutFile = new DialogAboutFile();
            dialogAboutFile.ShowDialog();*/
        }

        private void changeUserNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userName = _functions.GetUserNameFromDialog();
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
                _functions.SerializeXML(personalUserFiles, userName);
                
                ThreadStart sendDataFile = new ThreadStart(StartSendFileInfo);
                Thread threadSendDataFile = new Thread(sendDataFile);
                threadSendDataFile.Start();
                //StartSendFileInfo();
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
                    _functions.SerializeXML(personalUserFiles, userName);
                    ThreadStart sendDataFile = new ThreadStart(StartSendFileInfo);
                    Thread threadSendDataFile = new Thread(sendDataFile);
                    threadSendDataFile.Start();
                    //StartSendFileInfo();
                }
            }
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadCheckStatusServer.Abort();
        }
    }
}
