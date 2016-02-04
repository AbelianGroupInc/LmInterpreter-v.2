using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberImagination.ConverterLib;

namespace NumberImaginationTests
{
    [TestClass]
    public class ConvertorToDecTests
    {
        [TestMethod]
        public void STDToDecConvertorTest()
        {
            // 100001 - 33
            string number = Converter.ConvertToDecNumber(new FromSTDConverter(2), "100001");
            Assert.AreEqual("33", number);
        }
        [TestMethod]
        public void STDToDecConvertorTestTwo()
        {
            // 100001 - 33
            string number = Converter.ConvertToDecNumber(new FromSTDConverter(2), "-100001");
            Assert.AreEqual("-33", number);
        }
        [TestMethod]
        public void InversToDecConvertorTest()
        {
            // 01100001001 - 777
            string number = Converter.ConvertToDecNumber(new FromInverseCodeConverter(), "01100001001");
            Assert.AreEqual("777", number);
        }
        [TestMethod]
        public void InversToDecConvertorTestTwo()
        {
            // 10011110110 - -777
            string number = Converter.ConvertToDecNumber(new FromInverseCodeConverter(), "10011110110");
            Assert.AreEqual("-777", number);
        }
        [TestMethod]
        public void ComplCodeToDecConvertorTest()
        {
            // 01100001001 - 777
            string number = Converter.ConvertToDecNumber(new FromComplCodeConverter(), "01100001001");
            Assert.AreEqual("777", number);
        }
        [TestMethod]
        public void ComplCodeToDecConvertorTestTwo()
        {
            // 10011110111 - -777
            string number = Converter.ConvertToDecNumber(new FromComplCodeConverter(), "10011110111");
            Assert.AreEqual("-777", number);
        }
    }
}
