using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateSeer;
namespace UnitTestProject3
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expected = "Some fields are empty" + Environment.NewLine + "User under 18" + Environment.NewLine + "Email not valid" + Environment.NewLine;
            string result = new DateSeer.Validation().validateRegistrationForm("", "", "", "", "", DateTime.Today, true, false);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string expected = "";
            string name = "Bonifacija";
            string username = "Bonifaciuxx23";
            string pass = "Asgrazuole123^";
            string repeatedPass = "Asgrazuole123^";
            string email = "grazuole.asEsu@gmail.com";
            DateTime date = new DateTime(1998, 12, 9);
            bool male = false;
            bool female = true;
            var result = new DateSeer.Validation().validateRegistrationForm(username, pass, repeatedPass, email, name, date, male, female);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string expected = "Email not valid" + Environment.NewLine;
            string name = "Bonifacija";
            string username = "Bonifaciuxx23";
            string pass = "Asgrazuole123^";
            string repeatedPass = "Asgrazuole123^";
            string email = "cia lievs emails";
            DateTime date = new DateTime(1998, 12, 9);
            bool male = false;
            bool female = true;
            var result = new DateSeer.Validation().validateRegistrationForm(username, pass, repeatedPass, email, name, date, male, female);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string expected = "Passwords did not match" + Environment.NewLine + "Email not valid" + Environment.NewLine;
            string name = "Bonifacija";
            string username = "Bonifaciuxx23";
            string pass = "Asgrazuole123^";
            string repeatedPass = "Asgrazuole123";
            string email = "grazuole";
            DateTime date = new DateTime(1998, 12, 9);
            bool male = false;
            bool female = true;
            var result = new DateSeer.Validation().validateRegistrationForm(username, pass, repeatedPass, email, name, date, male, female);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod5()
        {
            string expected = "";
            string name = "asssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
            string username = "asssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";
            string pass = "Asssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss@1";
            string repeatedPass = "Asssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss@1";
            string email = "asssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss@gmail.com";
            DateTime date = new DateTime(1999, 12, 9);
            bool male = true;
            bool female = false;
            var result = new DateSeer.Validation().validateRegistrationForm(username, pass, repeatedPass, email, name, date, male, female);
            Assert.AreEqual(expected, result);
        }
    }
}