using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    public partial class Register : Form,RegisterIUI
    {
        public Action Exit { get => ExitPressed; set => ExitPressed = value; }
        public Action Registers { get => RegisterPressed; set => RegisterPressed = value; }
        public Action Back { get => BackPressed; set => BackPressed = value; }

        private Action RegisterPressed = delegate { };
        private Action ExitPressed = delegate { };
        private Action Watermarker = delegate { };
        private Action BackPressed = delegate { };

        public Register()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = default(char);
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
            ExitPressed();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            BackPressed();
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Black;
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

          private void button1_Click(object sender, EventArgs e)
        {
            RegisterPressed();
        }
    }
}
