using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmInterpreterLib
{
    public abstract class LearningMachine
    {
        protected OutputSystem mOutputStream;
        protected OutputSystem mErrorStream;
        protected IInputSystem mInputStream;

        public abstract void Execute();
        public abstract void Fill(string program);
        public abstract IMemoryOrganisation GetMemorySection();
    }
}
