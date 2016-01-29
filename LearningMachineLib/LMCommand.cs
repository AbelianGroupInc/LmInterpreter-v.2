using LmInterpreterLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMachineLib
{
    // Stub
    public abstract class LMCommand : IMemoryCell
    {
        private int mCommandNumber;

        public LMCommand(int commandNumber)
        {
            mCommandNumber = commandNumber;
        }

        public int CommandNumber 
        {
            get
            {
                return mCommandNumber;
            }
        }
    }
}
