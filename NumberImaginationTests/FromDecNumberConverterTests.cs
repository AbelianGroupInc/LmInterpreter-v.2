using System;
using NumberImagination.ConverterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Tests for Converter
namespace ConverterTests
{
    [TestClass]
    public class FromDecNumberConverterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ConverterException),
    "Входящая строка не является десятичным числом")]
        public void TestForDecNumberCorrectness()
        {
            NumberImagination.ConverterLib.Converter.Convert(new FromDecToComplCodeConverter(32),
                "412b578");
        }

        [TestMethod]
        [ExpectedException(typeof(ConverterException),
    "Неправильно указанная система счисления")]
        public void TestForNumericalSystemException()
        {
            NumberImagination.ConverterLib.Converter.Convert(new FromDecToSTDConverter(40), "40");
        }

        [TestMethod]
        public void TestForConvertionToBinCode()
        {
            Assert.AreEqual("1000",
                NumberImagination.ConverterLib.Converter.Convert(new FromDecToSTDConverter(2), "8"));

            Assert.AreEqual("4412",
               NumberImagination.ConverterLib.Converter.Convert(new FromDecToSTDConverter(8), "2314"));

            Assert.AreEqual("52C",
                NumberImagination.ConverterLib.Converter.Convert(new FromDecToSTDConverter(16), "1324"));
        }
    }
}
