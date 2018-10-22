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
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var validationResult = new Validation().validateRegistrationForm(name: textBox1.Text, username: textBox3.Text, repeatedPass: textBox5.Text, email: textBox2.Text, gotAge: dateTimePicker1.Value, female: FemaleBox.Checked, male: MaleBox.Checked, pass: textBox4.Text);
            if (validationResult == "")
            {
                int gender1 = 0;
                if (MaleBox.Checked == true) { gender1 = 1; }
                if (FemaleBox.Checked == true) { gender1 = 2; }
                User registeringUser = new User(textBox3.Text, textBox4.Text, textBox2.Text, textBox1.Text, dateTimePicker1.Value.ToString(), gender1);
                try
                {
                    DAL.CreateUser(registeringUser);
                    this.Hide();
                    Login LoginBack = new Login();
                    LoginBack.Show();
                }
                catch (Exception ex)
                {

                    textBox1.ForeColor = Color.Silver;
                    textBox2.ForeColor = Color.Silver;
                    textBox3.ForeColor = Color.Silver;
                    textBox4.ForeColor = Color.Silver;
                    textBox5.ForeColor = Color.Silver;

                    textBox1.Text = "Enter your name";
                    textBox2.Text = "Enter your email";
                    textBox3.Text = "Enter your username";

                    textBox4.PasswordChar = '\0';
                    textBox5.PasswordChar = '\0';
                    textBox4.Text = "Enter your password";
                    textBox5.Text = "Repeat your password";

                    MessageBox.Show("Username or Email already taken");
                }
            }
            else
            {
                MessageBox.Show("Following errors occured: " + Environment.NewLine + validationResult);
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter your name";

                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter your name")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter your email")
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter your email";

                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter your username")
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.Black;
            }
          
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter your username";

                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.PasswordChar = '\0';
                textBox4.Text = "Enter your password";

                textBox4.ForeColor = Color.Silver;
            }

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter your password")
            {
                textBox4.PasswordChar = '*';
                textBox4.Text = "";

                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.PasswordChar = '\0';
                textBox5.Text = "Repeat your password";

                textBox5.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Repeat your password")
            {
                textBox5.PasswordChar = '*';
                textBox5.Text = "";

                textBox5.ForeColor = Color.Black;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Loginback = new Login();
            Loginback.Show();
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
        }

        private void FemaleBox_CheckedChanged(object sender, EventArgs e)
        {
    
        }

        private void MaleBox_CheckedChanged_1(object sender, EventArgs e)
        {
     
        }

        private void MaleBox_CheckStateChanged(object sender, EventArgs e)
        {
       
           
        }

        private void FemaleBox_CheckStateChanged(object sender, EventArgs e)
        {
           
        }

        private void MaleBox_Click(object sender, EventArgs e)
        {
            if (FemaleBox.Checked == true)
            {
                FemaleBox.Checked = false;
                MaleBox.Checked = true;
            }
        }

        private void FemaleBox_Click(object sender, EventArgs e)
        {
            if (MaleBox.Checked == true)
            {
                MaleBox.Checked = false;
                FemaleBox.Checked = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
