using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CSharp_LB6
{
    public partial class Form1 : Form
    {
        //private static Functions _functions = new Functions();
        private static List<UserFile> _personalUserFiles;
        private List<string> _otherUsersName;
        private string _serverStatus = "unknown";
        //private string _serverStatus = "Online";
        private readonly Thread _threadCheckStatusServer;
        private static string _userName;
        private static string _oldUserName;
        
        private void StartLinkToServer()
        {
            while (true)
            {
                _serverStatus = Functions.LinkToServer();
                labelServerStatus.Text = "Server status: " + _serverStatus;
                Thread.Sleep(120000);
            }
        }

        private static void StartSendFileInfo()
        {
            Functions.SendFileToServer(_userName);
            Thread.Sleep(2000);
        }

        private static void StartChangeFiles()
        {
            Functions.ChangeFiles(_oldUserName, _userName, _personalUserFiles);
        }

        public Form1()
        {
            _userName = Functions.GetUserName();
            _personalUserFiles = new List<UserFile>();

            InitializeComponent();
            comboBoxUsers.Enabled = false;
            buttonSelectUser.Enabled = false;
            
            labelName.Text = "Вітаю, " + _userName;
            
            
            if (File.Exists("data/" + _userName + "UserData.xml"))
            {
                _personalUserFiles = Functions.DeserializeXmlPersonalUserData(_userName);
                if (_personalUserFiles.Count > 0)
                {
                    Functions.UpdateDataGridView(dataGridView1, _personalUserFiles);
                    buttonChangeFileStatus.Enabled = true;
                    buttonRemoveFile.Enabled = true;
                    buttonRemoveFile.Enabled = true;
                }
            }

            ThreadStart threadStartLinkToServer = (StartLinkToServer);
            _threadCheckStatusServer = new Thread(threadStartLinkToServer);
            _threadCheckStatusServer.Start();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            var newFile = Functions.SelectFile(true, _personalUserFiles);
            if (newFile.name != string.Empty)
            {
                _personalUserFiles.Add(newFile);
                Functions.UpdateDataGridView(dataGridView1, _personalUserFiles);
                buttonChangeFileStatus.Enabled = true;
                buttonRemoveFile.Enabled = true;
                
                Functions.SerializeXmlPersonalUserData(_personalUserFiles, _userName);
                
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
            Functions.UpdateDataGridView(dataGridView1, _personalUserFiles);
        }

        private void radioButtonOtherFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (_serverStatus == "Offline" || _serverStatus == "unknown")
            {
                MessageBox.Show("Зараз сервер недоступний!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioButtonClientFiles.Checked = true;
            }
            else
            {
                comboBoxUsers.Enabled = true;
                buttonSelectUser.Enabled = true;
                dataGridView1.Rows.Clear();
                
                _otherUsersName = Functions.GetOtherUsersName();
                var findUserName = _otherUsersName.Find(un => un.Equals(_userName));
                if (findUserName != null)
                    _otherUsersName.Remove(_userName);
                comboBoxUsers.DataSource = _otherUsersName;
                buttonAddFile.Enabled = false;
                buttonRemoveFile.Enabled = false;
                buttonChangeFileStatus.Enabled = false;
            }
        }

        private void buttonSelectUser_Click(object sender, EventArgs e)
        {
            /*var dialogAboutFile = new DialogAboutFile();
            dialogAboutFile.ShowDialog();*/
        }

        private void changeUserNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_otherUsersName == null)
            {
                _otherUsersName = Functions.GetOtherUsersName();
                var findUserName = _otherUsersName.Find(un => un.Equals(_userName));
                if (findUserName != null)
                    _otherUsersName.Remove(_userName);
            }

            _oldUserName = _userName;
            while (true)
            {
                string tempUserName = Functions.GetUserNameFromDialog();
                bool check = Functions.CheckNameRepeat(_otherUsersName, tempUserName);

                if (check)
                    MessageBox.Show("Це ім'я вже використовується! Оберіть інше!", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                {
                    _userName = tempUserName;
                    break;
                }
            }

            if (_userName != _oldUserName)
            {
                labelName.Text = "Вітаю, " + _userName;
                Functions.SerializeXmlPersonalUserData(_personalUserFiles, _userName);
                ThreadStart startChangeFiles = new ThreadStart(StartChangeFiles);
                Thread threadChangeFiles = new Thread(startChangeFiles);
                threadChangeFiles.Start();
                //StartChangeFiles();
            }
        }

        private void buttonChangeFileStatus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex == _personalUserFiles.Count)
                MessageBox.Show("Неправильно обраний індекс!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var dialogChangeAccessFile =
                    new DialogChangeAccessFile(_personalUserFiles, dataGridView1.CurrentCell.RowIndex);
                dialogChangeAccessFile.ShowDialog();
                Functions.UpdateDataGridView(dataGridView1, _personalUserFiles);
                Functions.SerializeXmlPersonalUserData(_personalUserFiles, _userName);
                
                ThreadStart sendDataFile = new ThreadStart(StartSendFileInfo);
                Thread threadSendDataFile = new Thread(sendDataFile);
                threadSendDataFile.Start();
            }
        }

        private void buttonRemoveFile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex == _personalUserFiles.Count)
                MessageBox.Show("Неправильно обраний індекс!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult mb = MessageBox.Show("Ви дійсно бажаєте видалити цей файл?", "Question?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mb == DialogResult.Yes)
                {
                    _personalUserFiles.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                    Functions.UpdateDataGridView(dataGridView1, _personalUserFiles);
                    if (_personalUserFiles.Count == 0)
                    {
                        buttonRemoveFile.Enabled = false;
                        buttonChangeFileStatus.Enabled = false;
                    }
                    Functions.SerializeXmlPersonalUserData(_personalUserFiles, _userName);
                    ThreadStart sendDataFile = new ThreadStart(StartSendFileInfo);
                    Thread threadSendDataFile = new Thread(sendDataFile);
                    threadSendDataFile.Start();
                }
            }
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _threadCheckStatusServer.Abort();
        }
    }
}
