using Microsoft.VisualStudio.TestTools.UnitTesting;
using SenseMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseMax.Tests
{
    [TestClass()]
    public class ProfileTests
    {
        #region Test Initialize

        private Profile? instance; //instance variable, used to store an instance of Profile, that i can use in my test methods.

        [TestInitialize]
        public void TestInitialize()
        {
            // arrange
            instance = new Profile();
        }
        
        #endregion
        
        #region Test ProfileName Property

        [TestMethod]
        [DataRow("Ziggy")]
        [DataRow("Eleanor")]
        [DataRow("Peter")]
        public void SetProfileNameTestOk(string validName)
        {
            // act
            instance.ProfileName = validName;
            
            // assert
            Assert.AreEqual(validName, instance.ProfileName);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("B")]
        public void SetProfileNameTestFail(string invalidName)
        {
            // act & arrange
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => instance.ProfileName = invalidName);
        }
        
        #endregion

        #region Test Password Property

        [TestMethod]
        [DataRow("Passw0rd")]
        [DataRow("SecurePwd123")]
        [DataRow("MyP@ssw0rd")]
        public void SetPasswordTestOk(string validPasssword)
        {
            // act
            instance.Password = validPasssword;
            
            // assert
            Assert.AreEqual(validPasssword, instance.Password);
        }

        [TestMethod]
        [DataRow("NoDigitsHere")]
        [DataRow("lowercaseonly")]
        [DataRow("ALLUPPERCASE")]
        public void SetPasswordTestFail(string invalidPassword)
        {
            // act & assert
            Assert.ThrowsException<ArgumentException>(() => instance.Password = invalidPassword);
        }

        #endregion
    }
}