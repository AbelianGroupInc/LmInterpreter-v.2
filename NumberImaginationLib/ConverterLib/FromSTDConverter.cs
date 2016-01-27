using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberImagination.ConverterLib
{
    public class FromSTDConverter : IToDecNumberConverter
    {
        private int mFromNumericalSystem;

        // Takes as a parametr numerical system from which is needed to convert
        public FromSTDConverter(int fromNumericalSystem)
        {
            NumberManipulation.TestForNumericalSystemCorrectness(fromNumericalSystem);

            mFromNumericalSystem = fromNumericalSystem;
        }
        public string Convert(string number)
        {
            const int cFirstNumberIndex = 0;

            NumberManipulation.CheckNumberCorrectness(number, mFromNumericalSystem);

            string convertatingNumber = NumberManipulation.GetCommonNumberMantissa(number);
            convertatingNumber = DoConvertation(convertatingNumber, cFirstNumberIndex).ToString();

             return NumberManipulation.IsMinusNumber(number) ?
                 '-' + convertatingNumber :
                 convertatingNumber;
        }

        private BigInteger DoConvertation(string number, int curNumberIndex)
        {
            return curNumberIndex < number.Length ?
                NumberManipulation.GetNumeralFromSignRepresentation(number[curNumberIndex]) *
                BigInteger.Pow(mFromNumericalSystem, number.Length - 1 - curNumberIndex) +
                DoConvertation(number, curNumberIndex + 1) :
                0;
        }
    }
}
