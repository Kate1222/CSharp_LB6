using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerProgram
{
    internal abstract class Program {
        private static void Main() {
            TcpListener listener = new TcpListener( IPAddress.Parse("192.168.31.202"), 1234);
            listener.Start();
            Console.WriteLine("Server started on port 1234");

            while (true) {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");

                NetworkStream stream = client.GetStream();

                // Receive the file name from the client
                byte[] fileNameBuffer = new byte[1024];
                int fileNameBytesRead = stream.Read(fileNameBuffer, 0, fileNameBuffer.Length);
                string fileName = Encoding.ASCII.GetString(fileNameBuffer, 0, fileNameBytesRead);
                Console.WriteLine("Receiving file: " + fileName);

                // Create a file stream to save the received file
                FileStream fileStream = File.Create(fileName);

                // Receive the file content from the client and save it to the file stream
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) {
                    fileStream.Write(buffer, 0, bytesRead);
                }

                fileStream.Close();
                client.Close();
                Console.WriteLine("File received and saved successfully");
            }
        }
    }
}