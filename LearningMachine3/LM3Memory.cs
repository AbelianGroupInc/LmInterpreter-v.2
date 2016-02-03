using System;
using System.Collections.Generic;
using LmInterpreterLib;

namespace LearningMachineLib.LearningMachine3
{
    // Memory organisation of LM 3
    public class LM3Memory : STDLearningMachineMemory
    {
        public override int LMMemoryVolume
        {
            get
            {
                int cLM3MemoryVolume = 65536;

                return cLM3MemoryVolume;
            }
        }
    }
}
