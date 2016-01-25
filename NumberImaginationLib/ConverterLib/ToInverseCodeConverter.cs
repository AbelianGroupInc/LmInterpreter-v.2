using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class ToInverseCodeConverter : IFromDecNumberConverter
    {
        // Takes as a parametr digital capacity in which is needed to represent resulting code
        private int mBitCapacity;
        public ToInverseCodeConverter(int bitCapacity) 
        { 
            if(bitCapacity <= 0)
                throw new ConverterException(ConverterExceptions.InvalidBitCapacity);

            mBitCapacity = bitCapacity;
        }

        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number, NumberManipulation.cDecNumberSystem);

            string binRepresentation = Converter.ConvertFromDecNumber(new ToSTDConverter(2), number);

            string inverseCode = NumberManipulation.AddNonsignificantZeroes(
                NumberManipulation.GetCommonNumberMantissa(binRepresentation), 
                mBitCapacity);

            if (NumberManipulation.IsMinusNumber(binRepresentation))
                inverseCode = InverseMantissaBits(inverseCode);


            return inverseCode.ToString();
        }

        private static string InverseMantissaBits(string inverseCode)
        {
            StringBuilder resultingNumber = new StringBuilder(inverseCode);
            // i = 1 - beginning of a mantissa
            for (int i = 0; i < inverseCode.Length; i++)
            {
                if (resultingNumber[i] == NumberManipulation.cMinusSign)
                    resultingNumber[i] = NumberManipulation.cPlusSign;
                else
                    resultingNumber[i] = NumberManipulation.cMinusSign;
            }

            return resultingNumber.ToString();
        }
    }
}
