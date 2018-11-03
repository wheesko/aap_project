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
        private string image;
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
        public void GetUserInfoByUsername()
        {
            GetUserInfo get = new GetUserInfo(username);
            this.name = get.getName();
            this.email = get.getEmail();
            this.gender = get.getGender();
            this.image = get.getImage();
            this.Id = get.getId();
            this.username = get.getUsername();
         
        }
        public void GetUserInfoByGender(int gender,int ids)
        {
            GetUserInfo get = new GetUserInfo(gender,ids,0);
            this.name = get.getName();
            this.email = get.getEmail();
            this.gender = get.getGender();
            this.image = get.getImage();
            this.Id = get.getId();
            this.username = get.getUsername();
          
           

        }
        public void GetUserInfoByID(int id)
        {
            GetUserInfo get = new GetUserInfo(id, 0);
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
      
    }

    }

