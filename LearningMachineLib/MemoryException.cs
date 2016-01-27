using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMachineLib
{
    public class MemoryException : Exception
    {
        public MemoryException(string message)
            : base(message) { }
    }
}
