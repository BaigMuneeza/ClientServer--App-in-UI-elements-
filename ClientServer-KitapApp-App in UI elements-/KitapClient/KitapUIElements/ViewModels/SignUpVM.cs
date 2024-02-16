using KitapRepositories;
using KitapUIElements.Utilities;
using KitapUIElements.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using KitapClientMananger;
using KitapCache;

namespace KitapUIElements.ViewModels
{
    public class SignUpVM : ViewModelBase
    {
 
        private CustomerModel _customer;
        private TcpClient client;
        private ClientManager clientManager;

        
       // List<Dictionary<string, string>> CustomerSignupInfo = new List<Dictionary<string, string>>();

        public CustomerModel CustomerData
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(CustomerData));
            }
        }

        public ICommand SignUpCommand { get; }
        public SignUpVM()
        {
            _customer = new CustomerModel();
            clientManager = new ClientManager();
            SignUpCommand = new RelayCommand(ExecuteSignUpCommand, CanExecuteSignUpCommand);
        }


        private bool CanExecuteSignUpCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(CustomerData.Username) || string.IsNullOrWhiteSpace(CustomerData.FirstName) || string.IsNullOrWhiteSpace(CustomerData.LastName) || string.IsNullOrWhiteSpace(CustomerData.Email) || CustomerData.Address == null)
            {

                validData = false;

            }

            else
            {
                validData = true;
            }

            return validData;
        }
        private void ExecuteSignUpCommand(object obj)
        {


            string key = "CustomerModel";
            CacheManager cacheManager = Application.Current.Properties["CacheManager"] as CacheManager;


            if (cacheManager != null)
            {
                List<CustomerModel> loginData = cacheManager.GetCachedData<List<CustomerModel>>(key);
                


                    foreach (CustomerModel customerModel in loginData)
                    {
                        if (customerModel.Username == CustomerData.Username)
                        {
                            MessageBox.Show("Username already Taken. Try a new one");
                            return;
                        }
                    }


                    clientManager.SendObjToServer(CustomerData);
                    object Ack = clientManager.GetAckFromServer();


                    if (Ack is bool)
                    {
                            bool acknowledgment = (bool)Ack;

                            if (acknowledgment)
                            {
                                cacheManager.AddObjectToCache("CustomerModel", CustomerData);
                            }
                            else
                            {
                    
                                Console.WriteLine("Acknowledgment received from server: false");
                        
                            }
                    }


                    


                    LoginView loginView = new LoginView();
                    Application.Current.MainWindow.Content = loginView;
                    MessageBox.Show("Account Created " + CustomerData.FirstName);
                


            }

        }

    }
}
