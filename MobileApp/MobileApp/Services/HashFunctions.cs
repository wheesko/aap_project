using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class HashFunctions
    {
        public string GetHash(string input, byte[] passedSalt = null)
        {
            //get salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //combine pass with salt
            var pbkdf2 = new Rfc2898DeriveBytes(input, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //convert to string and return
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }
        public bool GetNewHash(string gotPassString, string GotDbString)
        {
            /* Fetch the stored value */
            string savedPasswordHash = GotDbString;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(gotPassString, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }
        public bool CompareToHash(User user)
        {
            //get from user class
            string gotUsernameString = user.username;
            string gotPassString = user.password;
            //find user by username
            /*List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("Username", gotUsernameString));*/

            //DataTable dtLoginResults = DAL.executeStoredProcedure("ValidateLogin", sqlParams);
            DataController dataController = new DataController(new DatabaseDataManager());
            DataTable dtLoginResults = dataController.GetData("ValidateLogin", user);
            if (dtLoginResults.Rows.Count == 1) //if only 1 user found
            {
                string gotString = dtLoginResults.Rows[0]["password"].ToString();

                if (new HashFunctions().GetNewHash(gotPassString, gotString) == true) //compare hashed passwords
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
