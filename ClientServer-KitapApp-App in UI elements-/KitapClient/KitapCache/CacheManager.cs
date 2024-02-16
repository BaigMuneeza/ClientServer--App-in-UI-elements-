using KitapClientMananger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KitapCache
{
    public class CacheManager
    {

        private static CacheManager _instance; //a static instance is declared.
        private Dictionary<string, object> _receivedData;

    
        private CacheManager()
        {

            ClientManager clientManager = new ClientManager();
            _receivedData = clientManager.GetDataFromServer();

        }


        public static CacheManager Instance
        {

            get
            {

                if (_instance == null)
                {
                    _instance = new CacheManager();
                }
                return _instance;

            }
        }

        public Dictionary<string, object> ReceivedData => _receivedData;

        public T GetCachedData<T>(string key) where T : class
        {
            if (_receivedData.ContainsKey(key))
            {
                return _receivedData[key] as T;
            }
            return null;
        }

        public void AddObjectToCache(string key, object value)
        {
            if (_receivedData.ContainsKey(key))
            {
                if (_receivedData[key] is IList list)
                {
                    list.Add(value);
                }
                else
                {
                    throw new InvalidOperationException($"The value stored under key '{key}' is not a list.");
                }
            }

        }
    }
}
