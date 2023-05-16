using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram
{
    internal abstract class Server {
        static List<TcpClient> clients = new List<TcpClient>();

        private static async Task Main() {
            var listener = new TcpListener(IPAddress.Parse("192.168.31.202"), 1234);
            listener.Start();
            Console.WriteLine("Server started on port 1234");

            while (true) {
                var client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                Console.WriteLine("Client connected");

                _ = HandleClientAsync(client);
            }
        }

        private static async Task HandleClientAsync(TcpClient client) {
            var stream = client.GetStream();

            // Receive the file name from the client
            var fileNameBuffer = new byte[1024];
            var fileNameBytesRead = await stream.ReadAsync(fileNameBuffer, 0, fileNameBuffer.Length);
            var fileName = Encoding.ASCII.GetString(fileNameBuffer, 0, fileNameBytesRead);
            Console.WriteLine("Receiving file: " + fileName);
            
            if (File.Exists(fileName))
                File.Delete(fileName);

            // Create a file stream to save the received file
            var fileStream = File.Create(fileName);

            // Receive the file content from the client and save it to the file stream
            var buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0) {
                await fileStream.WriteAsync(buffer, 0, bytesRead);
            }

            fileStream.Close();
            client.Close();
            clients.Remove(client);
            Console.WriteLine("File received and saved successfully");
        }
    }
}