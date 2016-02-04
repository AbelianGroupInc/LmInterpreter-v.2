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

        // All in hex
        public void AddCommand(string address, string commandNumber, string a1, string a2, string a3)
        {
            address = Convert.ToInt32(address, 16).ToString();

            LM3Command lLM3Command = new LM3Command(commandNumber, Convert.ToInt32(a1, 16), Convert.ToInt32(a2, 16), Convert.ToInt32(a3, 16));
            mLM3Memory.SetCellByAddress(address, lLM3Command);
        }

        public void AddCommandPosition(string address, CommandPosition commandPosition)
        {
            address = Convert.ToInt32(address, 16).ToString();

            mLM3Memory.SetCellPositionByAddress(address, commandPosition);
        }

        public void AddName(string address, string name)
        {
            address = Convert.ToInt32(address, 16).ToString();

            mLM3Memory.SetCellNameByAddress(address, name);
        }
        public void AddVariable(string address, string value)
        {
            address = Convert.ToInt32(address, 16).ToString();

            mLM3Memory.SetCellByAddress(address, new Variable(value));
        }
    }
}
