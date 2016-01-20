using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    abstract class ToDecNumberConverter: IToDecNumberConverter
    {
        protected void TestForNumericalSystemCorrectness(int toNumericalSystem)
        {
            if (toNumericalSystem > 32 || toNumericalSystem <= 1)
                throw new ConverterException(ConverterExceptions.InvalidNumaricalSystem);
        }
        public abstract string Convert(string number);
    }
}
