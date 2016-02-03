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

        LmInterpreter(IParser parser, LearningMachine learningMachine)
        {
            mParser = parser;
            mLearningMachine = learningMachine;
        }

        public void Execute()
        {
            mLearningMachine.Execute();
        }

        public void Read(string program)
        {
            //  разбор программы
            mParser.Parse(program);
            // заполнение памяти 
            mLearningMachine.Fill();
        }
    }
}
