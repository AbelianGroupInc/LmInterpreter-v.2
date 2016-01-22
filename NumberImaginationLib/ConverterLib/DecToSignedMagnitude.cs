using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class DecToSignedMagnitude : IFromDecNumberConverter
    {
        private int mBitCapacity;
        public DecToSignedMagnitude(int bitCapacity)
        {
            if (bitCapacity <= 0)
                throw new ConverterException(ConverterExceptions.InvalidBitCapacity);

            mBitCapacity = bitCapacity;
        }

        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number, NumberManipulation.cDecNumberSystem);

            number = Converter.Convert(new DecToSTDConverter(2), number);

            StringBuilder signedMagnitude = new StringBuilder(
                NumberManipulation.AddNonsignificantZeroes(
                NumberManipulation.GetCommonNumberMantissa(number),
                mBitCapacity));

            if (NumberManipulation.IsMinusNumber(number))
                signedMagnitude[0] = NumberManipulation.cMinusSign;

            return signedMagnitude.ToString();
        }
    }
}
