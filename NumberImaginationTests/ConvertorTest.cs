using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberImagination.ConverterLib;

namespace NumberImaginationTests
{
    [TestClass]
    class ConvertorTest
    {
        [TestMethod]
        public void ConvetToSTDTestOne()
        {
            string number = Converter.Convert(new DecToSTDConverter(2), "40");
            Assert.AreEqual("101000", number);
        }
        [TestMethod]
        public void ConvetToSTDTestTwo()
        {
            string number = Converter.Convert(new DecToSTDConverter(2), "-40");
            Assert.AreEqual("-101000", number);
        }
        [TestMethod]
        public void ConvetToInversTestOne()
        {
            string number = Converter.Convert(new DecToInversCodeConverter(), "777");
            Assert.AreEqual("1100001001", number);
        }
        [TestMethod]
        public void ConvetToInversTestTwo()
        {
            string number = Converter.Convert(new DecToInversCodeConverter(), "-777");
            Assert.AreEqual("10011110110", number);
        }
        [TestMethod]
        public void ConvetToComplementTestOne()
        {
            string number = Converter.Convert(new DecToComplCodeConverter(), "312");
            Assert.AreEqual("100111000", number);
        }
        [TestMethod]
        public void ConvetToComplementTestTwo()
        {
            string number = Converter.Convert(new DecToComplCodeConverter(), "-312");
            Assert.AreEqual("1011001000", number);
        }
    }
}
