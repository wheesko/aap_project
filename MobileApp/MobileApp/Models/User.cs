using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace MobileApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public int gender { get; set; }
        public string email { get; set; }

        public void setImage(string v)
        {
            image = v;
        }

        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        private string image { get; set; }
        public string facebookID { get; set; }
        public string birthdate { get; set; }

        public User(string gotUsername, string gotPassword, string gotEmail, string gotName, string gotBirthdate, int gotGender)//used for register form
        {
            this.email = gotEmail;
            this.username = gotUsername;
            this.password = gotPassword;
            this.name = gotName;
            this.gender = gotGender;
            this.facebookID = null;
            this.birthdate = gotBirthdate;
        }
        public User(string gotEmail, string gotName, string gotfacebookID, string gotBirthdate, int gotGender)//used for login with facebook
        {
            this.username = " ";
            this.password = " ";
            this.name = gotName;
            this.email = gotEmail;
            this.facebookID = gotfacebookID;
            this.birthdate = gotBirthdate;
            this.gender = gotGender;
        }
  

        public User(string gotUsername, string gotPassword)//used for login form
        {
            this.username = gotUsername;
            this.password = gotPassword;
            this.name = null;
            this.email = null;
        }
       
       
       
        public void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        } 
      
    }

    }

