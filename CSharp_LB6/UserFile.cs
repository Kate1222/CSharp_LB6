using System;

namespace CSharp_LB6
{
    public class UserFile
    {
        public string name { get; set; } = string.Empty;
        public long fileWeight { get; set; } = 0;
        public string path { get; set; } = string.Empty;
        public DateTime createDate { get; set; } = DateTime.MinValue;
        public bool isAvailable { get; set; } = false;
    }
}
