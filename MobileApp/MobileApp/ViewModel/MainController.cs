using System;
using System.Data;
using System.IO;
using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Views;
using System.Drawing;
using Xamarin.Forms;

namespace MobileApp
{
    public class MainController
    {
        private MainPage main;
        public User MainUser;
        private DataController dc;
        public User Usern;
        public int number;

        public MainController(MainPage main, User mainUser)
        {
            this.main = main;
            this.MainUser = mainUser;
            Load_User();
            number = 1;
            main.LikePressed += () => LikeAsync();
            main.DislikePressed += () => Dislike();
            main.Profile += () => ShowProfile();
            main.Matches += () => ShowMatches();
            dc = new DataController(new DatabaseDataManager());
        }

        private void ShowMatches()
        {
            main.MatchesPressed(MainUser);
        }

        private void ShowProfile()
        {
            main.ProfilePressed(MainUser);
        }

        private void Dislike()
        {
            if (Usern.name != null)
            {
                int id = Usern.Id;
                int maine = MainUser.Id;
                Table table = new Table(maine,id,0, "dbo.UsedIDs", "ID", "UsedID");
                dc.UpdateTable(table);
                Load_User();
            }
        }

        private async System.Threading.Tasks.Task LikeAsync()
        {
            {
                if (Usern.name != null)
                {
                    int id = Usern.Id;
                    int maine = MainUser.Id;
                    Table dte = new Table(maine, id, 0, "dbo.UsedIDs", "ID", "UsedID");
                    dc.UpdateTable(dte);
                    Table dt1 = new Table(maine, id, 0, "dbo.Likes", "PersonID", "Liked");
                    dc.UpdateTable(dt1);
                    User searched = new User(null, null);
                    DataTable dt = dc.Searches(MainUser, Usern);
                  
                    if (dt.Rows.Count == 1)
                    {
                        await main.DisplayAlert("Alert","Matched","Okay");
                       Table dt0 = new Table(maine, id, number, "dbo.Matches", "PersonID", "MatchedID");
                        dc.UpdateTable(dt0);
                       Table dt2 = new Table(id, maine, number, "dbo.Matches", "PersonID", "MatchedID");
                        dc.UpdateTable(dt2);
                        number++;
                    }
                    Load_User();
                }
            }
        }
        private void Load_User()
        {
            Usern = new User(null, null);
            if (MainUser.gender == 1)
            {
                DataTable dt = dc.GetUnsedUser(2, MainUser.Id);
                try
                {
                    Usern.name = dt.Rows[0]["Name"].ToString();
                    Usern.email = dt.Rows[0]["Email"].ToString();
                    Usern.gender = int.Parse(dt.Rows[0]["Gender"].ToString());
                    Usern.Id = int.Parse(dt.Rows[0]["ID"].ToString());
                    Usern.username = dt.Rows[0]["Username"].ToString();

                    byte[] bytr = null;
                    ImageSource retSource = null;

                    bytr = StringToByteArray(dt.Rows[0]["Image"].ToString());

                    retSource = ImageSource.FromStream(() => new MemoryStream(bytr));

                    Usern.image = retSource;
                    main.LabelN.Text = Usern.name;
                    main.Picture.Source = Usern.image;
                }
                catch (Exception ex)
                {
                    main.Picture.Source = ImageSource.FromFile(@"\kek.jpg");
                    main.LabelN.Text = "";
                }

            }
            else
            {
                DataTable dt = dc.GetUnsedUser(1, MainUser.Id);
                try
                {
                    Usern.name = dt.Rows[0]["Name"].ToString();
                    Usern.email = dt.Rows[0]["Email"].ToString();
                    Usern.gender = int.Parse(dt.Rows[0]["Gender"].ToString());
                    Usern.Id = int.Parse(dt.Rows[0]["ID"].ToString());
                    Usern.username = dt.Rows[0]["Username"].ToString();

                    byte[] bytr = null;
                    ImageSource retSource = null;

                    bytr = StringToByteArray(dt.Rows[0]["Image"].ToString());

                    retSource = ImageSource.FromStream(() => new MemoryStream(bytr));

                    Usern.image = retSource;
                    main.LabelN.Text = Usern.name;
                    main.Picture.Source = Usern.image;
                }
                catch (Exception ex)
                {
                    main.Picture.Source = ImageSource.FromFile(@"\kek.jpg");
                    main.LabelN.Text = "";
                }
            }
        }

        private byte[] StringToByteArray(string p)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(p);
        }
    }
}