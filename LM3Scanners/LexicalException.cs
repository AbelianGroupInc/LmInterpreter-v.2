using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM3Scanners
{
    public class LexicalException : Exception
    {
        public LexicalException(string message) : base(message) { }
    }
}
