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
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                List<SqlParameter> checkParams = new List<SqlParameter>();

                checkParams.Add(new SqlParameter("Username", textBox3.Text));
                checkParams.Add(new SqlParameter("Email", textBox2.Text));
                if (DAL.executeStoredProcedure("GetByEmailOrUsername", checkParams).Rows.Count == 0)
                {
                    if (textBox4.Text == textBox5.Text)
                    {
                        byte[] salt;
                        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                        var pbkdf2 = new Rfc2898DeriveBytes(textBox4.Text, salt, 10000);
                        byte[] hash = pbkdf2.GetBytes(20);
                        byte[] hashBytes = new byte[36];
                        Array.Copy(salt, 0, hashBytes, 0, 16);
                        Array.Copy(hash, 0, hashBytes, 16, 20);
                        string savedPasswordHash = Convert.ToBase64String(hashBytes);
                        sqlParams.Add(new SqlParameter("Name", textBox1.Text));
                        sqlParams.Add(new SqlParameter("Email", textBox2.Text));
                        sqlParams.Add(new SqlParameter("Username", textBox3.Text));
                        sqlParams.Add(new SqlParameter("Password", savedPasswordHash));
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        DAL.executeStoredProcedure("AddUser", sqlParams);
                        MessageBox.Show("Registration complete");
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
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    MessageBox.Show("Email or Username already taken");
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
