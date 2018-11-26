using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Views;
using Xamarin.Forms;

namespace MobileApp.ViewModel
{
    public class LoginViewModel : ContentPage
    {
        private LoginPage log;

        public string Username {  set => _username = value; }
        public string Password {  set => _password = value; }

        private string _username;
        private string _password;

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
            public LoginViewModel()
        {
            log = LoginPage.instance;
            LoginCommand = new Command(() => LoginAsync());
            RegisterCommand = new Command(() => Register());
           
        }

        private void Register()
        {
            log.Navigation.PushModalAsync(new RegistrationPage(), false);
        }

        private void LoginAsync()
        {
            if (_username is null && _password is null)
            {
                DisplayAlertAsync("Some fields are empty");
            }
            else
            {
                User LogUser = new User(_username, _password);
                DataController dataController = new DataController(new DatabaseDataManager());
                if (new HashFunctions().CompareToHash(LogUser) == true)
                {
                    log.Navigation.PushModalAsync(new MainPage(), false);
                }
            }

        }
        private async System.Threading.Tasks.Task DisplayAlertAsync(string message)
        {
           await log.DisplayAlert("Something wrong",message,"Ok");
           
        }
    }
}
