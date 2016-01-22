using System;
using NumberImagination.ConverterLib;
using NumberImagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Tests for Converter
namespace ConverterTests
{
    [TestClass]
    public class FromDecNumberConverterTests
    {
        [TestMethod]
        [ExpectedException(typeof(NumberImaginationException),
    "Неправильное представление числа")]
        public void TestForDecNumberCorrectness()
        {
            NumberImagination.ConverterLib.Converter.Convert(new DecToComplCodeConverter(5),
                "412b578");
        }

        [TestMethod]
        [ExpectedException(typeof(NumberImaginationException),
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
            Assert.AreEqual("01000",
                NumberImagination.ConverterLib.Converter.Convert(new DecToComplCodeConverter(5), "8"));

            Assert.AreEqual("101100101101",
                NumberImagination.ConverterLib.Converter.Convert(new DecToComplCodeConverter(12), "-1235"));
        }
        [TestMethod]
        public void TestForConvertationToSignedMagnitude()
        {
            Assert.AreEqual("01000",
                NumberImagination.ConverterLib.Converter.Convert(new DecToSignedMagnitude(5), "8"));

            Assert.AreEqual("110011010011",
                NumberImagination.ConverterLib.Converter.Convert(new DecToSignedMagnitude(12), "-1235"));
        }
        [TestMethod]
        public void TestForNonsignificantZeroes()
        {
            Assert.AreEqual("00005",
                NumberManipulation.AddNonsignificantZeroes("5", 5));
        }
        [TestMethod]
        [ExpectedException(typeof(NumberImaginationException),
    "Неправильно указанная разрядность числа")]
        public void TestForNonsignificantZeroesException()
        {
            NumberManipulation.AddNonsignificantZeroes("500", 2);
        }
    }
}
