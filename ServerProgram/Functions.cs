using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerProgram
{
    public class Functions
    {
        public async Task FunctionResponse(NetworkStream stream, string response)
        {
            var responseBuffer = Encoding.ASCII.GetBytes(response);
            await stream.WriteAsync(responseBuffer, 0, responseBuffer.Length);
        }

        public async Task<string> FunctionReceive(NetworkStream stream)
        {
            var resultBuffer = new byte[1024];
            var resultBytesRead = await stream.ReadAsync(resultBuffer, 0, resultBuffer.Length);
            return Encoding.ASCII.GetString(resultBuffer, 0, resultBytesRead);
        }
        
        public void SerializeXml(List<string> usersName)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<string>));

            using (var fs = new FileStream("data/Users.xml", FileMode.Create))
                xmlSerializer.Serialize(fs, usersName);
        }

        public List<string> DeserializeXml(string usersName)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<string>));
            
            using (var fs = new FileStream("data/" + usersName + "UserData.xml", FileMode.Open))
            {
                var deserializeUserFiles = (List<string>)xmlSerializer.Deserialize(fs);
                return deserializeUserFiles;
            }
        }
        
        internal void SendFile(NetworkStream stream, string filePath) 
        {
            // Send the file content to the server
            using (FileStream fileStream = File.OpenRead(filePath)) {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    stream.Write(buffer, 0, bytesRead);
            }
        }
    }
}
