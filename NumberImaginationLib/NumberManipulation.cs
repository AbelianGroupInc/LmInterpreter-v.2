using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;

namespace NumberImagination
{
    public static class NumberManipulation
    {
        public static readonly char cMinusSign = '1';
        public static readonly char cPlusSign = '0';
        public static readonly int cDecNumberSystem = 10;
        public static readonly int cBinNumberSystem = 2;
        public static void CheckNumberCorrectness(string number, int baseSystem)
        {
            char numSystemLastNumeral = GetNumeralRepresentation(baseSystem - 1);
            Regex decNumbRegExp = new Regex(@"^-?[0-" + numSystemLastNumeral + "]+$");
            if (!decNumbRegExp.IsMatch(number))
                throw new NumberImaginationException(NumberImaginationExceptions.InvalidNumber);
        }

        public static bool IsMinusNumber(string number)
        {
            return number.First() == '-' ? true : false;
        }

        public static string GetCommonNumberMantissa(string number)
        {
            string mantiss = String.Empty;
            if (IsMinusNumber(number))
            {
                // 1 - the beginning of number mantiss
                mantiss = number.Substring(1, number.Length - 1);
            }
            else
                mantiss = number;

            return mantiss;
        }

        public static string GetNumberCodeMantissa(string code)
        {
            // 1 - is the beginning of code mantissa
            return code.Substring(1, code.Length - 1);
        }

        // Returns number with added nonsignificant zeroes
        public static string AddNonsignificantZeroes(string number, int newBitCapacity)
        {
            TestForBitCapacity(number, newBitCapacity);

            String zeroes = new String('0', newBitCapacity - number.Length);

            return zeroes + number;
        }
        public static void TestForBitCapacity(string number, int newBitCapacity)
        {
            if (newBitCapacity <= number.Length)
                throw new NumberImaginationException(NumberImaginationExceptions.InvalidBitCapacity);
        }

        // Represent decimal numeral into imagination of new numerical system numeral
        public static char GetNumeralRepresentation(BigInteger decNumber)
        {
            if (decNumber > 9)
                return (char)((decNumber - 10) + (int)'A');
            else
                return (char)(decNumber + (int)'0');
        }

        public static void TestForNumericalSystemCorrectness(int numericalSystem)
        {
            if (numericalSystem > 32 || numericalSystem <= 1)
                throw new NumberImaginationException(NumberImaginationExceptions.InvalidNumaricalSystem);
        }
    }
}
