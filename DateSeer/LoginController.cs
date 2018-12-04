using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace DateSeer
{
    internal class LoginController
    {
        Thread th;
        Thread tr;
        private Login loginform;
        private Register regform;
        private Main mainpage;

        public LoginController(Login loginform)
        {
            this.loginform = loginform;
            loginform.Logins += () => LoginButtomPressed();
            loginform.Exit += () => Exit();
            loginform.Register += () => Register();
          
        }

        private void Register()
        {
            loginform.Dispose();
            regform = new Register();
            RegisterController reg = new RegisterController(regform); 
            th = new Thread(OpenRegister);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenRegister()
        {
            Application.Run(regform);
        }

        private void Exit()
        {
            Application.Exit();
        }

        private void LoginButtomPressed()
        {
            DataController dataController = new DataController(new DatabaseDataManager());
            if (loginform.UsernameTextBox.Text != "Username" && loginform.PasswordTextBox.Text != "Enter your password")
            {
                User loginUser = new User(loginform.UsernameTextBox.Text, loginform.PasswordTextBox.Text);
                //if (DAL.CompareToHash(loginUser) == true)
                if (new HashFunctions().CompareToHash(loginUser) == true)
                {
                    loginform.Dispose();
                    mainpage = new Main();
                    MainController main = new MainController(loginUser,mainpage);
                    th = new Thread(OpenMain);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                {
                    loginform.UsernameTextBox.ForeColor = Color.Silver;
                    loginform.PasswordTextBox.PasswordChar = '\0';
                    loginform.PasswordTextBox.ForeColor = Color.Silver;

                    loginform.UsernameTextBox.Text = "Username";
                    loginform.PasswordTextBox.Text = "Enter your password";
                    MessageBox.Show("Incorrect username or password");
                }
            }
            else
            {
                MessageBox.Show("Empty username or password field");
            }
        }

        private void OpenMain()
        {
            Application.Run(mainpage);
        }
    }
}