using LmInterpreterLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LearningMachineLib
{
    public class Variable : IMemoryCell
    {
        private BigInteger mValue;

        public Variable(BigInteger value)
        {
            mValue = value;
        }

        public BigInteger Value
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
