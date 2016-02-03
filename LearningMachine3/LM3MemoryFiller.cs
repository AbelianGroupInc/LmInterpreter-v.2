using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMachineLib.LearningMachine3
{
    public class LM3MemoryFiller
    {
        private LM3Memory mLM3Memory;

        public LM3MemoryFiller(LM3Memory memory)
        {
            mLM3Memory = memory;
        }

        public void AddCommand(string address, string commandNumber, string a1, string a2, string a3)
        {
            throw new NotImplementedException();
        }

        public void AddCommandPosition(string address, CommandPosition commandPostiion)
        {
            throw new NotImplementedException();
        }

        public void AddName(string address, string name)
        {
            throw new NotImplementedException();
        }
        public void AddVariable(string address, string value)
        {
            throw new NotImplementedException();
        }
    }
}
