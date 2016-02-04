using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningMachineLib;
using LmInterpreterLib;

namespace LearningMachine2
{
    // Learning Machine 3 Implementation
    class LM2 : STDLearningMachine
    {
        private LM2Memory mLM2Memory;

        public LM2(string programPath) : base (programPath)
        {
            mLM2Memory = new LM2Memory();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Fill()
        {
            throw new NotImplementedException();
        }

        public override IMemoryOrganisation GetMemorySection()
        {
            return new LMMemoryToIMemoryOrganisation(mLM2Memory);
        }

        public void SetCellByAddress(string address, IMemoryCell cell)
        {
            mLM2Memory.SetCellByAddress(address, cell);
        }
    }
}
