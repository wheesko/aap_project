using System;
using DateSeer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataSeer1
{
    [TestClass]
    class MatchesTest
    {
        [TestMethod]
        public void UploadPhotoMethod()
        {
            string expected = "sadlaif.jpg";

            User testUser = new User(null, null);
            testUser.setImage("sadlaif.jpg");
            User test = new User(null, null);
            string result = new Matches(test).UploadPhoto(testUser);
            Assert.AreEqual(expected, result);

        }
    }
}
