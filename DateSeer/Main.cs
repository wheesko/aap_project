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
    public partial class Main : Form
    {
       private User MainUser;
       private User Usern;
               
        public Main(User MainUser)
        {
            this.MainUser = MainUser;
            MainUser.GetUserInfoByUsername();
            string path = GetResourcesPath();
            path = Path.Combine(path,"Users");
            path = path + @"\" + MainUser.getName() + ".txt";
            if (File.Exists(path)) { }
            else
            {
                MainUser.CreateFile(path);
            }
            InitializeComponent();
            Load_User();
        }

        private string GetResourcesPath()
        {
            string PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            PathR = Path.Combine(PathR, "Resources");
            return PathR;
        }

        private void Load_User()
        {
            Usern = new User(null, null);
           
            if (MainUser.getGender() == 1)
            {
                Usern.GetUserInfoByGender(2,MainUser.getId());
            }
            else
            {
                Usern.GetUserInfoByGender(1,MainUser.getId());
            }
          
          
            string name; ;
            if (Usern.getName() == null)
            {
                string pathg = GetResourcesPath();
                pathg = Path.Combine(pathg + @"\NoMore.png");
                Image image = Image.FromFile(pathg);
                UsernPic.Image = image;
                label2.Text = "";

            }
            else
            {
                name = Usern.getName().ToString();
                label2.Text = name;
                string PathR = GetResourcesPath();
                PathR = Path.Combine(PathR, "DefaultAccountPic");
                if (Usern.getImage() == "")
                {
                    if (Usern.getGender() == 1)
                    {

                        Image image = Image.FromFile(PathR + @"\male.png");
                        UsernPic.Image = image;

                    }
                    else
                    {
                        Image image = Image.FromFile(PathR + @"\female.jpg");
                        UsernPic.Image = image;

                    }

                }
                else
                {
                    Image image = Image.FromFile(Usern.getImage());
                    UsernPic.Image = image;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        { 
           if (Usern.getName() != null)
            {
                int id = Usern.getId();
               
                int main = MainUser.getId();
                ChangeDatabase insert = new ChangeDatabase(main, id);
                string PathR = GetResourcesPath();
                PathR = Path.Combine(PathR, "Users");
                PathR = PathR + @"\" + MainUser.getName() + ".txt";

                TextWriter tw = new StreamWriter(PathR,true);
                tw.WriteLine(Usern.getId());
                tw.Close();
                PathR = "";
                PathR = GetResourcesPath();
                PathR = Path.Combine(PathR, "Users");
                PathR = PathR + @"\" + Usern.getName() + ".txt";
                string c = main.ToString();
                if (!File.Exists(PathR))
                {
                    File.Create(PathR);
                }
                using (StreamReader sr = File.OpenText(PathR))
                {
                    string s = String.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s == c)
                        {
                            matched();
                        }
                    }
                }

                Load_User();

           }
        }

        private void matched()
        {
            MessageBox.Show("Matched!");
           String  Pathw = GetResourcesPath();
            Pathw = Path.Combine(Pathw, "Matches");
            Pathw = Pathw + @"\" + MainUser.getName() + ".txt";
            MainUser.CreateFile(Pathw);
            TextWriter tew = new StreamWriter(Pathw,true);
            tew.WriteLine(Usern.getId());
            tew.Close();
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
            if (Usern.getName() != null)
            {
                int id = Usern.getId();
                int main = MainUser.getId();
                ChangeDatabase insert = new ChangeDatabase(main, id);
                Load_User();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Options options = new Options(MainUser);
            options.Show();

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
            this.Hide();
            Matches n = new  Matches(MainUser);
            n.Show();
        }

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void UsernPic_Click(object sender, EventArgs e)
        {

        }
    }
}
