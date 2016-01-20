using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberImagination;

namespace ConverterTests
{
    [TestClass]
    public class ComplementCodeTests
    {
        [TestMethod]
        public void CreatedTest()
        {
            ComplementCode cc = new ComplementCode(5, "110");
            Assert.AreEqual("00110", cc.ToString());

            cc = new ComplementCode("11010");
            Assert.AreEqual("11010", cc.ToString());

            cc = new ComplementCode(10, "110111");
            Assert.AreEqual("0000110111", cc.ToString());
        }

        [TestMethod]
        public void EqualTest()
        {
            ComplementCode cc1 = new ComplementCode(5, "110");
            ComplementCode cc2 = cc1;
            ComplementCode cc3 = new ComplementCode(5, "110");

            Assert.IsTrue(cc1.Equals(cc2));
            Assert.IsFalse(cc1.Equals(cc3));
            Assert.IsTrue(cc1 == cc3);
        }

        [TestMethod]
        public void AddTest()
        {
            ComplementCode cc1 = new ComplementCode(5, "11111");
            ComplementCode cc2 = new ComplementCode(5, "1");
            ComplementCode cc3 = new ComplementCode(5);

            cc3 = cc1 + cc2;

            Assert.AreEqual("00000", cc3.ToString());
        }

        [TestMethod]
        public void CopyTest()
        {
            ComplementCode cc1 = new ComplementCode(5, "11111");
            ComplementCode cc2 = new ComplementCode(cc1);

            Assert.IsTrue(cc1 == cc2);
            Assert.IsFalse(cc1.Equals(cc2));
        }

        [TestMethod]
        public void ShiftTest()
        {
            ComplementCode cc1 = new ComplementCode(5, "10110");

            cc1 >>= 1;
            Assert.AreEqual("01011", cc1.ToString());

            cc1 >>= 3;
            Assert.AreEqual("00001", cc1.ToString());
        }

        [TestMethod]
        public void ShiftTest2()
        {
            ComplementCode cc1 = new ComplementCode(5, "10110");

            cc1 <<= 1;
            Assert.AreEqual("01100", cc1.ToString());

            cc1 <<= 2;
            Assert.AreEqual("10000", cc1.ToString());
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            ComplementCode cc1 = new ComplementCode(6, "00101");
            ComplementCode cc2 = new ComplementCode(6, "00011");

            cc1 = cc1 * (-cc2);
            Assert.AreEqual("110001", cc1.ToString());
        }

        [TestMethod]
        public void MinusTest()
        {
            ComplementCode cc1 = new ComplementCode(5, "00110");

            cc1 = -cc1;
            Assert.AreEqual("11010", cc1.ToString());
        }

        [TestMethod]
        public void MinusTest2()
        {
            ComplementCode cc1 = new ComplementCode(5, "11010");

            cc1 = -cc1;
            Assert.AreEqual("00110", cc1.ToString());
        }

        [TestMethod]
        public void DivideTest()
        {
            ComplementCode cc1 = new ComplementCode(8, "110100");
            ComplementCode cc2 = new ComplementCode(8, "111");

            cc1 /= cc2;
            Assert.AreEqual("00000111", cc1.ToString());
        }

        [TestMethod]
        public void ModuleTest()
        {
            ComplementCode cc1 = new ComplementCode(8, "110100");
            ComplementCode cc2 = new ComplementCode(8, "111");

            cc1 %= cc2;
            Assert.AreEqual("00000011", cc1.ToString());
        }

        [TestMethod]
        public void LessOrEqualTest()
        {
            ComplementCode cc1 = new ComplementCode(5, "00100");
            ComplementCode cc2 = new ComplementCode(5, "00001");

            Assert.IsFalse(cc1 <= cc2);
        }
    }
}
