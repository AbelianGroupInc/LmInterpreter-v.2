using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberImagination.ConverterLib
{
    // Exception for ConverterLib namespace
    public class ConverterException : Exception
    {
        public ConverterException(string message) : base(message)
        {
        }
    }
}
