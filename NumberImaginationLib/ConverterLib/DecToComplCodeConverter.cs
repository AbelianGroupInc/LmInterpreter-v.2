using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace NumberImagination.ConverterLib
{
    // Class that implements IFromDecNumberConverter interface
    // Makes convertation from dec numerical system to complement code
    public class DecToComplCodeConverter : FromDecNumberConverter
    {
        public DecToComplCodeConverter() { }
        public override string Convert(string number)
        {
            CheckNumberCorrectness(number);

            number = Converter.Convert(new DecToSTDConverter(2), number);

            ComplementCode complCodeRepresentation = new ComplementCode(number.Length, GetMantissa(number));

            if (IsMinusNumber(number))
                complCodeRepresentation = -complCodeRepresentation;

            return complCodeRepresentation.ToString();
        }
    }
}
