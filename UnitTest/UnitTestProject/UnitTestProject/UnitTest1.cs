using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Rudimentary_Antivirus;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnryptionUnitTest()
        {

            string password = "myPassword";
            byte[] expectedBytes = Encoding.UTF8.GetBytes(password);
            string expectedBase64String = Convert.ToBase64String(expectedBytes);

            string encryptedString = RegistrationWindow.Enryption(password);

            Assert.AreEqual(expectedBase64String, encryptedString);
        }      
    }
}
