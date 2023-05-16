using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CSharp_LB6
{
    public class Functions
    {
        private string serverIP = "192.168.31.202";
        
        public string GetUserNameFromDialog()
        {
            var userNameDialog = new UserNameDialog();
            userNameDialog.ShowDialog();
            var userName = userNameDialog.userName;
            
            SaveToJson(userName);
            
            return userName;
        }
        
        public string GetUserName()
        {
            string userName;
            
            if (!File.Exists("username.json"))
            {
                userName = GetUserNameFromDialog();
                SaveToJson(userName);
            }
            else
            {
                var readUserNameJsonFile = File.ReadAllText("username.json");
                userName = JsonSerializer.Deserialize<string>(readUserNameJsonFile);
            }

            return userName;
        }

        private static void SaveToJson(string userName)
        {
            var saveUserNameJsonFile = JsonSerializer.Serialize(userName);
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");
            File.WriteAllText("username.json", saveUserNameJsonFile);
        }

        public UserFile SelectFile(bool openDialodAboutFile, List<UserFile> userFiles)
        {
            var newFile = new UserFile();
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fInfo = new FileInfo(openFileDialog.FileName);
                newFile.name = fInfo.Name;
                newFile.fileWeight = fInfo.Length;
                newFile.path = fInfo.DirectoryName;
                newFile.createDate = fInfo.CreationTime;

                var findUserFile = userFiles.Find(x => x.name.Equals(newFile.name) && x.path.Equals(newFile.path));
                if (findUserFile == null)
                {
                    //open save file
                    if (openDialodAboutFile)
                    {
                        var dialogAboutFile = new DialogAboutFile(newFile, userFiles);
                        dialogAboutFile.ShowDialog();
                        newFile = dialogAboutFile.userFile;
                    }
                }
                else
                {
                    MessageBox.Show("Цей файл вже доданий до списку!", "Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    newFile = new UserFile();
                }
            }

            return newFile;
        }

        internal void UpdateDataGridView(DataGridView dataGridView, List<UserFile> userFiles)
        {
            dataGridView.Rows.Clear();
            for (var i = 0; i < userFiles.Count; i++)
            {
                string sighn;
                if (userFiles[i].isAvailable)
                    sighn = "+";
                else
                    sighn = "-";
                dataGridView.Rows.Add(i + 1, userFiles[i].name, userFiles[i].fileWeight / 1000000 + " мб.",
                    userFiles[i].path, userFiles[i].createDate, sighn);
            }
        }

        public void SerializeXML(List<UserFile> userFiles, string userName)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<UserFile>));

            using (var fs = new FileStream(userName + "UserData.xml", FileMode.Create))
                xmlSerializer.Serialize(fs, userFiles);
        }

        public List<UserFile> DeserializeXML(string userName)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<UserFile>));
            
            using (var fs = new FileStream(userName + "UserData.xml", FileMode.Open))
            {
                var deserializeUserFiles = (List<UserFile>)xmlSerializer.Deserialize(fs);
                return deserializeUserFiles;
            }
        }

        internal string LinkToServer()
        {
            string result;
            try
            {
                TcpClient client = new TcpClient(serverIP, 1234);
                result = "Online";
            }
            catch
            {
                result = "Offline";
            }

            return result;
        }

        internal void SendFilesInfo(string userName)
        {
            TcpClient client = new TcpClient(serverIP, 1234);

            NetworkStream stream = client.GetStream();

            // Send the file name to the server
            string filePath = userName + "UserData.xml";
            var fileName = Path.GetFileName(filePath);
            var fileNameBuffer = Encoding.ASCII.GetBytes(fileName);
            Thread.Sleep(2);
            stream.Write(fileNameBuffer, 0, fileNameBuffer.Length);

            // Send the file content to the server
            using (var fileStream = File.OpenRead(filePath)) {
                var buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0) {
                    stream.Write(buffer, 0, bytesRead);
                }
            }

            client.Close();
        }
    }
}
