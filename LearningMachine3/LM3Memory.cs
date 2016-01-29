using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningMachineLib;
using LmInterpreterLib;

namespace LearningMachine3
{
    // Memory organisation of LM 3
    public class LM3Memory
    {
        private int cLM3MemoryVolume = 65536;
        private Dictionary<string, IMemoryCell> mMemoryCellList;

        public Dictionary<string, IMemoryCell> MemoryCellList
        {
            get
            {
                return mMemoryCellList;
            }
        }

        public LM3Memory()
        {
            mMemoryCellList = new Dictionary<string, IMemoryCell>(cLM3MemoryVolume);
            
            for(int i = 0; i < cLM3MemoryVolume; i++)
                mMemoryCellList.Add(i.ToString(), new EmptyCell());
        }

        public IMemoryCell GetCellByAddress(string address)
        {
            TestForAddressCorrectness(address);

            TestForCellEmptyness(address);

            return mMemoryCellList[address];
        }
        public void SetCellByAddress(string address, IMemoryCell cellContent)
        {
            TestForAddressCorrectness(address);

            mMemoryCellList[address] = cellContent;
        }

        public void TestForAddressCorrectness(string address)
        {
            if (Convert.ToInt32(address) < 0 || Convert.ToInt32(address) >= cLM3MemoryVolume)
                throw new MemoryException(MemoryExceptionsMessages.MemoryBoundsViolation);
        }

        public void TestForCellEmptyness(string address)
        {
            if (mMemoryCellList[address] is EmptyCell)
                throw new MemoryException(MemoryExceptionsMessages.AccessToUninitializedAddress);
        }
    }
}
