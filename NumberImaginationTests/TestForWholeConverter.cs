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
    }
}
