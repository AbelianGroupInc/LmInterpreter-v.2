using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public static class Converter
    {
        public static string Convert(IToDecNumberConverter converterToDec,
            IFromDecNumberConverter converterFromDec,
            string numb)
        {
            numb = converterToDec.Convert(numb);
            numb = converterFromDec.Convert(numb);

            return numb;
        }
        public static string Convert(IFromDecNumberConverter converterFromDec,
            string numb)
        {
            return converterFromDec.Convert(numb);
        }
        public static string Convert(IToDecNumberConverter converterToDec,
            string numb)
        {
            return converterToDec.Convert(numb);
        }
    }

}
