using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberImagination.ConverterLib
{
    public class DecToSTDConverter : FromDecNumberConverter
    {
        private int mToNumericalSystem;
        // Takes as a parametr cur numerical system in which is needed to convert
        public DecToSTDConverter(int toNumericalSystem)
        {
            TestForNumericalSystemCorrectness(toNumericalSystem);

            mToNumericalSystem = toNumericalSystem;
        }
        private void TestForNumericalSystemCorrectness(int toNumericalSystem)
        {
            if (toNumericalSystem > 32 || toNumericalSystem <= 1)
                throw new ConverterException(ConverterExceptions.InvalidNumaricalSystem);
        }
        public override string Convert(string number)
        {
            CheckNumberCorrectness(number);

            BigInteger convertatingNumber = BigInteger.Parse(GetMantissa(number),
                System.Globalization.NumberStyles.AllowLeadingSign);

            return IsMinusNumber(number) ? 
                '-' + DoConvert(convertatingNumber) : 
                DoConvert(convertatingNumber);
        }

        // Implements convertation algorithm
        private string DoConvert(BigInteger decNumber)
        {
            if (decNumber != 0)
                return DoConvert(decNumber / mToNumericalSystem) +
                    GetNewNumeralRepresentation(decNumber % mToNumericalSystem);
            else
                return String.Empty;
        }

        // Represent decimal numeral into imagination of new numerical system numeral
        private char GetNewNumeralRepresentation(BigInteger decNumber)
        {
            if (decNumber > 9)
                return (char)((decNumber - 10) + (int)'A');
            else
                return (char)(decNumber + (int)'0');
        }
    }
}
