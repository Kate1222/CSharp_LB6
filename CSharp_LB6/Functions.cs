using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CSharp_LB6
{
    public class Functions
    {
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
                    newFile = null;
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

        public void SerializeXML(List<UserFile> userFiles)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<UserFile>));

            using (var fs = new FileStream("UserData.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, userFiles);
            }
        }

        public List<UserFile> DeserializeXML()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<UserFile>));
            
            using (var fs = new FileStream("UserData.xml", FileMode.Open))
            {
                var deserializeUserFiles = (List<UserFile>)xmlSerializer.Deserialize(fs);
                return deserializeUserFiles;
            }
        }

        /*internal void LinkToServer()
        {
            while (true)
            {
                
            }
        }*/
    }
}
