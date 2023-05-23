using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                case "give usernames":
                {
                    if (!Directory.Exists("data"))
                    {
                        await _functions.FunctionResponse(stream, "Users not found");
                        Console.WriteLine("Users not found!");
                    }
                    else
                    {
                        // Get the list of files in the "data" directory
                        List<string> files = new List<string>(Directory.GetFiles(DataDirectory));

                        if (files.Count == 0 || files[0] == "Users.xml")
                            await _functions.FunctionResponse(stream, "Users not found");
                        else
                        {
                            // Send the list of files to the client
                            List<string> usersName =
                                (from file in files
                                    select Path.GetFileName(file)
                                    into fileName
                                    where fileName != "Users.xml"
                                    select fileName.Substring(0, fileName.Length - 12)).ToList();
                            _functions.SerializeXml(usersName);
                            Thread.Sleep(1000);
                            _functions.SendFile(stream, "data/Users.xml");
                            Thread.Sleep(1000);

                            Console.WriteLine("List send successful!");
                        }
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
