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
    public class ExhibitTests
    {
        private Exhibit? instance; //instance variable, used to store an instance of Profile, that i can use in my test methods.

        [TestInitialize]
        public void TestInitialize()
        {
            // arrange
            instance = new Exhibit();
        }



        [TestMethod]
        [DataRow(null)]
        public void NameTestNull(string invalidName)
        {
            // act & arrange
            Assert.ThrowsException<ArgumentNullException>(() => instance.Name = invalidName);
        }

        [TestMethod]
        [DataRow("A")]
        public void NameTestShort(string invalidName)
        {
            // act & arrange
            Assert.ThrowsException<ArgumentException>(() => instance.Name = invalidName);
        }



        [TestMethod]
        [DataRow("An")]
        public void NameTestOk(string validName)
        {
            // act
            instance.Name = validName;

            // assert
            Assert.AreEqual(validName, instance.Name);
        }
    }
}