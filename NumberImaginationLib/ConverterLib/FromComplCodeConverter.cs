using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class FromComplCodeConverter : IToDecNumberConverter
    {
        public FromComplCodeConverter() { }
        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number, NumberManipulation.cBinNumberSystem);

            ComplementCode complCode = new ComplementCode(number.Length,
                number);

            // Converting complement code to sign magnitude
            string resultingNumber = GetSignMagnitude(complCode);

            // Sign magnitude mantisas to dec code
            resultingNumber = ConverterLib.Converter.ConvertToDecNumber(
                new FromSignedMagnitudeConverter(), resultingNumber);

            if (IsComplCodeMinus(complCode))
                return '-' + resultingNumber;
            else
                return resultingNumber;
        }

        public string GetSignMagnitude(ComplementCode code)
        {
            ComplementCode resultingCode = new ComplementCode(code);

            if (IsComplCodeMinus(code))
                resultingCode = -code;

            return resultingCode.ToString();
        }

        public bool IsComplCodeMinus(ComplementCode code)
        {
            ComplementCode cNull = new ComplementCode(code.ToString().Length, new String('0', code.ToString().Length));

            if (code < cNull)
                return true;
            else
                return false;
        }
    }
}
