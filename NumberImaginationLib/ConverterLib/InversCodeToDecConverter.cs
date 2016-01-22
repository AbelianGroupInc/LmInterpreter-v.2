using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class InversCodeToDecConverter : IToDecNumberConverter
    {
        private int mFromNumericalSystem;

        public InversCodeToDecConverter(int fromNumericalSystem)
        {
            NumberManipulation.TestForNumericalSystemCorrectness(fromNumericalSystem);

            mFromNumericalSystem = fromNumericalSystem;
        }
        public string Convert(string number)
        {
            throw new NotImplementedException();
        }
    }
}
