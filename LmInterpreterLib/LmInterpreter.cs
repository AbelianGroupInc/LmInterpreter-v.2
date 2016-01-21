using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmInterpreterLib
{
    public class LmInterpreter
    {
        LearningMachine mLearningMachine;
        IParser mParser;
        string program;

        public void Execute()
        {
            mLearningMachine.Execute();
        }
        public void Read(string program)
        {
            mParser.Parse(program);
        }
    }
}
