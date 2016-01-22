using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class DecToInversCodeConverter : IFromDecNumberConverter
    {
        // Takes as a parametr digital capacity in which is needed to represent resulting code
        private int mBitCapacity;
        public DecToInversCodeConverter(int bitCapacity) 
        { 
            if(bitCapacity <= 0)
                throw new ConverterException(ConverterExceptions.InvalidBitCapacity);

            mBitCapacity = bitCapacity;
        }

        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number, NumberManipulation.cDecNumberSystem);

            string binRepresentation = Converter.Convert(new DecToSTDConverter(2), number);

            StringBuilder inversCode = new StringBuilder(NumberManipulation.AddNonsignificantZeroes(
                NumberManipulation.GetCommonNumberMantissa(binRepresentation), 
                mBitCapacity));

            if (NumberManipulation.IsMinusNumber(binRepresentation))
                InverseMantissaBits(inversCode);


            return inversCode.ToString();
        }

        private static void InverseMantissaBits(StringBuilder inversCode)
        {
            // i = 1 - beginning of a mantissa
            for (int i = 0; i < inversCode.Length; i++)
            {
                if (inversCode[i] == NumberManipulation.cMinusSign)
                    inversCode[i] = NumberManipulation.cPlusSign;
                else
                    inversCode[i] = NumberManipulation.cMinusSign;
            }
        }
    }
}
