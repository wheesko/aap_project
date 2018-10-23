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
    public partial class Options : Form
    {
        private User MainUser;

        public Options(User MainUser)
        {
           
            this.MainUser = MainUser;
            InitializeComponent();
          
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Register newregister = new Register();
          
            Upload photo = new Upload();
           ChangeDatabase change = new ChangeDatabase(photo.getPathR(), MainUser);
            MainUser.setImage(photo.getPathR());
           Option_Load();

        }

        private void Option_Load()
        {
            UserName.Text = MainUser.name;
            string PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            PathR = Path.Combine(PathR, "Resources");
            PathR = Path.Combine(PathR, "DefaultAccountPic");
            if (MainUser.getImage() == "")
            {

                if (MainUser.gender == 1)

                {

                    Image image = Image.FromFile(PathR + @"\male.png");
                    pictureBox1.Image = image;

                }
                else
                {
                    Image image = Image.FromFile(PathR + @"\female.jpg");
                    pictureBox1.Image = image;

                }

            }
            else
            {
                try
                {
                    Image image = Image.FromFile(MainUser.getImage());
                    pictureBox1.Image = image;
                }
                catch (Exception ex) { }

                    
            }
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Option_Load();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Update_Click(object sender, EventArgs e)
        {

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
            this.Hide();
            Main n = new Main(MainUser);
            n.Show();
        }
    }
}
