using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    public class DecToInversCodeConverter : FromDecNumberConverter
    {
        // Takes as a parametr cur numerical system in which is needed to convert
        public DecToInversCodeConverter() { }

        public override string Convert(string number)
        {
            CheckNumberCorrectness(number);

            StringBuilder binRepresentation = new StringBuilder(Converter.Convert(new DecToSTDConverter(2), number));

            for (int i = 0; i < binRepresentation.Length; i++)
            {
                if (binRepresentation[i] == '0')
                    binRepresentation[i] = '1';
                else
                    binRepresentation[i] = '0';
            }

            return binRepresentation.ToString();
        }
    }
}
