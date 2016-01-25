using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class FromSignedMagnitudeConverter : IToDecNumberConverter
    {
        // private int mBitCapacity;

        public FromSignedMagnitudeConverter(){ }

        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number, NumberManipulation.cBinNumberSystem);

            string resultingNumberMantiss = NumberManipulation.GetNumberCodeMantissa(number);

            resultingNumberMantiss = Converter.ConvertToDecNumber(
                new FromSTDConverter(NumberManipulation.cBinNumberSystem), resultingNumberMantiss);

            if (NumberManipulation.IsCodeMinusNumber(number))
                return '-' + resultingNumberMantiss;
            else
                return resultingNumberMantiss;
        }
    }
}
