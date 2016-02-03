using LearningMachineLib;
using LmInterpreterLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMachine2
{
    class LM2Memory : STDLearningMachineMemory
    {
        public override int LMMemoryVolume
        {
            get
            {
                int cLM2MemoryVolume = 65536;

                return cLM2MemoryVolume;
            }
        }
    }
}
