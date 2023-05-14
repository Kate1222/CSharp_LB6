using System.IO;
using System.Text.Json;

namespace CSharp_LB6
{
    public class Functions
    {
        public string GetUserNameFromDialog()
        {
            var userNameDialog = new UserNameDialog();
            userNameDialog.ShowDialog();
            var userName = userNameDialog.userName;

            return userName;
        }
        
        public string GetUserName()
        {
            string userName;
            
            if (!File.Exists("username.json"))
            {
                userName = GetUserNameFromDialog();
                var saveUserNameJsonFile = JsonSerializer.Serialize(userName);
                File.WriteAllText("username.json", saveUserNameJsonFile);
            }
            else
            {
                var readUserNameJsonFile = File.ReadAllText("username.json");
                userName = JsonSerializer.Deserialize<string>(readUserNameJsonFile);
            }

            return userName;
        }
    }
}