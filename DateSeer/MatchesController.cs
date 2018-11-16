using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DateSeer
{
    public class MatchesController
    {
        Thread th;
        private User MainUser;
        private Matches match;
        private Main mainpage;
        private List<User> matched;
        private List<string> names;
        private List<User> tempw;
        private List<User> temp1;
        private int brake;

        public MatchesController(User mainUser, Matches reference)
        {
            MainUser = mainUser;
            match = reference;
            Loader();
            match.Back += () => Back();
            match.Exit += () => Exit();
            match.Next += () => Next();
            match.Previous += () => Previous();
            match.Searh += () => Search();
        }
        private void Search()
        {
            if (match.textBox1.Text != "")
            {
                temp1 = new List<User>();
                var searched = from person in matched
                               where person.name.Contains(match.textBox1.Text)
                               select person;
                foreach (User person in searched)
                {
                    temp1.Add(person);
                }
                matched.Clear();
                foreach (User us in temp1)
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
                brake = 0;
                foreach (User person in matched)
                {
                    UploadUser(person, brake);
                    brake++;
                }
                brake = 0;
            }
        }
        private void Previous()
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

        private void Next()
        {
            if (match.label4.Text != "")
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
            private void Exit()
        {
            Application.Exit();
        }

        private void Back()
        {
            match.Dispose();
            mainpage = new Main();
            MainController main = new MainController(MainUser,mainpage);
            th = new Thread(OpenMain);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenMain()
        {
            Application.Run(mainpage);
        }

        private string GetResourcesPath()
        {
            string PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            PathR = Path.Combine(PathR, "Resources");
            return PathR;
        }
        private void Loader()
            {
                
                string name = MainUser.name;
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
                         names.Add(person.name);
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
                match.label1.Text = person.name;
                match.label5.Text = person.email;
                try
                {
                    Image img = Image.FromFile(UploadPhoto(person));
                    match.pictureBox1.Image = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem with User: " + person.name + " image, we will reset this image to default");
                    person.setImage("");
                    person.setImage(UploadPhoto(person));
                    Image img = Image.FromFile(UploadPhoto(person));
                    match.pictureBox1.Image = img;
                }

                match.label2.Text = null;
                match.label6.Text = null;
                match.pictureBox2.Image = null;

                match.label3.Text = null;
                match.label7.Text = null;
                match.pictureBox3.Image = null;

                match.label4.Text = null;
                match.label8.Text = null;

                match.pictureBox4.Image = null;
            }
            else if (brake1 == 1)
            {
                match.label2.Text = person.name;
                match.label6.Text = person.email;
                try
                {
                    Image img = Image.FromFile(UploadPhoto(person));
                    match.pictureBox2.Image = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem with User: " + person.name + "image, we will reset this image to default");
                    person.setImage("");
                    person.setImage(UploadPhoto(person));
                    Image img = Image.FromFile(UploadPhoto(person));
                    match.pictureBox1.Image = img;
                }

                match.label3.Text = null;
                match.label7.Text = null;
                match.pictureBox3.Image = null;

                match.label4.Text = null;
                match.label8.Text = null;
                match.pictureBox4.Image = null;
            }
            else if (brake1 == 2)
            {
                match.label3.Text = person.name;
                match.label7.Text = person.email;
                try
                {
                    Image img = Image.FromFile(UploadPhoto(person));
                    match.pictureBox3.Image = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem with User: " + person.name + "image, we will reset this image to default");
                    person.setImage("");
                    person.setImage(UploadPhoto(person));
                    Image img = Image.FromFile(UploadPhoto(person));
                    match.pictureBox1.Image = img;
                }
                match.label4.Text = null;
                match.label8.Text = null;

                match.pictureBox4.Image = null;

            }
            else if (brake1 == 3)
            {
                match.label4.Text = person.name;
                match.label8.Text = person.email;
                try
                {
                    Image img = Image.FromFile(UploadPhoto(person));
                    match.pictureBox4.Image = img;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem with User: " + person.name + "image, we will reset this image to default");
                    person.setImage("");
                    person.setImage(UploadPhoto(person));
                    Image img = Image.FromFile(UploadPhoto(person));
                    match.pictureBox1.Image = img;
                }
            }
        }
        public string UploadPhoto(User person)
        {

            string pathphoto = GetResourcesPath();
            pathphoto = Path.Combine(pathphoto, "DefaultAccountPic");
            if (person.getImage() == "")
            {
                if (person.gender == 1)
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
    }
 }
