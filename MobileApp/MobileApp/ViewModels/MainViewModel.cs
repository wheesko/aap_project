using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using MobileApp.Models;

namespace MobileApp.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private string _Username;
        private string _Password;
        

        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;

                OnPropertyChanged();
            }
        }
        public string Password{
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(() =>
                {
                if(Username == "" || Password == "")
                {
                        Username = "";
                        Password = "";
                }
                    else
                    {
                        Login();
                    }

                });
            }
     
    }

        public void Login()
        {
            DataController dataController = new DataController(new DatabaseDataManager());
            User user = new User(Username, Password);
            if (new HashFunctions().CompareToHash(user) == true)
            {

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string prpertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prpertyName));
        }
    }
}
