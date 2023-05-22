using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
    }
}
