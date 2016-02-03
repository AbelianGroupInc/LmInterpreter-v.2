using System;
using LmInterpreterLib;

namespace LearningMachineLib.LearningMachine3
{
    // Learning machine 3 Implementation
    public class LM3 : STDLearningMachine
    {
        private LM3Memory mLM3Memory;

        public LM3(string programPath) : base(programPath)
        {
            mLM3Memory = new LM3Memory();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Fill()
        {
            LM3ProgramXMLLoader loader = new LM3ProgramXMLLoader(
                new LM3MemoryFiller(mLM3Memory));

            loader.Load(mProgramPath);
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
