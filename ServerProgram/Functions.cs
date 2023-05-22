using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServerProgram
{
    public class Functions
    {
        /*public string DeserializeJson(string path)
        {
            var result = string.Empty;

            if (!File.Exists(path)) return result;
            var readJson = File.ReadAllText(path);
            result = JsonSerializer.Deserialize<string>(readJson);

            return result;
        }
        
        public void SerializeXml(List<string> userNames)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<string>));

            using (var fs = new FileStream("data//UserNames.xml", FileMode.Create))
                xmlSerializer.Serialize(fs, userNames);
        }

        public List<string> DeserializeXml()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<string>));
            
            using (var fs = new FileStream("data//UserNames.xml", FileMode.Open))
            {
                var deserializeUserNames = (List<string>)xmlSerializer.Deserialize(fs);
                return deserializeUserNames;
            }
        }*/

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
    }
}
