using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    public class User
    {
        private int Id;
        private int gender;
        private string email;
        private string username;
        private string password;
        private string name;
        private string image;

       

        public User(string gotUsername, string gotPassword, string gotEmail, string gotName, int gotGender)//used for register form
        {
            this.email = gotEmail;
            this.username = gotUsername;
            this.password = gotPassword;
            this.name = gotName;
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
            this.Id = get.getId();
         
        }
        public void GetUserInfoByGender(int gender)
        {
            GetUserInfo get = new GetUserInfo(gender);
            this.name = get.getName();
            this.email = get.getEmail();
            this.gender = get.getGender();
            this.image = get.getImage();
            this.Id = get.getId();
           

        }
        public void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public int getId()
        {
            return Id;
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
    }

    }

