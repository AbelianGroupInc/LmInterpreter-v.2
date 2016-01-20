using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    class STDToDecConverter : ToDecNumberConverter
    {
        private int mFromNumericalSystem;

        // Takes as a parametr numerical system from which is needed to convert
        public STDToDecConverter(int fromNumericalSystem)
        {
            TestForNumericalSystemCorrectness(fromNumericalSystem);

            mFromNumericalSystem = fromNumericalSystem;
        }
        public override string Convert(string number)
        {
            throw new NotImplementedException();
        }
    }
}
