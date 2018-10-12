using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DateSeer
{
    public class User
    {
        private int gender;
        private string email;
        private string username;
        private string password;
        private string name;
        private string image;
        private string facebookID;
        private string birthdate;


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
        internal void setImage(string path)
        {
            image = path;
        }

        public User(string gotUsername, string gotPassword)//used for login form
        {
            this.username = gotUsername;
            this.password = gotPassword;
            this.name = null;
            this.email = null;
        }
        public void GetUserInfoByUsername()
        {
            GetUserInfo get = new GetUserInfo(username);
            this.name = get.getName();
            this.email = get.getEmail();
            this.gender = get.getGender();
            this.image = get.getImage();
        }

        public string getImage()
        {
            return image;
        }
        public string getName()
        {
            return name;
        }
        public string getemail()
        {
            return email;
        }
        public string getUsername()
        {
            return username;
        }
        public string getpassword()
        {
            return password;
        }
        public int getGender()
        {
            return gender;
        }
        public string getBirthday()
        {
            return birthdate;
        }
        public string getFacebookID()
        {
            return facebookID;
        }
    }

    }

