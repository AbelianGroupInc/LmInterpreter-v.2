using LmInterpreterLib;
using System.Collections.Generic;

namespace LearningMachineLib
{
    public class LMMemoryToIMemoryOrganisation : IMemoryOrganisation
    {
        STDLearningMachineMemory mLMMemory;

        public LMMemoryToIMemoryOrganisation(STDLearningMachineMemory memory)
        {
            mLMMemory = memory;
        }

        public IMemoryCell GetCellByAddress(string address)
        {
            return mLMMemory.GetCellByAddress(address);
        }

        public Dictionary<string, IMemoryCell> MemoryCellList
        {
            get 
            {
                return mLMMemory.MemoryCellList;
            }
        }
    }
}
