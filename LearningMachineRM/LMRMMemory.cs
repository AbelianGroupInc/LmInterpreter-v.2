using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningMachineLib;

namespace LearningMachineRM
{
    // This have an extension - register memory
    public class LMRMMemory : STDLearningMachineMemory
    {
        private Dictionary<string, string> mRegisters;

        // Need a Constructor

        public override int LMMemoryVolume
        {
            get
            {
                int cLMRMMemoryVolume = 65536;

                return cLMRMMemoryVolume;
            }
        }

        public Dictionary<string, string> Registers
        {
            get
            {
                return mRegisters;
            }
        }

        #region Register memory

        public int LMRegisterMemoryVolume
        {
            get
            {
                int cLMRegisterMemoryVolume = 16;

                return cLMRegisterMemoryVolume;
            }
        }

        public string GetRegisterValue(string address)
        {
            address = Convert.ToInt32(address).ToString();

            TestForRegisterAddressCorrectness(address);

            TestForRegisterValueEmptyness(address);

            return mRegisters[address];
        }

        public void SetRegisterValue(string address, string value)
        {
            // Test for value bit capacity

            address = Convert.ToInt32(address).ToString();

            TestForRegisterAddressCorrectness(address);

            mRegisters[address] = value;
        }

        public void TestForRegisterAddressCorrectness(string address)
        {
            if(Convert.ToInt32(address) < 0 || Convert.ToInt32(address) >= LMRegisterMemoryVolume)
                throw new MemoryException(MemoryExceptionsMessages.MemoryBoundsViolation);
        }

        //Need to get into good shape
        public void TestForRegisterValueEmptyness(string address)
        {
            throw new NotImplementedException();

            /*f (mRegisters[address] is EmptyCell)
                throw new MemoryException(MemoryExceptionsMessages.AccessToUninitializedAddress);*/
        }

        #endregion
    }
}
