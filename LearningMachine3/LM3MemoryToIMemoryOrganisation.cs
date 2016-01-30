using LmInterpreterLib;
using System.Collections.Generic;

namespace LearningMachineLib.LearningMachine3
{
    class LM3MemoryToIMemoryOrganisation : IMemoryOrganisation
    {
        LM3Memory mLM3Memory;

        public LM3MemoryToIMemoryOrganisation(LM3Memory memory)
        {
            mLM3Memory = memory;
        }

        public IMemoryCell GetCellByAddress(string address)
        {
            return mLM3Memory.GetCellByAddress(address);
        }

        public Dictionary<string, IMemoryCell> MemoryCellList
        {
            get 
            {
                return mLM3Memory.MemoryCellList;
            }
        }
    }
}
