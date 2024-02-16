using System;
using KitapUIElements.Views;
using KitapUIElements.Utilities;
using System.Collections.Generic;
using KitapRepositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using KitapCache;

namespace KitapUIElements.ViewModels
{
    public class LoginVM : ViewModelBase
    {
        private LoginModel _customer;

        public LoginModel Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }


        public ICommand LoginCommand { get; }
        public LoginVM()
        {
            _customer = new LoginModel();
            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }


        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Customer.LoginUsername) || string.IsNullOrWhiteSpace(Customer.LoginPassword))
            {
                
                validData = false;

            }

            else
            {
                validData = true;
            }

            return validData;
        }
        private void ExecuteLoginCommand(object obj)
        {

            string key = "CustomerModel";
            CacheManager cacheManager = Application.Current.Properties["CacheManager"] as CacheManager;
           

            if (cacheManager != null)
            {

                List<CustomerModel> loginData = cacheManager.GetCachedData<List<CustomerModel>>(key);


                        foreach (CustomerModel customerModel in loginData)
                        {

                            if (customerModel.Username == Customer.LoginUsername && customerModel.Password == Customer.LoginPassword)
                            {

                                MessageBox.Show("Login successful!" + Customer.LoginUsername);
                                //Dashboard DashboardView = new Dashboard();
                                //Application.Current.MainWindow.Content = DashboardView;
                                return;
                            }
                        }

                        MessageBox.Show("Invalid username or password, Try again or Sign up!");                  


            }


        }


    }
}
