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
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
            SignUpVM signUpObj = new SignUpVM();
            this.DataContext = signUpObj;

            txtUser.TextChanged += (sender, e) => signUpObj.CustomerData.Username = txtUser.Text;
            txtPassword.TextChanged += (sender, e) => signUpObj.CustomerData.Password = txtPassword.Text;
            txtFName.TextChanged += (sender, e) => signUpObj.CustomerData.FirstName = txtFName.Text;
            txtLName.TextChanged += (sender, e) => signUpObj.CustomerData.LastName = txtLName.Text;
            txtEmail.TextChanged += (sender, e) => signUpObj.CustomerData.Email = txtEmail.Text;
            txtAddress.TextChanged += (sender, e) => signUpObj.CustomerData.Address = txtAddress.Text;
        }
    }
}
