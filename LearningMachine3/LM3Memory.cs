using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMachine3
{
    // Memory organisation of LM 3
    class LM3Memory
    {
        private int cLM3MemoryVolume = 65536;
        private List<IMemoryCell> mMemoryCellList;

        public LM3Memory()
        {
            mMemoryCellList = new List<IMemoryCell>(cLM3MemoryVolume);
            
            for(int i = 0; i < cLM3MemoryVolume; i++)
                mMemoryCellList.Add(new EmptyCell());
        }

        public IMemoryCell GetCellByAddress(int address)
        {
            throw new NotImplementedException();
            // Need to add test for adderss correctness

            return mMemoryCellList[address];
        }

        public List<IMemoryCell> GetWholeMemory()
        {
            return mMemoryCellList;
        }
    }
}
