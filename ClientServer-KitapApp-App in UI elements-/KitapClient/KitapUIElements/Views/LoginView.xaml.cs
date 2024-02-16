using KitapUIElements.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KitapUIElements.Views
{

    public partial class LoginView : Page
    {
        public LoginView()
        {
            InitializeComponent();
            LoginVM loginObj = new LoginVM();
            this.DataContext = loginObj;


            txtUser.TextChanged += (sender, e) => loginObj.Customer.LoginUsername = txtUser.Text;
            txtPassowrd.TextChanged += (sender, e) => loginObj.Customer.LoginPassword = txtPassowrd.Text;
        }


        private void btnGoToSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUpVw = new SignUp();
            Application.Current.MainWindow.Content = signUpVw;
        }
    }
}
