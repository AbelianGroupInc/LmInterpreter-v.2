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
            Assert.AreEqual("8",
                NumberImagination.ConverterLib.Converter.Convert(new STDToDecConverter(2), "1000"));

            Assert.AreEqual("2314",
                NumberImagination.ConverterLib.Converter.Convert(new STDToDecConverter(8), "4412"));

            Assert.AreEqual("1324",
                NumberImagination.ConverterLib.Converter.Convert(new STDToDecConverter(16), "52C"));

            Assert.AreEqual("-1324",
                NumberImagination.ConverterLib.Converter.Convert(new STDToDecConverter(16), "-52C"));
        }

        [TestMethod]
        public void TestForFromInverseConvertation()
        {
            Assert.AreEqual("8",
                NumberImagination.ConverterLib.Converter.Convert(new STDToDecConverter(2), "01000"));

            Assert.AreEqual("-123",
                NumberImagination.ConverterLib.Converter.Convert(new InverseCodeToDecConverter(), "111110000100"));
        }
    }
}
