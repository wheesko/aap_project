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
    public partial class Options : Form, OptionForm
    {

        public Action Upload { get => UploadButtomPressed; set => UploadButtomPressed = value; }
        public Action Back { get => BackPressed; set => BackPressed = value; }
        public Action Exit { get => ExitPressed; set => ExitPressed = value; }

        private Action UploadButtomPressed= delegate { };
        private Action BackPressed = delegate { };
        private Action ExitPressed = delegate { };
     
        public Options()
        { 
            InitializeComponent();       
        }

        private void label3_Click(object sender, EventArgs e)
        {
            UploadButtomPressed();
        }
        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ExitPressed();
        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            BackPressed();
        }
    }
}
