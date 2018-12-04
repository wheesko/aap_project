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
    public partial class Main : Form,  MainForm
    {

       private Action LikeButtomPressed_ = delegate { };
       private Action DisLikeButtomPressed_ = delegate { };
       private Action AllMatches_ = delegate { };
       private Action Profile_ = delegate { };
       private Action ExitPressed = delegate { };

         public Action LikeButtomPressed { get => LikeButtomPressed_; set => LikeButtomPressed_ = value; }
         public Action DisLikeButtomPressed { get => DisLikeButtomPressed_; set => DisLikeButtomPressed_ = value; }
         public Action AllMatches { get => AllMatches_; set => AllMatches_ = value; }
         public Action Profile { get => Profile_; set => Profile_ = value; }
         public Action Exit { get => ExitPressed; set => ExitPressed = value ; }

        public Main()
        {
            InitializeComponent();  
        }  
        private void button1_Click(object sender, EventArgs e)
        {
            LikeButtomPressed_();   
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ExitPressed();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DisLikeButtomPressed_();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Profile_();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AllMatches_();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
