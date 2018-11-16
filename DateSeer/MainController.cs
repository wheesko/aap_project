using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    public class MainController
    {
        Thread th;
        private User MainUser;
        private User Usern;
        public int state = 1;
        public Main mainpage;
        public Matches matchesform;
        public Options optionform;

        public MainController(User MainUser,Main e)
        {
            this.MainUser = MainUser;
            mainpage = e;

            MainUser.GetUserInfoByUsername();
            string path = GetResourcesPath();
            path = Path.Combine(path, "Users");
            path = path + @"\" + MainUser.username + ".txt";
            if (File.Exists(path)) { }
            else
            {
                MainUser.CreateFile(path);
            }
            Load_User();
            mainpage.LikeButtomPressed += () =>Liked();
            mainpage.DisLikeButtomPressed += () => Disliked();
            mainpage.AllMatches += () => ShowMatches();
            mainpage.Profile += () => ShowProfile();
            mainpage.Exit += () => Exit();

        }

        private void Exit()
        {
            Application.Exit();
        }

        private string GetResourcesPath()
        {
            string PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            PathR = Path.Combine(PathR, "Resources");
            return PathR;
        }


        private void ShowProfile()
        {
            mainpage.Close();
            optionform = new Options();
            OptionsController matches = new OptionsController(MainUser,optionform);
            th = new Thread(OpenOptions);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenOptions()
        {
            Application.Run(optionform);
        }

        private void OpenMatches()
        {
            Application.Run(matchesform);
        }

        private void ShowMatches()
        {
            mainpage.Close();
            matchesform = new Matches();
            MatchesController matches = new MatchesController(MainUser,matchesform);
            th = new Thread(OpenMatches);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Disliked()
        {
            if (Usern.name != null)
            {
                int id = Usern.getId();
                int main = MainUser.getId();
                ChangeDatabase insert = new ChangeDatabase(main, id);
                Load_User();
            }
        }

        private void Load_User()
        {
            Usern = new User(null, null);
            if (MainUser.gender == 1)
            {
                Usern.GetUserInfoByGender(2, MainUser.getId());

            }
            else
            {
                Usern.GetUserInfoByGender(1, MainUser.getId());
            }

            if (Usern.name == null)
            {
                string pathg = GetResourcesPath();
                pathg = Path.Combine(pathg + @"\NoMore.png");
                Image image = Image.FromFile(pathg);
                mainpage.UsernPic.Image = image;
                mainpage.label2.Text = "";

            }
            else
            {

                string pathg = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                pathg = Path.Combine(pathg, "Resources");
                pathg = Path.Combine(pathg, "DefaultAccountPic");
                if (Usern.getImage() == "")
                {
                    if (Usern.gender == 1)
                    {
                        
                        pathg = Path.Combine(pathg + @"\male.png");
                        Usern.setImage(pathg);
                        Image image = Image.FromFile(pathg);
                        mainpage.UsernPic.Image = image;
                        mainpage.label2.Text = Usern.name;


                    }
                    else
                    {
                        pathg = Path.Combine(pathg + @"\female.jpg");
                        Usern.setImage(pathg);
                        Image image = Image.FromFile(pathg);
                        mainpage.UsernPic.Image = image;
                        mainpage.label2.Text = Usern.name;

                    }
                }
                else
                {
                    Image image = Image.FromFile(Usern.getImage());
                    mainpage.UsernPic.Image = image;
                    mainpage.label2.Text = Usern.name;

                }
            }
        }
        private void Liked()
        {
            {
                if (Usern.name != null)
                {
                    int id = Usern.Id;
                    int maine = MainUser.Id;
                    ChangeDatabase insert = new ChangeDatabase(maine, id);
                    string PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    PathR = Path.Combine(PathR, "Resources");
                    PathR = Path.Combine(PathR, "Users");
                    PathR = PathR + @"\" + MainUser.username + ".txt";
                    TextWriter tw = new StreamWriter(PathR, true);
                    tw.WriteLine(Usern.Id);
                    tw.Close();
                    PathR = "";
                    PathR = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    PathR = Path.Combine(PathR, "Resources");
                    PathR = Path.Combine(PathR, "Users");
                    PathR = PathR + @"\" + Usern.username + ".txt";

                    string c = maine.ToString();
                    using (StreamReader sr = File.OpenText(PathR))
                    {
                        string s = String.Empty;
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s == c)
                            {
                                matched(MainUser, Usern);
                            }
                        }
                    }
                    Load_User();
                }
            }
        }
        public void matched(User MainUser,User Usern)
        {
                MessageBox.Show("Matched!");
                string Pathw = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                Pathw = Path.Combine(Pathw, "Resources");
                Pathw = Path.Combine(Pathw, "Matches");
                TextWriter tew = new StreamWriter(Pathw + @"\" + MainUser.username + ".txt", true);
                tew.WriteLine(MainUser.Id);
                tew.Close();
                TextWriter tw = new StreamWriter(Pathw + @"\" + Usern.username + ".txt", true);
                tw.WriteLine(MainUser.Id);
                tw.Close();
                Load_User();
        }
    }
   
}
