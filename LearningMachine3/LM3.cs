using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningMachineLib;
using LmInterpreterLib;

namespace LearningMachine3
{
    // Implementation of Learning machine 3
    public class LM3 : STDLearningMachine
    {
        private LM3Memory mLM3Memory;

        public LM3()
        {
            mLM3Memory = new LM3Memory();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        //Need parametr - program
        public override void Fill(string program)
        {
            throw new NotImplementedException();
        }

        // Returns IMemoryOrganisation
        public override IMemoryOrganisation GetMemorySection()
        {
            return new LM3MemoryToIMemoryOrganisation(mLM3Memory);
        }

        public void SetCellByAddress(string address, IMemoryCell cell)
        {
            mLM3Memory.SetCellByAddress(address, cell);
        }
    }
}
