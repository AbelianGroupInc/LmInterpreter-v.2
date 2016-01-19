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

        protected void TestForNumericalSystemCorrectness(int toNumericalSystem)
        {
            if (toNumericalSystem > 32 || toNumericalSystem <= 1)
                throw new ConverterException(ConverterExceptions.InvalidNumaricalSystem);
        }
        public abstract string Convert(string number);
    }
}
