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
    public class DecToComplCodeConverter : IFromDecNumberConverter
    {
        private int mBitCapacity;
        // Takes as a parametr digital capacity in which is needed to represent resulting code
        public DecToComplCodeConverter(int bitCapacity) 
        {
            if (bitCapacity <= 0)
                throw new ConverterException(ConverterExceptions.InvalidBitCapacity);

            mBitCapacity = bitCapacity;
        }
        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number);

            number = Converter.Convert(new DecToSTDConverter(2), number);

            ComplementCode complCodeRepresentation = new ComplementCode(mBitCapacity,
                NumberManipulation.GetCommonNumberMantissa(number));

            if (NumberManipulation.IsMinusNumber(number))
                complCodeRepresentation = -complCodeRepresentation;

            return complCodeRepresentation.ToString();
        }
    }
}
