using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class DecToInversCodeConverter : FromDecNumberConverter
    {
        private const char cMinusSign = '1';
        private const char cPlusSign = '0';
        // Takes as a parametr digital capacity in which is needed to represent resulting number
        private int mBitCapacity;
        public DecToInversCodeConverter(int bitCapacity) 
        { 
            if(bitCapacity <= 0)
                throw new ConverterException(ConverterExceptions.InvalidBitCapacity);

            mBitCapacity = bitCapacity;
        }

        public override string Convert(string number)
        {
            CheckNumberCorrectness(number);

            string binRepresentation = Converter.Convert(new DecToSTDConverter(2), number);

            StringBuilder inversCode = new StringBuilder(AddNonsignificantZeroes(GetMantissa(binRepresentation), 
                mBitCapacity));

            if (IsMinusNumber(binRepresentation))
                InverseMantissaBits(inversCode);


            return inversCode.ToString();
        }

        private static void InverseMantissaBits(StringBuilder inversCode)
        {
            // i = 1 - beginning of a mantissa
            for (int i = 0; i < inversCode.Length; i++)
            {
                if (inversCode[i] == cMinusSign)
                    inversCode[i] = cPlusSign;
                else
                    inversCode[i] = cMinusSign;
            }
        }
    }
}
