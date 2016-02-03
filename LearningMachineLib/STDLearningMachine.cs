using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LmInterpreterLib;

namespace LearningMachineLib
{
    public abstract class STDLearningMachine : LearningMachine
    {
        protected int currentAddress;
        protected string mProgramPath;

        public STDLearningMachine(string programPath)
        {
            mProgramPath = programPath;
        }

        // Executor

        // ProgramLoader
    }
}
