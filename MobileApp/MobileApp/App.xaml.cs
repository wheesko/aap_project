using System;
using MobileApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileApp
{
    public partial class App : Application
    {
        public static App instance;

        public App()
        {
            instance = this;
            InitializeComponent();
            RegistrationPage e = new RegistrationPage();
            RegisterController f = new RegisterController(e);
            MainPage = e;
            //StateController stateController = new StateController(this);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
