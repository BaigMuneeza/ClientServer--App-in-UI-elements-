using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using KitapFileManager;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using KitapCacheManager;

namespace KitapServer
{
    public class ServerManager
    {
        private TcpListener server;


        //Construtor
        public ServerManager()
        {
            server = new TcpListener(IPAddress.Any, 8888);
        }

        //Start method for server
        public void Start()
        {
            server.Start();
            Console.WriteLine("Server started. Waiting for clients...");
            SendCacheData();
      
            while (true)
            {
                ListenForClientData();
            }
        }

        private Socket AcceptClientConnection()
        {
            return server.AcceptSocket();
        }

        private void SendCacheData()
        {
            try
            {
                Socket socketForClients = AcceptClientConnection();
                

                if (socketForClients.Connected)
                {
                    Console.WriteLine("Sending cache data...");
                    NetworkStream ns = new NetworkStream(socketForClients);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    // Read cache data from file
                    CacheManager cacheManager = new CacheManager();
                    Dictionary<string, object> cachedData = cacheManager.ReadCacheDataFromFile();

                    // Serialize and send the cache data to the client
                    binaryFormatter.Serialize(ns, cachedData);
                    Console.WriteLine("Cache Data sent to client.");

                    ns.Close();
                }
                socketForClients.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        private void ListenForClientData()
        {
            try
            {
                Socket socketForClients = AcceptClientConnection();

                if (socketForClients.Connected)
                {
                    Console.WriteLine("Client connected. Receiving data...");
                    NetworkStream ns = new NetworkStream(socketForClients);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    // Receive data from client
                    //List<Dictionary<string, string>> receivedData = (List<Dictionary<string, string>>)binaryFormatter.Deserialize(ns);

                    object receivedData = binaryFormatter.Deserialize(ns);
                    Console.WriteLine("Received data from client:");

                    //string enumKey = receivedData[0]["EnumKey"];
                    //int enumValue = int.Parse(enumKey);
                     int enumValue = 1;

                    FileManagerServer fileManager = new FileManagerServer();
                    bool Ack = fileManager. ProcessReceivedData(enumValue, receivedData);

                    // Sending acknowledgment back to the client
                    binaryFormatter.Serialize(ns, Ack);
                    Console.WriteLine("Ack sent to client.");

                    ns.Close();
                }
                socketForClients.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Thread.Sleep(1000);
        }


    }
}
