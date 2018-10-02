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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You liked this person");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You disliked this person");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Our team is working on this feature.\nWe hope we will make it available for you as fast as possiable :)");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Our team is working on this feature.\nWe hope we will make it available for you as fast as possiable :)");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Our team is working on this feature.\nWe hope we will make it available for you as fast as possiable :)");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Our team is working on this feature.\nWe hope we will make it available for you as fast as possiable :)");
        }
    }
}
