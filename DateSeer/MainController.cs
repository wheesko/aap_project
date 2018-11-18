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
        public Main mainpage;
        public Matches matchesform;
        public Options optionform;
        public int number;

        public MainController(User MainUser,Main e)
        {
            this.MainUser = MainUser;
            mainpage = e;
            number = 1;
            MainUser.GetUserInfoByUsername(); 
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
                ChangeDatabase insert = new ChangeDatabase(main,id,0, "dbo.UsedIDs", "ID","UsedID");
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
                    int main = MainUser.Id;
                    ChangeDatabase insert = new ChangeDatabase(main, id,0,"dbo.UsedIDs", "ID", "UsedID");
                    ChangeDatabase insert0 = new ChangeDatabase(main,id,0,"dbo.Likes","PersonID","Liked");
                    User searched = new User(null, null);
                    searched.SearchLikes(MainUser,Usern);
                    if (searched.username != null)
                    {
                        MessageBox.Show("Matched!");
                        ChangeDatabase insert1 = new ChangeDatabase(main,id,number,"dbo.Matches","PersonID","MatchedID");
                        ChangeDatabase insert2 = new ChangeDatabase(id,main,number,"dbo.Matches","PersonID", "MatchedID");
                        number++;
                    }
                    Load_User();
                }
            }
        }
    }
   
}
