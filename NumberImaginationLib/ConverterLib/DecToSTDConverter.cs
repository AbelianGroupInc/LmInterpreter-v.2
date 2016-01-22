using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberImagination.ConverterLib
{
    public class DecToSTDConverter : IFromDecNumberConverter
    {
        private int mToNumericalSystem;
        // Takes as a parametr cur numerical system in which is needed to convert
        public DecToSTDConverter(int toNumericalSystem)
        {
            NumberManipulation.TestForNumericalSystemCorrectness(toNumericalSystem);

            mToNumericalSystem = toNumericalSystem;
        }
        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number, NumberManipulation.cDecNumberSystem);

            BigInteger convertatingNumber = BigInteger.Parse(NumberManipulation.GetCommonNumberMantissa(number),
                System.Globalization.NumberStyles.AllowLeadingSign);

            return NumberManipulation.IsMinusNumber(number) ? 
                '-' + DoConvertation(convertatingNumber) : 
                DoConvertation(convertatingNumber);
        }

        // Implements convertation algorithm
        private string DoConvertation(BigInteger decNumber)
        {
            if (decNumber != 0)
                return DoConvertation(decNumber / mToNumericalSystem) +
                    NumberManipulation.GetNumeralRepresentation(decNumber % mToNumericalSystem);
            else
                return String.Empty;
        }
    }
}
