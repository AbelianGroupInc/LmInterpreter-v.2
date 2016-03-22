using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningMachineLib;
using LmInterpreterLib;

namespace LearningMachineRM
{
    public class LMRM : STDLearningMachine
    {
        private LMRMMemory mLMRMMemory;

        public LMRM(string programParh) : base(programParh)
        {
            mLMRMMemory = new LMRMMemory();
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
            throw new NotImplementedException();
        }

        public void SetCellByAddress(string address, IMemoryCell cell)
        {
            throw new NotImplementedException();
        }
    }
}
