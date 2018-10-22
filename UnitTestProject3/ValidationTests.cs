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
            string expected = "Some fields are empty" +Environment.NewLine+ "User under 18" + Environment.NewLine+ "Email not valid" + Environment.NewLine;
            string result = new DateSeer.Validation().validateRegistrationForm("","","","","",DateTime.Today,true,false);
            Assert.AreEqual(expected, result);
        }
    }
}
