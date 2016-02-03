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
            LM3Command lLM3Command = new LM3Command(commandNumber, Convert.ToInt32(a1), Convert.ToInt32(a2), Convert.ToInt32(a3));
            mLM3Memory.SetCellByAddress(address, lLM3Command);
        }

        public void AddCommandPosition(string address, CommandPosition commandPosition)
        {
            mLM3Memory.SetCellPositionByAddress(address, commandPosition);
        }

        public void AddName(string address, string name)
        {
            mLM3Memory.SetCellNameByAddress(address, name);
        }
        public void AddVariable(string address, string value)
        {
            mLM3Memory.SetCellByAddress(address, new Variable(value));
        }
    }
}
