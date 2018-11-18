using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    public partial class Matches : Form, MatchesForm
    {
        private Action BackPressed = delegate { };
        private Action ExitPressed = delegate { };
        private Action NextPressed = delegate { };
        private Action PreviousPressed = delegate { };
        private Action SearchUser = delegate { };


        public Action Back { get => BackPressed; set => BackPressed = value; }
        public Action Exit { get => ExitPressed; set => ExitPressed = value; }
        public Action Next { get => NextPressed; set => NextPressed = value; }
        public Action Previous { get => PreviousPressed; set => PreviousPressed = value; }
        public Action Searh { get => SearchUser; set => SearchUser= value; }

        public Matches()
        {
            InitializeComponent();
        }
        private void label11_Click(object sender, EventArgs e)
        {
            BackPressed();
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
            ExitPressed();
        }
        private void label10_Click(object sender, EventArgs e)
        {
            NextPressed();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            PreviousPressed();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchUser();
        }
    }
}
        
    

