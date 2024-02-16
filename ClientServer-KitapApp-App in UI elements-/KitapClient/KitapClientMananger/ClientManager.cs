using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KitapClientMananger
{

    public class ClientManager
    {

        private TcpClient client;


        public ClientManager()
        {
            client = new TcpClient("127.0.0.1", 8888);
        }

        public Dictionary<string, object> GetDataFromServer()
        {
            NetworkStream clientStream = client.GetStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (Dictionary<string, object>)binaryFormatter.Deserialize(clientStream);
        }

        public void SendObjToServer(object data)
        {
            NetworkStream clientStream = client.GetStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(clientStream, data);
        }

        public object GetAckFromServer()
        {
            NetworkStream clientStream = client.GetStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(clientStream);
        }

    }


}
