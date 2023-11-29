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
    public class ArtworkTests
    {
        private Artwork correctInstance;
        private Artwork wrongInstance;
        private Artwork nearInstanceUpper;
        private Artwork nearInstanceLower;

        [TestInitialize]
        public void TestInitialize()
        {
            // arrange
            correctInstance = new Artwork(1, "Magnificent Chef", 27.5, 50, 25, 30, 45, 60);
            wrongInstance = new Artwork(1, "Magnificent Chefs", 34, 64, 25, 30, 45, 60);
            nearInstanceUpper = new Artwork(1, "Magnificent Chefu", 29.99, 59.99, 25, 30, 45, 60);
            nearInstanceLower = new Artwork(1, "Magnificent Chefu", 25.01, 45.01, 25, 30, 45, 60);
        }

        [TestMethod()]
        public void ValidateTempHumiTestOK()
        {
            //act
            correctInstance.Validate();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateTempHumiTestFail()
        {
            //act
            wrongInstance.Validate();
        }

        [TestMethod()]
        public void ValidateTempHumiTestNearOK()
        {
            //act
            nearInstanceUpper.Validate();
            nearInstanceLower.Validate();
        }
    }
}