using System;
using NumberImagination.ConverterLib;
using NumberImagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberImaginationTests
{
    [TestClass]
    public class TestForWholeConverter
    {
        [TestMethod]
        public void TestForSTDToSTDConvertation()
        {
            Assert.AreEqual("-140250",
               NumberImagination.ConverterLib.Converter.Convert(new FromSTDConverter(13), new ToSTDConverter(6), "-5c3A"));

            Assert.AreEqual("2101112",
                NumberImagination.ConverterLib.Converter.Convert(new FromSTDConverter(5), new ToSTDConverter(3), "23432"));
           
        }
        [TestMethod]
        public void TestForComplementCodeToSTDConvertation()
        {
            Assert.AreEqual("-1200202",
               NumberImagination.ConverterLib.Converter.Convert(new FromComplCodeConverter(), new ToSTDConverter(3), "101100101101"));

            Assert.AreEqual("111101100101100",
               NumberImagination.ConverterLib.Converter.Convert(new FromComplCodeConverter(), new ToInverseCodeConverter(15), "101100101101"));
        }
        [TestMethod]
        public void HardTest()
        {
            string numb = "-12345678910111213141516171819";
            string resultingNumber = "-12345678910111213141516171819";

            numb = NumberImagination.ConverterLib.Converter.Convert(new FromSTDConverter(10), new ToSTDConverter(3), numb);

            Assert.AreEqual("-21212022022211200011101120021202210000110202101001120221001", numb);

            numb = NumberImagination.ConverterLib.Converter.Convert(new FromSTDConverter(3), new ToSTDConverter(16), numb);

            numb = Converter.Convert(new FromSTDConverter(16), new ToComplCodeConverter(200), numb);

            numb = Converter.Convert(new FromComplCodeConverter(), new ToSTDConverter(10), numb);

            Assert.AreEqual(resultingNumber, numb);
        }
    }
}
