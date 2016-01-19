using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberImagination.ConverterLib
{
    public class FromDecToSTDConverter : FromDecNumberConverter
    {
        private int mToNumericalSystem;
        // Takes as a parametr cur numerical system in which is needed to convert
        public FromDecToSTDConverter(int toNumericalSystem)
        {
            TestForNumericalSystemCorrectness(toNumericalSystem);

            mToNumericalSystem = toNumericalSystem;
        }

        public override string Convert(string number)
        {
            CheckNumberCorrectness(number);

            BigInteger numberToConvertation = BigInteger.Parse(number, System.Globalization.NumberStyles.AllowLeadingSign);

            return DoConvert(numberToConvertation);
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
