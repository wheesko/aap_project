using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Views;
using Xamarin.Forms;

namespace MobileApp
{
    internal class MatchesController
    {
        private MatchesPage match;
        private User mainUser;
        public DataController dc;
        
        private User MainUser;
        private List<User> matched;
        private List<string> names;
        private List<User> tempw;
        private List<User> temp1;
        private int brake;

        public MatchesController(MatchesPage match, User mainUser)
        {
            dc = new DataController(new DatabaseDataManager());
            this.match = match;
            this.mainUser = mainUser;
            match.BackPressed += () => match.Back(mainUser);
            match.NextPressed += () => Next();
            match.PreviousPressed += () => Previous();
            match.Search += () => Search();
        }

        private void Search()
        {
            if (match.SearchByName.Text != "")
            {
                temp1 = new List<User>();
                var searched = from person in matched
                               where person.name.Contains(match.SearchByName.Text)
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
            if (match.LabelName3.Text != "")
            {

                brake = brake - 4;

                int temp = brake;
                foreach (User person in matched)
                {
                    UploadUser(person, brake);
                    brake++;
                    
                }
                brake = temp;

            }
        }
        private void Loader()
        {


            matched = new List<User>();
            names = new List<string>();


            for (int i = 1; ; i++)
            {
                User rUser = new User(null, null);
                DataTable dt = dc.SearchMatch(MainUser, i);

                rUser.name = dt.Rows[0]["Name"].ToString();
                rUser.email = dt.Rows[0]["Email"].ToString();
                rUser.username = dt.Rows[0]["Username"].ToString();

                byte[] bytr = null;
                ImageSource retSource = null;

                bytr = StringToByteArray(dt.Rows[0]["Image"].ToString());

                retSource = ImageSource.FromStream(() => new MemoryStream(bytr));

                if (rUser.username != null)
                {
                    matched.Add(rUser);
                }
                else { break; }


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
        private void UploadUser(User person, int brake1)
        {
            if (brake1 == 0)
            {
                match.LabelName1.Text = person.name;
                match.LabelEmail1.Text = person.email;
               
                 match.Picture1.Source= person.image;
               
                match.LabelName2.Text = null;
                match.LabelEmail2.Text = null;
                match.Picture2.Source = null;

                match.LabelName3.Text = null;
                match.LabelEmail3.Text = null;
                match.Picture3.Source = null;

                
            }
            else if (brake1 == 1)
            {
              
                match.LabelName2.Text = person.name;
                match.LabelEmail2.Text = person.email;
                match.Picture2.Source = person.image;

                match.LabelName3.Text = null;
                match.LabelEmail3.Text = null;
                match.Picture3.Source = null;

            }
            else if (brake1 == 2)
            {
                match.LabelName3.Text = person.name;
                match.LabelEmail3.Text = person.email;
                match.Picture3.Source = person.image;

            }
           
        }
       
        private byte[] StringToByteArray(string p)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(p);
        }
    }
}