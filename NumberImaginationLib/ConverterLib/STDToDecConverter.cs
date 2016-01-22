using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberImagination.ConverterLib
{
    public class STDToDecConverter : IToDecNumberConverter
    {
        private int mFromNumericalSystem;

        // Takes as a parametr numerical system from which is needed to convert
        public STDToDecConverter(int fromNumericalSystem)
        {
            NumberManipulation.TestForNumericalSystemCorrectness(fromNumericalSystem);

            mFromNumericalSystem = fromNumericalSystem;
        }
        public string Convert(string number)
        {
            const int cFirstNumberIndex = 0;

            NumberManipulation.CheckNumberCorrectness(number, mFromNumericalSystem);

            string convertatingNumber = NumberManipulation.GetCommonNumberMantissa(number);

             return NumberManipulation.IsMinusNumber(number) ?
                 '-' + DoConvertation(convertatingNumber, cFirstNumberIndex) :
                 DoConvertation(convertatingNumber, cFirstNumberIndex);
        }

        private string DoConvertation(string number, int curNumberIndex)
        {
            throw new NotImplementedException();

        }
    }
}
