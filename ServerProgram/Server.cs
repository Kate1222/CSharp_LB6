using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerProgram
{
    internal abstract class Program {
        private static readonly string DataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "data");
        private static readonly Functions _functions = new Functions();
        
        private static async Task Main() {
            TcpListener listener = new TcpListener(IPAddress.Parse("192.168.31.99"), 1111);
            listener.Start();
            Console.WriteLine("Server started on port 1111");

            while (true) {
                TcpClient client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected");

                _ = HandleClientAsync(client);
            }
        }

        private static async Task HandleClientAsync(TcpClient client) {
            NetworkStream stream = client.GetStream();

            // Receive the request from the client
            var request = await _functions.FunctionReceive(stream);
            Console.WriteLine("Received request: " + request);

            switch (request)
            {
                case "send":
                {
                    // Receive the file name from the client
                    string fileName = await _functions.FunctionReceive(stream);
                    Console.WriteLine("Receiving file: " + fileName);
                    Thread.Sleep(150);

                    // Create a file stream to save the received file
                    string filePath = Path.Combine(DataDirectory, fileName);

                    if (!Directory.Exists("data"))
                        Directory.CreateDirectory("data");
            
                    FileStream fileStream = File.Create(filePath);

                    // Receive the file content from the client and save it to the file stream
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0) {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                    }

                    fileStream.Close();
                    Console.WriteLine("File received and saved successfully");
                    break;
                }
                case "get":
                {
                    // Receive the file name to send from the client
                    string fileName = await _functions.FunctionReceive(stream);
                    Console.WriteLine("Requested file: " + fileName);

                    string filePath = Path.Combine(DataDirectory, fileName);

                    // Send an error response to the client
                    if (!Directory.Exists("data"))
                        await _functions.FunctionResponse(stream, "File not found");
                    else
                    {
                        if (File.Exists(filePath))
                        {
                            // Send the file name to the client
                            byte[] responseBuffer = Encoding.ASCII.GetBytes(fileName);
                            await stream.WriteAsync(responseBuffer, 0, responseBuffer.Length);

                            // Send the file content to the client
                            using (FileStream fileStream = File.OpenRead(filePath))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    await stream.WriteAsync(buffer, 0, bytesRead);
                                }
                            }

                            Console.WriteLine("File sent successfully");
                        }
                        // Send an error response to the client
                        else
                            await _functions.FunctionResponse(stream, "File not found");
                    }

                    break;
                }
                case "give files" when !Directory.Exists("data"):
                {
                    // Send an error response to the client
                    await _functions.FunctionResponse(stream, "Files not found");
                    Console.WriteLine("Files not found!");
                    break;
                }
                case "give files":
                {
                    // Get the list of files in the "data" directory
                    List<string> files = new List<string>(Directory.GetFiles(DataDirectory));
                    
                    if (files.Count == 0)
                        await _functions.FunctionResponse(stream, "Files not found");
                    else
                    {
                        // Send the list of files to the client
                        await _functions.FunctionResponse(stream, "List of files on the server:");

                        foreach (var file in files)
                        {
                            Thread.Sleep(50);
                            var fileName = Path.GetFileName(file);
                            var fileNameBuffer = Encoding.ASCII.GetBytes(fileName);
                            await stream.WriteAsync(fileNameBuffer, 0, fileNameBuffer.Length);
                            Thread.Sleep(50);
                        }

                        Console.WriteLine("List send successful!");
                    }

                    break;
                }
                case "remove file":
                {
                    string fileName = await _functions.FunctionReceive(stream);
                    Console.WriteLine("Requested file: " + fileName);

                    string filePath = Path.Combine(DataDirectory, fileName);
                    if (!File.Exists(filePath))
                        await _functions.FunctionResponse(stream, "File not found");
                    else
                    {
                        File.Delete(filePath);
                        await _functions.FunctionResponse(stream, "Success!");
                        Console.WriteLine("Success delete!");
                    }
                    
                    break;
                }
            }
            client.Close();
            Console.WriteLine("Client disconnected");
        }
    }
}
