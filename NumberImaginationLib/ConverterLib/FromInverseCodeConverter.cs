using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class FromInverseCodeConverter : IToDecNumberConverter
    {
        public FromInverseCodeConverter() { }
        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number, NumberManipulation.cBinNumberSystem);

            string convertatingNumber = NumberManipulation.GetNumberCodeMantissa(number);
            string resultingNumberMantiss = String.Empty;

            if (NumberManipulation.IsCodeMinusNumber(number)) 
                convertatingNumber = InverseCodeMantissaBits(convertatingNumber);

            resultingNumberMantiss = ConverterLib.Converter.ConvertToDecNumber(
                    new FromSTDConverter(NumberManipulation.cBinNumberSystem),
                    convertatingNumber);

            if (NumberManipulation.IsCodeMinusNumber(number))
                return '-' + resultingNumberMantiss;
            else
                return resultingNumberMantiss;
        }
        private string InverseCodeMantissaBits(string number)
        {
            StringBuilder resultingNumber = new StringBuilder(number);
            // i = 1 - beginning of a mantissa
            for (int i = 0; i < number.Length; i++)
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
