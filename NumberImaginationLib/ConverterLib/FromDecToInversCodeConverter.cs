using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class FromDecToInversCodeConverter : FromDecNumberConverter
    {
        private int mToNumericalSystem;
        // Takes as a parametr cur numerical system in which is needed to convert
        public FromDecToInversCodeConverter(int toNumericalSystem)
        {
            TestForNumericalSystemCorrectness(toNumericalSystem);

            mToNumericalSystem = toNumericalSystem;
        }

        public override string Convert(string number)
        {
            CheckNumberCorrectness(number);

            number = Converter.Convert(new FromDecToSTDConverter(2), number);

            throw new NotImplementedException();
        }
    }
}
