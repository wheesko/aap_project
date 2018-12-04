using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace DateSeer
{
    internal class RegisterController
    {
        Thread th;
        private Login loginform;
        private Register regform;


        public RegisterController(Register regform)
        {
            this.regform = regform;
            regform.Registers += () => register();
            regform.Back += () => Back();
            regform.Exit += () => Exit();
        }
        public void Exit()
        {
            Application.Exit();
        }
        public void Back()
        {
            regform.Dispose();
            loginform = new Login();
            LoginController reg = new LoginController(loginform);
            th = new Thread(OpenLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void register()
        {
            var validationResult = new Validation().validateRegistrationForm(name: regform.textBox1.Text, username: regform.textBox3.Text, repeatedPass: regform.textBox5.Text, email: regform.textBox2.Text, gotAge: regform.dateTimePicker1.Value, female: regform.FemaleBox.Checked, male: regform.MaleBox.Checked, pass: regform.textBox4.Text);
            DataController dataController = new DataController(new DatabaseDataManager());
            if (validationResult == "")
            {
                int gender1 = 0;
                if (regform.MaleBox.Checked == true) { gender1 = 1; }
                if (regform.FemaleBox.Checked == true) { gender1 = 2; }
                User registeringUser = new User(regform.textBox3.Text, regform.textBox4.Text, regform.textBox2.Text, regform.textBox1.Text, regform.dateTimePicker1.Value.ToString(), gender1);
                try
                {
                    dataController.WriteData("AddUser", registeringUser);

                    regform.Dispose();
                    loginform= new Login();
                    LoginController reg = new LoginController(loginform);
                    th = new Thread(OpenLogin);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                catch (Exception ex)
                {

                    regform.textBox1.ForeColor = Color.Silver;
                    regform.textBox2.ForeColor = Color.Silver;
                    regform.textBox3.ForeColor = Color.Silver;
                    regform.textBox4.ForeColor = Color.Silver;
                    regform.textBox5.ForeColor = Color.Silver;

                    regform.textBox1.Text = "Enter your name";
                    regform.textBox2.Text = "Enter your email";
                    regform.textBox3.Text = "Enter your username";

                    regform.textBox4.PasswordChar = '\0';
                    regform.textBox5.PasswordChar = '\0';
                    regform.textBox4.Text = "Enter your password";
                    regform.textBox5.Text = "Repeat your password";

                    MessageBox.Show("Username or Email already taken");
                }
            }
            else
            {
                MessageBox.Show("Following errors occured: " + Environment.NewLine + validationResult);
            }
        }

        private void OpenLogin()
        {
            Application.Run(loginform);
        }
    }
}