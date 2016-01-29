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
    public class LM3Memory : IMemoryOrganisation
    {
        private int cLM3MemoryVolume = 65536;
        private Dictionary<string, IMemoryCell> mMemoryCellList;

        public Dictionary<string, Object> MemoryCellList
        {
            get
            {
                return GetMemoryObjectDictionary();
            }
        }

        public LM3Memory()
        {
            mMemoryCellList = new Dictionary<string, IMemoryCell>(cLM3MemoryVolume);
            
            for(int i = 0; i < cLM3MemoryVolume; i++)
                mMemoryCellList.Add(i.ToString(), new EmptyCell());
        }

        public object GetCellByAddress(string address)
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

        private Dictionary<string, Object> GetMemoryObjectDictionary()
        {
            Dictionary<string, Object> resultingDictionary = new Dictionary<string,object>(cLM3MemoryVolume);

            foreach (var cell in mMemoryCellList)
                resultingDictionary.Add(cell.Key, cell.Value);

            return resultingDictionary;
        }
    }
}
