using System;
using System.IO;
using DateSeer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject3
{
    [TestClass]
    public class MatchesTest
    {
        [TestMethod]
        public void UploadPhotoMethod1()
        {
            string expected = "sadlaif.jpg";

            User testUser = new User("ew", null);
            testUser.setImage("sadlaif.jpg");
            User test = new User(null, null);
            string result = new Matches().UploadPhoto(testUser);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void UploadPhotoMethod2()
        {
            string expected = ".exedswagadsgsagasdsagsgasdgadsgasdgadsgasdgasdgadsgasdgadsgsaGAWGEHRWAQGBVEW";
            User testUser = new User("qt", null);
            testUser.setImage(".exedswagadsgsagasdsagsgasdgadsgasdgadsgasdgasdgadsgasdgadsgsaGAWGEHRWAQGBVEW");
            User test = new User(null, null);
            string result = new Matches().UploadPhoto(testUser);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void GetResources1()
        { 
            User testUser = new User("ew", null);
            string result = new Matches().GetResourcesPath();
           Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetResources2()
        {
            string expected = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            expected = Path.Combine(expected, "Resources");
            User testUser = new User("ew", null);
            string result = new Matches().GetResourcesPath();
            Assert.AreEqual(result,expected);
        }
    }
}
