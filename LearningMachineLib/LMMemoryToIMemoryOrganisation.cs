using LmInterpreterLib;
using System.Collections.Generic;

namespace LearningMachineLib
{
    // The adapter for LMMemories
    public class LMMemoryToIMemoryOrganisation : IMemoryOrganisation
    {
        STDLearningMachineMemory mLMMemory;

        public LMMemoryToIMemoryOrganisation(STDLearningMachineMemory memory)
        {
            mLMMemory = memory;
        }

        // Possible problem with registers
        public Dictionary<string, IMemoryCell> MemoryCellList
        {
            get
            {
                return mLMMemory.MemoryCellList;
            }
        }

        public IMemoryCell GetCellByAddress(string address)
        {
            return mLMMemory.GetCellByAddress(address);
        }
    }
}
