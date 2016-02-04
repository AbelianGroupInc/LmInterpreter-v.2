using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberImagination.ConverterLib;

namespace NumberImaginationTests
{
    [TestClass]
    public class ConvertorTest
    {
        [TestMethod]
        public void ConvetToSTDTestOne()
        {
            string number = Converter.ConvertFromDecNumber(new ToSTDConverter(2), "40");
            Assert.AreEqual("101000", number);
        }
        [TestMethod]
        public void ConvetToSTDTestTwo()
        {
            string number = Converter.ConvertFromDecNumber(new ToSTDConverter(2), "-40");
            Assert.AreEqual("-101000", number);
        }
        [TestMethod]
        public void ConvetToInversTestOne()
        {
            string number = Converter.ConvertFromDecNumber(new ToInverseCodeConverter(11), "777");
            Assert.AreEqual("01100001001", number);
        }
        [TestMethod]
        public void ConvetToInversTestTwo()
        {
            string number = Converter.ConvertFromDecNumber(new ToInverseCodeConverter(11), "-777");
            Assert.AreEqual("10011110110", number);
        }
        [TestMethod]
        public void ConvetToComplementTestOne()
        {
            string number = Converter.ConvertFromDecNumber(new ToComplCodeConverter(10), "312");
            Assert.AreEqual("0100111000", number);
        }
        [TestMethod]
        public void ConvetToComplementTestTwo()
        {
            string number = Converter.ConvertFromDecNumber(new ToComplCodeConverter(10), "-312");
            Assert.AreEqual("1011001000", number);
        }
    }
}
