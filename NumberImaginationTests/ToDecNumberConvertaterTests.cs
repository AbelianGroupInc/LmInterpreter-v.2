using System;
using NumberImagination.ConverterLib;
using NumberImagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConverterTests
{
    [TestClass]
    public class ToDecNumberConvertation
    {
        [TestMethod]
        public void TestForFromSTDConvertation()
        {
            Assert.AreEqual("213",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromSTDConverter(7), "423"));

            Assert.AreEqual("-1324",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromSTDConverter(16), "-52C"));

            Assert.AreEqual("8",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromSTDConverter(2), "1000"));

            Assert.AreEqual("2314",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromSTDConverter(8), "4412"));

            Assert.AreEqual("1324",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromSTDConverter(16), "52C"));

            Assert.AreEqual("-1324",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromSTDConverter(16), "-52C"));

        }

        [TestMethod]
        public void TestForFromInverseConvertation()
        {
            Assert.AreEqual("8",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromInverseCodeConverter(), "01000"));

            Assert.AreEqual("-123",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromInverseCodeConverter(), "111110000100"));
        }
        [TestMethod]
        public void TestForSignedMagnitudeConvertation()
        {
            Assert.AreEqual("8",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromSignedMagnitudeConverter(), "01000"));

            Assert.AreEqual("-1235",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromSignedMagnitudeConverter(), "110011010011"));
        }

        [TestMethod]
        public void TestForComplementCodeConvertation()
        {
            Assert.AreEqual("8",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromComplCodeConverter(), "01000"));

            Assert.AreEqual("-1235",
                NumberImagination.ConverterLib.Converter.ConvertToDecNumber(new FromComplCodeConverter(), "101100101101"));
        }
    }
}
