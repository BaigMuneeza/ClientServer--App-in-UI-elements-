using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitapRepositories;


namespace KitapFileManager
{
    public class FileManagerServer
    {

        public bool ProcessReceivedData(int enumKey, object receivedData)
        {
            try {

                switch (enumKey)
                {
                    case (int)DataReceived.Signup:

                        DataHandler.SignupData processor = new DataHandler.SignupData();
                        processor.ProcessSignUpData(receivedData);

                        break;


                    case (int)DataReceived.BookRequest:
                        Console.WriteLine("BookRequest");
                        break;


                    case (int)DataReceived.OrderInfo:
                        Console.WriteLine("OrderInfo");
                        break;


                    default:
                        Console.WriteLine("incorrect key ");
                        break;
                }


                return true;

            } 
            
            catch (Exception e) { 

                Console.WriteLine(e.ToString());
                return false;
            
            
            }
        }
        //public void ProcessReceivedData(int enumKey, List<Dictionary<string, string>> receivedData)
        //{
        //    switch (enumKey)
        //    {
        //        case (int)DataReceived.Signup:

        //            DataHandler.SignupData processor = new DataHandler.SignupData();
        //            processor.ProcessSignUpData(receivedData);

        //            break;


        //        case (int)DataReceived.BookRequest:
        //            Console.WriteLine("BookRequest");
        //            break;


        //        case (int)DataReceived.OrderInfo:
        //            Console.WriteLine("OrderInfo");
        //            break;


        //        default:
        //            Console.WriteLine("incorrect key ");
        //            break;
        //    }
        //}
    }
}
