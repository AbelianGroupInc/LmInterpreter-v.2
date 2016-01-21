using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NumberImagination.ConverterLib
{
    public abstract class FromDecNumberConverter : IFromDecNumberConverter
    {
        protected void CheckNumberCorrectness(string number)
        {
            Regex decNumbRegExp = new Regex(@"^-?[0-9]+$");
            if (!decNumbRegExp.IsMatch(number))
                throw new ConverterException(ConverterExceptions.InvalidDecNumber);
        }
        public abstract string Convert(string number);
        
        public bool IsMinusNumber(string number)
        {
            return number.First() == '-' ? true : false;
        }

        public string GetMantissa(string number)
        {
            string mantiss = String.Empty;
            if (IsMinusNumber(number))
            {
                // 1 - the beginning of number mantiss
                mantiss = number.Substring(1, number.Length - 1);
            }
            else
                mantiss = number;

            return mantiss;
        }

        // Returns number with added nonsignificant zeroes
        public string AddNonsignificantZeroes(string number, int newBitCapacity)
        {
            TestForBitCapacity(number, newBitCapacity);

            String zeroes = new String('0', newBitCapacity - number.Length);

            return zeroes + number;
        }
        public void TestForBitCapacity(string number, int newBitCapacity)
        {
            if (newBitCapacity <= number.Length)
                throw new ConverterException(ConverterExceptions.InvalidBitCapacity);
        }
    }
}
