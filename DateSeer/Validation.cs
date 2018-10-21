using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
namespace DateSeer
{
    
    static class Validation
    {
        public static string validateRegistrationForm(string username, string pass, string repeatedPass, string email, string name, DateTime gotAge, CheckBox male, CheckBox female)
        {
            string returnedString = "";
            string[] textArgs = { username, pass, repeatedPass, email, name};
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - gotAge.Year;  
            // Go back to the year the person was born in case of a leap year
            if (gotAge > today.AddYears(-age)) age--;
            //check if user is under 18
            //check if all fields are not empty
            foreach (string s in textArgs) {
                if (string.IsNullOrEmpty(s) == true || checkForDefaultStrings(s)) {
                    returnedString += "Some fields are empty" + Environment.NewLine;
                    break;
                }
            }
            //check if age is over 18
            if (age < 18) returnedString += "User under 18" + Environment.NewLine;
            //check if passwords match
            if (pass != repeatedPass && returnedString.Contains("Some fields are empty") == false) returnedString += "Passwords did not match" + Environment.NewLine;
            try {
                var mailAddress = new MailAddress(email); //try creating email, if exception, format not valid
            }
            catch
            {
                returnedString += "Email not valid" + Environment.NewLine;
            }
            if (male.Checked != true && female.Checked != true) returnedString += "Gender not selected!" + Environment.NewLine;
            return returnedString;
        }
        private static bool checkForDefaultStrings(string str) {
            string checkString = "Repeat your password Enter your username Enter your email Enter your password Enter your name";
            if (checkString.Contains(str) == true) return true;
            return false;
        }
    }
}
