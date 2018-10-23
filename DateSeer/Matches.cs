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
    public partial class Matches : Form
    {
        private User MainUser;
        private int brake;
        private List<User> matched;
        private List<string> names;
        private List<User> tempw;
        private List<User> temp1;

        public Matches(User MainUser)
        {
            this.MainUser = MainUser;

            InitializeComponent();
            Loader();

        }

        private void Loader()
        {
            string name = MainUser.getName();
            string pathg = GetResourcesPath();
            pathg = Path.Combine(pathg + @"\Matches" + @"\" + name + ".txt");
            if (File.Exists(pathg))
            {

                matched = new List<User>();
                names = new List<string>();
                using (var reader = new StreamReader(pathg,true))
                {

                    string line;
                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        User n = new User(null, null);
                        n.GetUserInfoByID(int.Parse(line));
                        matched.Add(n);
                    }
                }
                brake = 0;
                foreach (User person in matched)
                {
                    UploadUser(person, brake);
                    brake++;
                    names.Add(person.getName());
                }
                brake = 0;

                tempw = new List<User>();

                foreach (User match in matched)
                {
                    tempw.Add(match);
                }
            }
            else
            {
                File.Create(pathg);
                Loader();
            }

        }
        private void UploadUser(User person, int brake1)
        {
            if (brake1 == 0)
            {
                label1.Text = person.getName();
                label5.Text = person.getemail();
                Image img = Image.FromFile(UploadPhoto(person));
                pictureBox1.Image = img;

                label2.Text =null;
                label6.Text = null;
                pictureBox2.Image = null;

                label3.Text = null;
                label7.Text = null;
                pictureBox3.Image = null;

                label4.Text = null;
                label8.Text = null;
              
                pictureBox4.Image = null;
            }
            else if (brake1 == 1)
            {
                label2.Text = person.getName();
                label6.Text = person.getemail();
                Image img = Image.FromFile(UploadPhoto(person));
                pictureBox2.Image = img;

                label3.Text = null;
                label7.Text = null;
                pictureBox3.Image = null;

                label4.Text = null;
                label8.Text = null;

                pictureBox4.Image = null;
            }
            else if (brake1 == 2)
            {
                label3.Text = person.getName();
                label7.Text = person.getemail();
                Image img = Image.FromFile(UploadPhoto(person));
                pictureBox3.Image = img;

                label4.Text = null;
                label8.Text = null;

                pictureBox4.Image = null;
            }
            else if (brake1 == 3)
            {
                label4.Text = person.getName();
                label8.Text = person.getemail();
                Image img = Image.FromFile(UploadPhoto(person));
                pictureBox4.Image = img;
            }
        }
        private string UploadPhoto(User person)
        {

            string pathphoto = GetResourcesPath();
            pathphoto = Path.Combine(pathphoto, "DefaultAccountPic");
            if (person.getImage() == "")
            {
                if (person.getGender() == 1)
                {

                    pathphoto = Path.Combine(pathphoto + @"\male.png");
                    return pathphoto;
                }
                else
                {
                    pathphoto = Path.Combine(pathphoto + @"\female.jpg");
                    return pathphoto;

                }

            }
            else
            {
                return person.getImage();
            }
        }
        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main n = new Main(MainUser);
            n.Show();
        }
        private string GetResourcesPath()
        {
            string PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            PathR = Path.Combine(PathR, "Resources");
            return PathR;
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

        private void Matches_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

            if (label4.Text != "")
            {
                
                brake = brake - 4;
            
                int temp = brake;
                foreach (User person in matched)
                {
                    UploadUser(person, brake);
                    brake++;
                   ;
                }
                brake = temp;

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (brake < 0)
            {
               
                brake = brake + 4;
                int temp = brake;
              
                foreach (User person in matched)
                {
                    UploadUser(person, brake);
                    brake++;
                }
                brake = temp;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == (char)Keys.Enter)
           {
                if (textBox1.Text != "")
                {

                    temp1 = new List<User>();
                    var searched = from person in matched
                                   where person.getName().Contains(textBox1.Text) 
                                   select person;

                    foreach (User person in searched)
                    {
                        
                        temp1.Add(person);

                    }
                    matched.Clear();
                    
                    foreach(User us in temp1)
                    {
                      
                        matched.Add(us);
                    }

                    int brake = 0;
                    foreach (User userz in matched)
                    {
                       
                        UploadUser(userz, brake);
                        brake++;
                    }
                    brake = 0;

                }
                else
                {
                    matched.Clear();
                    foreach (User u in tempw)
                    {
                        matched.Add(u);
                    }
                    int temp = brake;
                    foreach (User person in matched)
                    {
                        
                        UploadUser(person, brake);
                        brake++;
                    }
                    brake = temp;
                }
           }

        }
    }
}


