using LmInterpreterLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The general class for std memory of machines machnies overrides some parts and extends this class
namespace LearningMachineLib
{
    public abstract class STDLearningMachineMemory
    {
        private Dictionary<string, IMemoryCell> mMemoryCellList;
        private Dictionary<string, string> mMemoryCellsNames;
        private Dictionary<string, ICommandPosition> mMemoryCellsPositions;

        public abstract int LMMemoryVolume
        {
            get;
        }

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

        public STDLearningMachineMemory()
        {
            mMemoryCellList = new Dictionary<string, IMemoryCell>(LMMemoryVolume);
            mMemoryCellsNames = new Dictionary<string, string>(LMMemoryVolume);
            mMemoryCellsPositions = new Dictionary<string, ICommandPosition>(LMMemoryVolume);

            for (int i = 0; i < LMMemoryVolume; i++)
            {
                mMemoryCellList.Add(i.ToString(), new EmptyCell());
                mMemoryCellsPositions.Add(i.ToString(), new NullCommandPosition());
            }
        }

        #region Methods for memory cell content manipulation
        public IMemoryCell GetCellByAddress(string address)
        {
            // Nonsignificant zeroes deleting
            address = Convert.ToInt32(address).ToString();

            TestForAddressCorrectness(address);

            TestForCellEmptyness(address);

            return mMemoryCellList[address];
        }
        public void SetCellByAddress(string address, IMemoryCell cellContent)
        {
            // Nonsignificant zeroes deleting
            address = Convert.ToInt32(address).ToString();

            TestForAddressCorrectness(address);

            mMemoryCellList[address] = cellContent;
        }

        #endregion

        #region Methods for names of memory cells content

        public string GetCellNameByAddress(string address)
        {
            // Nonsignificant zeroes deleting
            address = Convert.ToInt32(address).ToString();

            TestForAddressCorrectness(address);

            if (mMemoryCellsNames.ContainsKey(address))
                return mMemoryCellsNames[address];
            else
                return address;
        }

        public void SetCellNameByAddress(string address, string name)
        {
            // Nonsignificant zeroes deleting
            address = Convert.ToInt32(address).ToString();

            TestForAddressCorrectness(address);

            mMemoryCellsNames[address] = name;
        }

        #endregion

        #region Methods for memory cells position

        public ICommandPosition GetCellPositionByAddress(string address)
        {
            // Nonsignificant zeroes deleting
            address = Convert.ToInt32(address).ToString();

            TestForAddressCorrectness(address);

            return mMemoryCellsPositions[address];
        }

        public void SetCellPositionByAddress(string address, CommandPosition commandPosition)
        {
            // Nonsignificant zeroes deleting
            address = Convert.ToInt32(address).ToString();

            TestForAddressCorrectness(address);

            mMemoryCellsPositions[address] = commandPosition;
        }
        public void TestForAddressCorrectness(string address)
        {
            if (Convert.ToInt32(address) < 0 || Convert.ToInt32(address) >= LMMemoryVolume)
                throw new MemoryException(MemoryExceptionsMessages.MemoryBoundsViolation);
        }

        public void TestForCellEmptyness(string address)
        {
            if (mMemoryCellList[address] is EmptyCell)
                throw new MemoryException(MemoryExceptionsMessages.AccessToUninitializedAddress);
        }

        #endregion
    }
}
