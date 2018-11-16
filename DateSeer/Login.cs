using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace DateSeer
{
    public partial class Login : Form,LoginForm
    {
      

        public Action Logins { get => LoginButtomClicked; set => LoginButtomClicked = value; }
        public Action Register { get => RegisterPressed; set => RegisterPressed = value; }
        public Action Exit { get => ExitPressed; set => ExitPressed = value; }
        public Action facebook { get => FacebookPressed; set => FacebookPressed = value; }

        private Action LoginButtomClicked = delegate { };
        private Action ExitPressed = delegate { };
        private Action RegisterPressed = delegate { };
        private Action FacebookPressed = delegate { };

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginButtomClicked();
        }

        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            UsernameTextBox.ForeColor = Color.Black;
            if (UsernameTextBox.Text == "Username")
            {

                UsernameTextBox.Text = "";
                UsernameTextBox.ForeColor = Color.Black;
            }
        }

        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                UsernameTextBox.Text = "Username";

                UsernameTextBox.ForeColor = Color.Silver;
            }

        }

        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
               PasswordTextBox.PasswordChar = '\0';
                PasswordTextBox.Text = "Enter your password";

                PasswordTextBox.ForeColor = Color.Silver;
            }
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "Enter your password")
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.PasswordChar = '*';
                PasswordTextBox.ForeColor = Color.Black;
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ExitPressed();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            RegisterPressed();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }
    }
}
