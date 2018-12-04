using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public Action Register = delegate { };
        public Action<User> SignIn = delegate { };
        public Action Login = delegate { };

        public string Username { get { return Entry_Username.Text; } set { Entry_Username.Text = value; } }
        public string Password { get { return Entry_Password.Text; } set { Entry_Password.Text = value; } }

        public static LoginPage instance;
		public LoginPage ()
		{
            instance = this;
           
            InitializeComponent ();  
		}
        private void Btn_SignIn_Clicked_1(object sender, EventArgs e)
        {
            Login();
        }

        private void Btn_Register_Clicked_1(object sender, EventArgs e)
        {
            Register();
        }
    }
}