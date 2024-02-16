using KitapRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.SerializationMananger;

namespace KitapCacheManager
{
    public class CacheManager
    {
        string filePath = @"C:\DataFiles";
        private Dictionary<string, object> _cacheFiles;


        public Dictionary<string, object> CacheFiles
        {
            get { return _cacheFiles; }
            private set { _cacheFiles = value; }
        }

        public Dictionary<string, object> ReadCacheDataFromFile()
        {
            string filePath_signup = Path.Combine(filePath, "CustomerInformation.save");
            

            List<CustomerModel> customers = new List<CustomerModel>();


            if (File.Exists(filePath_signup))
            {

                customers = SerializationBase.DeserializeData<CustomerModel>(filePath_signup);               


                _cacheFiles = new Dictionary<string, object>();
                _cacheFiles.Add("CustomerModel", customers);
            }
            else
            {
                _cacheFiles = new Dictionary<string, object>();
            }

            return _cacheFiles;
        }

        //public Dictionary<string, object> ReadCacheDataFromFile()
        //{
        //    string filePath_signup = Path.Combine(filePath, "CustomerInformation.save");
        //    string filePath_login = Path.Combine(filePath, "LoginInformation.save");

        //    List<CustomerModel> customers = new List<CustomerModel>();
        //    List<LoginModel> loginData = new List<LoginModel>();


        //    if (File.Exists(filePath_signup) && File.Exists(filePath_login))
        //    {

        //        customers = SerializationBase.DeserializeData<CustomerModel>(filePath_signup);
        //        loginData = SerializationBase.DeserializeData<LoginModel>(filePath_login);


        //        _cacheFiles = new Dictionary<string, object>();
        //        _cacheFiles.Add("CustomerModel", customers);
        //        _cacheFiles.Add("LoginModel", loginData);
        //    }
        //    else
        //    {
        //        _cacheFiles = new Dictionary<string, object>();
        //    }

        //    return _cacheFiles;
        //}
    }
}
