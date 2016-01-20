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
            NumberImagination.ConverterLib.Converter.Convert(new DecToComplCodeConverter(),
                "412b578");
        }

        [TestMethod]
        [ExpectedException(typeof(ConverterException),
    "Неправильно указанная система счисления")]
        public void TestForNumericalSystemException()
        {
            NumberImagination.ConverterLib.Converter.Convert(new DecToSTDConverter(40), "40");
        }

        [TestMethod]
        public void TestForConvertionToSTD()
        {
            Assert.AreEqual("1000",
                NumberImagination.ConverterLib.Converter.Convert(new DecToSTDConverter(2), "8"));

            Assert.AreEqual("4412",
               NumberImagination.ConverterLib.Converter.Convert(new DecToSTDConverter(8), "2314"));

            Assert.AreEqual("52C",
                NumberImagination.ConverterLib.Converter.Convert(new DecToSTDConverter(16), "1324"));

            Assert.AreEqual("-52C",
                NumberImagination.ConverterLib.Converter.Convert(new DecToSTDConverter(16), "-1324"));
        }
        [TestMethod]
        public void TestForConvertationToInversCode()
        {
            Assert.AreEqual("01000",
                NumberImagination.ConverterLib.Converter.Convert(new DecToInversCodeConverter(5), "8"));
            Assert.AreEqual("111110000100",
                NumberImagination.ConverterLib.Converter.Convert(new DecToInversCodeConverter(12), "-123"));
        }
        [TestMethod]
        public void TestForConvertationToComplementCode()
        {
            Assert.AreEqual("1000",
                NumberImagination.ConverterLib.Converter.Convert(new DecToComplCodeConverter(), "8"));

            Assert.AreEqual("101100101101",
                NumberImagination.ConverterLib.Converter.Convert(new DecToComplCodeConverter(), "-1235"));
        }
        [TestMethod]
        public void TestForNonsignificantZeroes()
        {
            Assert.AreEqual("00005",
                new DecToSTDConverter(5).AddNonsignificantZeroes("5", 5));
        }
        [TestMethod]
        [ExpectedException(typeof(ConverterException),
    "Неправильно указанная разрядность числа")]
        public void TestForNonsignificantZeroesException()
        {
            new DecToSTDConverter(5).AddNonsignificantZeroes("500", 2);
        }
    }
}
