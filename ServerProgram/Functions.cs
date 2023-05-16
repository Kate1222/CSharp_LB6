using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace ServerProgram
{
    public class Functions
    {
        public void SerializeXML(List<string> userNames)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<string>));

            using (var fs = new FileStream("data//UserNames.xml", FileMode.Create))
                xmlSerializer.Serialize(fs, userNames);
        }

        public List<string> DeserializeXML()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<string>));
            
            using (var fs = new FileStream("data//UserNames.xml", FileMode.Open))
            {
                var deserializeUserNames = (List<string>)xmlSerializer.Deserialize(fs);
                return deserializeUserNames;
            }
        }
    }
}
