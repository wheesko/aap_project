using System;
using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Views;
using Xamarin.Forms;

namespace MobileApp
{
    internal class RegisterController
    {
        private RegistrationPage register;

        public RegisterController(RegistrationPage register)
        {
            this.register = register;
            register.RegisterPressed += () => RegisterAsync();

        }

        private async System.Threading.Tasks.Task RegisterAsync()
        {
            Picker Gender = new Picker();
            int mode = Gender.SelectedIndex;
            bool male;
            bool female;
            if (register.Gender.SelectedIndex == 0)
            {
                male = true;
                female = false;
            }
            else
            {
                male = false;
                female = true;
            }
            var validationResult = new Validation().validateRegistrationForm(name: register.Entry_name.Text, username: register.Entry_Username.Text, repeatedPass: register.Entry_PasswordRep.Text, email: register.Entry_Email.Text, gotAge: register.DatePicker.Date, female: female, male: male, pass: register.Entry_Password.Text);
            DataController dataController = new DataController(new DatabaseDataManager());
            if (validationResult == "")
            {

                
                User registeringUser = new User(register.Entry_Username.Text, register.Entry_Password.Text, register.Entry_Email.Text, register.Entry_name.Text, register.DatePicker.Date.ToString(), register.Gender.SelectedIndex++);
                try
                {
                    dataController.WriteData("AddUser", registeringUser);
                    //reik image padaryt kad ikeltu
                   
                }
                catch (Exception ex)
                {

                    register.Entry_name.Text = "";
                    register.Entry_Email.Text = "";
                    register.Entry_Password.Text = "";
                    register.Entry_PasswordRep.Text = "";
          


                }
            }
            else
            {
                await register.DisplayAlert("Ops", "Following errors occured: " + Environment.NewLine + validationResult,"Ok");
            }
        
    
    }
    }
}