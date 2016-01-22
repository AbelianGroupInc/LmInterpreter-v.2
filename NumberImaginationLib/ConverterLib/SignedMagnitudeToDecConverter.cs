using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class SignedMagnitudeToDecConverter : IToDecNumberConverter
    {
        private int mBitCapacity;

        public SignedMagnitudeToDecConverter(int bitCapacity)
        {
            if (bitCapacity <= 0)
                throw new ConverterException(ConverterExceptions.InvalidBitCapacity);

            mBitCapacity = bitCapacity;
        }

        public string Convert(string number)
        {
            throw new NotImplementedException();
        }
    }
}
