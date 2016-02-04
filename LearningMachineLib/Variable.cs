using LmInterpreterLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using NumberImagination;
using NumberImagination.ConverterLib;

namespace LearningMachineLib
{
    public class Variable : IMemoryCell
    {
        private BigInteger cLM3BitCapacity = BigInteger.Pow(2, 56);
        private ComplementCode mValue;

        public Variable(string value)
        {
            string decRepresentationString = Converter.ConvertToDecNumber(new FromSTDConverter(16), value);
            BigInteger decRepresentationBigInt = BigInteger.Parse(decRepresentationString,
                System.Globalization.NumberStyles.AllowLeadingSign);

            decRepresentationBigInt = decRepresentationBigInt % cLM3BitCapacity;

            ComplementCode complRepresentation = new ComplementCode(
                Converter.Convert(new FromSTDConverter(10), new ToComplCodeConverter(56), decRepresentationBigInt.ToString()));

            mValue = complRepresentation;
        }

        public ComplementCode Value
        {
            get
            {
                return mValue;
            }
        }

        public override string ToString()
        {
            return mValue.ToString();
        }
    }
}
