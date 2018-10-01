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
        private string email;
        private string username;
        private string password;
        private string name;
        public User(string gotUsername, string gotPassword, string gotEmail, string gotName)//used for register form
        {
            this.email = gotEmail;
            this.username = gotUsername;
            this.password = gotPassword;
            this.name = gotName;
        }
        public User(string gotUsername, string gotPassword)//used for login form
        {
            this.username = gotUsername;
            this.password = gotPassword;
            this.name = null;
            this.email = null;
        }
        public string getemail()
        {
            return email;
        }
        public string getusername()
        {
            return username;
        }
        public string getname()
        {
            return name;
        }
        public string getpassword()
        {
            return password;
        }
     }
       
    
    }

