using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    // How to use: 
    // 1) Send objects which according to their names define a type of convertation 
    // in appropriate function params 
    // 2) In constructors set additional information needed for the appropriate object 
    // (this information is described in the appropriate object file)
    // 3) Result will be returned in the string type
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
        public static string ConvertFromDecNumber(IFromDecNumberConverter converterFromDec,
            string numb)
        {
            return converterFromDec.Convert(numb);
        }
        public static string ConvertToDecNumber(IToDecNumberConverter converterToDec,
            string numb)
        {
            return converterToDec.Convert(numb);
        }
    }

}
