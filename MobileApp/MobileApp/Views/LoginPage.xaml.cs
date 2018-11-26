using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public static LoginPage instance;
		public LoginPage ()
		{
            instance = this;
            InitializeComponent ();
            BindingContext = new ViewModel.LoginViewModel();
		}   
    }
}