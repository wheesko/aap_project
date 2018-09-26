using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DateSeer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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

            this.Close();


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
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("Username", UsernameTextBox.Text));
            sqlParams.Add(new SqlParameter("Password", PasswordTextBox.Text));

            DataTable dtLoginResults = DAL.executeStoredProcedure("ValidateLogin", sqlParams);

            if (dtLoginResults.Rows.Count == 1)
            {
                MessageBox.Show("Logged in");
            }
            else
            {
                MessageBox.Show("Invalid login");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Register();
            form.Show();
        }

        private void FacebookButton_Click(object sender, EventArgs e)
        {

        }

    }
    }
