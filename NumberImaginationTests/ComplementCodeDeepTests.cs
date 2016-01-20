using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberImagination;

namespace NumberImaginationTests
{
    [TestClass]
    public class ComplementCodeDeepTests
    {
        [TestMethod]
        public void AdditionTest()
        {
            //5 + 5 = 10
            ComplementCode first = new ComplementCode(5, "101");
            ComplementCode second = new ComplementCode(5, "101");

            first = first + second;

            Assert.AreEqual("01010", first.ToString());
        }
        [TestMethod]
        public void AdditionTestTwo()
        {
            // 5 + (-5) = 0
            ComplementCode first = new ComplementCode(5, "101");
            ComplementCode second = new ComplementCode(5, "101");

            first = first + -second;

            Assert.AreEqual("00000", first.ToString());
        }
        [TestMethod]
        public void MinusTest()
        {
            //5 - 7 = (-2)
            ComplementCode first = new ComplementCode(3, "101");
            ComplementCode second = new ComplementCode(3, "111");

            first = first - second;
            first = -first;

            Assert.AreEqual("010", first.ToString());
        }
        [TestMethod]
        public void MultiplyTest()
        {
            //257836 * 583864 = 150541158304
            ComplementCode first = new ComplementCode(40, "111110111100101100");
            ComplementCode second = new ComplementCode(40, "10001110100010111000");

            first = first * second;

            Assert.AreEqual("0010001100001100111100111100011110100000", first.ToString());
        }
        [TestMethod]
        public void MultiplyTestTwo()
        {
            // 5 * -2 = -10
            ComplementCode first = new ComplementCode(4, "101");
            ComplementCode second = new ComplementCode(4, "10");

            first = first * -second;
            first = -first;

            Assert.AreEqual("1010", first.ToString());
        }
        [TestMethod]
        public void DivideTestOne()
        {
            //8 / 4 = 2
            ComplementCode first = new ComplementCode(5, "1000");
            ComplementCode second = new ComplementCode(5, "100");

            first = first / second;

            Assert.AreEqual("00010", first.ToString());
        }
        [TestMethod]
        public void DivideTestTwo()
        {
            //-5 / -5 = 1
            ComplementCode A = new ComplementCode(5, "101");
            ComplementCode B = new ComplementCode(5, "101");

            A = -A / -B;

            Assert.AreEqual("00001", A.ToString());
        }
        [TestMethod]
        public void DivideTestThree()
        {
            // 10 / -5 = -2
            ComplementCode A = new ComplementCode(5, "1010");
            ComplementCode B = new ComplementCode(5, "101");

            A = A / -B;

            Assert.AreEqual("11110", A.ToString());
        }
        [TestMethod]
        public void DivideTestFour()
        {
            //-4 / 2 = -2
            ComplementCode A = new ComplementCode(4, "100");
            ComplementCode B = new ComplementCode(4, "10");

            A = -A / B;

            Assert.AreEqual("1110", A.ToString());
        }
        [TestMethod]
        public void ModulTest()
        {
            //6 % 4 = 2
            ComplementCode A = new ComplementCode(3, "110");
            ComplementCode B = new ComplementCode(3, "100");

            A = A % B;

            Assert.AreEqual("010", A.ToString());
        }
        [TestMethod]
        public void IncremTest()
        {
            // 5++ = 6
            ComplementCode A = new ComplementCode(3, "101");
            // ++5 = 6
            ComplementCode B = new ComplementCode(3, "101");

            A++;
            ++B;

            Assert.AreEqual("110", A.ToString());
            Assert.AreEqual("110", B.ToString());
        }
        [TestMethod]
        public void DecrimTest()
        {
            // --5 = 4
            ComplementCode A = new ComplementCode(3, "101");
            // 5-- = 4
            ComplementCode B = new ComplementCode(3, "101");

            --A;
            B--;

            Assert.AreEqual("100", A.ToString());
            Assert.AreEqual("100", B.ToString());
        }
        [TestMethod]
        public void GreatTest()
        {
            //3 > 2
            ComplementCode A = new ComplementCode(3, "11");
            ComplementCode B = new ComplementCode(3, "10");

            Assert.IsTrue(A > B);
            // 2 > -2
            A = new ComplementCode(3, "10");
            B = new ComplementCode(3, "10");
            B = -B;
            Assert.IsTrue(A > B);
        }
        [TestMethod]
        public void LessTest()
        {
            //2 < 3
            ComplementCode A = new ComplementCode(3, "11");
            ComplementCode B = new ComplementCode(3, "10");

            Assert.IsTrue(B < A);
            //-2 < 2
            A = new ComplementCode(3, "10");
            A = -A;
            B = new ComplementCode(3, "10");
            Assert.IsTrue(A < B);
        }
        [TestMethod]
        public void EqualTest()
        {
            // 5 = 5
            ComplementCode A = new ComplementCode(5, "101");
            ComplementCode B = new ComplementCode(5, "101");

            Assert.IsTrue(A == B);

            //-5 = -5
            A = new ComplementCode(5, "101");
            A = -A;
            B = new ComplementCode(5, "101");
            B = -B;

            Assert.IsTrue(A == B);
        }
        [TestMethod]
        public void GreatOrEqualTestOne()
        {
            //3 => 2
            ComplementCode A = new ComplementCode(3, "11");
            ComplementCode B = new ComplementCode(3, "10");

            Assert.IsTrue(A >= B);
        }
        [TestMethod]
        public void GreatOrEqualTestTwo()
        {
            //3 => 3
            ComplementCode A = new ComplementCode(3, "11");
            ComplementCode B = new ComplementCode(3, "11");

            Assert.IsTrue(A >= B);
        }
        [TestMethod]
        public void GreatOrEqualTestThree()
        {
            //2 => -2
            ComplementCode A = new ComplementCode(3, "10");
            ComplementCode B = new ComplementCode(3, "10");
            B = -B;
            Assert.IsTrue(A >= B);
        }
        [TestMethod]
        public void LessOrEqualTestOne()
        {
            // 3 =< 2
            ComplementCode A = new ComplementCode(3, "11");
            ComplementCode B = new ComplementCode(3, "10");

            Assert.IsTrue(B <= A);
        }
        [TestMethod]
        public void LessOrEqualTestTwo()
        {
            //3 =< 3
            ComplementCode A = new ComplementCode(3, "11");
            ComplementCode B = new ComplementCode(3, "11");

            Assert.IsTrue(A <= B);
        }
        [TestMethod]
        public void LessOrEqualTestThree()
        {
            // 2 =< -2
            ComplementCode A = new ComplementCode(3, "10");
            ComplementCode B = new ComplementCode(3, "10");
            B = -B;
            Assert.IsTrue(B <= A);
        }
        [TestMethod]
        [ExpectedException(typeof(ComlementCodeExeption),
    "Ошибка")]
        public void Exeption()
        {
            ComplementCode A = new ComplementCode(-3, "11");
        }
    }
}
