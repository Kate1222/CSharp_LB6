using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

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

        public UserFile SelectFile(bool openDialodAboutFile)
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
                
                //open save file
                if (openDialodAboutFile)
                {
                    var dialogAboutFile = new DialogAboutFile(newFile);
                    dialogAboutFile.ShowDialog();
                    newFile = dialogAboutFile.userFile;
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
    }
}
