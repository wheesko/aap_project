using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    public partial class Matches : Form
    {
        private User MainUser;

        public Matches(User MainUser)
        {
            this.MainUser = MainUser;
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main n = new Main(MainUser);
            n.Show();
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Red;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Black;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
