using KitapRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.SerializationMananger;

namespace KitapFileManager.DataHandler
{
    public class SignupData
    {
        string filePath = @"C:\DataFiles";

        public void ProcessSignUpData(object receivedData)
        {
            string filePath_signup = Path.Combine(filePath, "CustomerInformation.save");

            List<CustomerModel> customers = new List<CustomerModel>(); 


            if (File.Exists(filePath_signup))
            {
                //reads from the existing file 
                customers = SerializationBase.DeserializeData<CustomerModel>(filePath_signup);
                
            }

            if (receivedData is CustomerModel customer)
            {
                customers.Add(customer);

            }


            //writes the list of records back to the file
            SerializationBase.SerializeData(filePath_signup, customers);
            Console.WriteLine("Employee data saved to file.");
        }
        //public void ProcessSignUpData(object receivedData)
        //{
        //    string filePath_signup = Path.Combine(filePath, "CustomerInformation.save");
        //    string filePath_login = Path.Combine(filePath, "LoginInformation.save");

        //    List<CustomerModel> customers = new List<CustomerModel>();
        //    List<LoginModel> loginData = new List<LoginModel>();


        //    if (File.Exists(filePath_signup) && File.Exists(filePath_login))
        //    {
        //        //reads from the existing file 
        //        customers = SerializationBase.DeserializeData<CustomerModel>(filePath_signup);
        //        loginData = SerializationBase.DeserializeData<LoginModel>(filePath_login);
        //    }

        //    if (receivedData is CustomerModel customer)
        //    {

        //        LoginModel login = new LoginModel() { LoginUsername = customer.Username, LoginPassword = customer.Password };
        //        customers.Add(customer);
        //        loginData.Add(login);

        //    }


        //        //writes the list of records back to the file
        //    SerializationBase.SerializeData(filePath_signup, customers);
        //    SerializationBase.SerializeData(filePath_login, loginData);
        //    Console.WriteLine("Employee data saved to file.");
        //}
    }
}
