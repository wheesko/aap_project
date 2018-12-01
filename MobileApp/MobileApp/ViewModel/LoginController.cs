using System;
using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Views;

namespace MobileApp
{
    public class LoginController
    {
        private LoginPage log;

        public User loginUser;
        public LoginController(LoginPage log)
        {
            this.log = log;
            log.Login += () => LoginAsync();
        }

        private async System.Threading.Tasks.Task LoginAsync()
        {
            DataController dataController = new DataController(new DatabaseDataManager());
            if (log.Username != null && log.Password != null)
            {
                loginUser = new User(log.Username, log.Password);
                if (new HashFunctions().CompareToHash(loginUser) == true)
                {           
                    log.SignIn(loginUser);
                }
            }
            else
            {
               await log.DisplayAlert("Ops", "Some fields are empty","Ok");
            }
        
        }
    }
}