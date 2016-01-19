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
    public class FromDecToComplCodeConverter : FromDecNumberConverter
    {
        private int mToNumericalSystem;
        // Takes as a parametr cur numerical system in which is needed to convert
        public FromDecToComplCodeConverter(int toNumericalSystem)
        {
            TestForNumericalSystemCorrectness(toNumericalSystem);

            mToNumericalSystem = toNumericalSystem;
        }
        public override string Convert(string number)
        {
            CheckNumberCorrectness(number);

            number = Converter.Convert(new FromDecToSTDConverter(2), number);

            // Convert to invers code

            // Convert to complement code

            throw new NotImplementedException();
        }
    }
}
