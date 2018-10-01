using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Loginback = new Login();
            Loginback.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
              
                    if (textBox4.Text == textBox5.Text)
                    {
                        User registeringUser = new User(textBox3.Text, textBox4.Text, textBox2.Text, textBox1.Text);
                        try
                        {
                            DAL.CreateUser(registeringUser);
                            MessageBox.Show("Registered Succesfully");
                        }
                        catch(Exception ex)
                        {
                            textBox1.Text = "";
                            textBox3.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            MessageBox.Show("Username or Email already taken");
                        }
                       
                    }
                    else
                    {
                        textBox4.Text = "";
                        textBox5.Text = "";
                        MessageBox.Show("Passwords did not match");
                    }
               
            }
            else
            {
                MessageBox.Show("Some fields are empty");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = default(char);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
