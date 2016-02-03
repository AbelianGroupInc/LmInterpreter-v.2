using System;
using System.Collections.Generic;
using LmInterpreterLib;

namespace LearningMachineLib.LearningMachine3
{
    // Memory organisation of LM 3
    public class LM3Memory
    {
        private int cLM3MemoryVolume = 65536;
        private Dictionary<string, IMemoryCell> mMemoryCellList;
        private Dictionary<string, string> mMemoryCellsNames;
        private Dictionary<string, ICommandPosition> mMemoryCellsPositions;

        public Dictionary<string, IMemoryCell> MemoryCellList
        {
            get
            {
                return mMemoryCellList;
            }
        }

        public Dictionary<string, string> MemoryCellsNames
        {
            get
            {
                return mMemoryCellsNames;
            }
        }

        public Dictionary<string, ICommandPosition> MemoryCellsPositions
        {
            get
            {
                return mMemoryCellsPositions;
            }
        }

        public LM3Memory()
        {
            mMemoryCellList = new Dictionary<string, IMemoryCell>(cLM3MemoryVolume);
            mMemoryCellsNames = new Dictionary<string, string>(cLM3MemoryVolume);
            mMemoryCellsPositions = new Dictionary<string, ICommandPosition>(cLM3MemoryVolume);

            for (int i = 0; i < cLM3MemoryVolume; i++)
            {
                mMemoryCellList.Add(i.ToString(), new EmptyCell());
                mMemoryCellsPositions.Add(i.ToString(), new NullCommandPosition());
            }


        }


        #region Methods for memory cell content manipulation
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

        #endregion

        #region Methods for names of memory cells content

        public string GetCellNameByAddress(string address)
        {
            TestForAddressCorrectness(address);

            if (mMemoryCellsNames.ContainsValue(address))
                return mMemoryCellsNames[address];
            else
                return address;
        }

        public void SetCellNameByAddress(string address, string name)
        {
            TestForAddressCorrectness(address);

            mMemoryCellsNames[address] = name;
        }

        #endregion

        #region Methods for memory cells position

        public ICommandPosition GetCellPositionByAddress(string address)
        {
            TestForAddressCorrectness(address);

            return mMemoryCellsPositions[address];
        }

        public void SetCellPositionByAddress(string address, CommandPosition commandPosition)
        {
            TestForAddressCorrectness(address);

            mMemoryCellsPositions[address] = commandPosition;
        }

        #endregion

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
