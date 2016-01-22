using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class STDToDecConverter : IToDecNumberConverter
    {
        private int mFromNumericalSystem;

        // Takes as a parametr numerical system from which is needed to convert
        public STDToDecConverter(int fromNumericalSystem)
        {
            NumberManipulation.TestForNumericalSystemCorrectness(fromNumericalSystem);

            mFromNumericalSystem = fromNumericalSystem;
        }
        public string Convert(string number)
        {
            NumberManipulation.CheckNumberCorrectness(number, mFromNumericalSystem);

            // Convertation

            throw new NotImplementedException();
        }
    }
}
