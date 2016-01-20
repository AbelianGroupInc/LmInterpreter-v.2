using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    class InversCodeToDecConverter : ToDecNumberConverter
    {
        private int mFromNumericalSystem;

        public InversCodeToDecConverter(int fromNumericalSystem)
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
