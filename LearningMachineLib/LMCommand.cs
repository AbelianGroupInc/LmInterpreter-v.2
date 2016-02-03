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
        private string mCommandNumber;

        public LMCommand(string commandNumber)
        {
            mCommandNumber = commandNumber;
        }

        public string CommandNumber 
        {
            get
            {
                return mCommandNumber;
            }
        }
    }
}
