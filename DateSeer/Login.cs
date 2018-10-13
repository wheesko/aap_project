using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace DateSeer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            List<SqlParameter> sqlParams = new List<SqlParameter>();


        }

        private void Button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Register reg = new Register();
            reg.Region = this.Region;
            reg.Show();

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text != "Username" && PasswordTextBox.Text != "Enter your password")
            {
                User loginUser = new User(UsernameTextBox.Text, PasswordTextBox.Text);
                if (DAL.CompareToHash(loginUser) == true)
                {
                    this.Hide();
                    Main main = new Main(loginUser);
                    main.Show();
                  
                }
                else
                {
                    UsernameTextBox.ForeColor = Color.Silver;
                    PasswordTextBox.PasswordChar = '\0';
                    PasswordTextBox.ForeColor = Color.Silver;

                    UsernameTextBox.Text = "Username";
                    PasswordTextBox.Text = "Enter your password";
                    MessageBox.Show("Incorrect username or password");
                }
            }
            else
            {
                MessageBox.Show("Empty username or password field");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.Show();
        }

        private void FacebookButton_Click(object sender, EventArgs e)
        {
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
            Application.Exit();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.Show();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

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
