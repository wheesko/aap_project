using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileApp.ViewModel
{
    public class RegisterViewModel
    {
        public Command RegisterCommand { get; }
        public Command BackCommand { get; }

        private RegistrationPage reg;
        public RegisterViewModel()
        {
            reg = RegistrationPage.instance;
            RegisterCommand = new Command(() => Register());
            BackCommand = new Command(() => Back());
        }

        private void Back()
        {
            reg.Navigation.PushModalAsync(new LoginPage(), true);
        }

        private void Register()
        {
            
        }
    }
}
