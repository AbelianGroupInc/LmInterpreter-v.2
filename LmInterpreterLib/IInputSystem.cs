using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmInterpreterLib
{
    interface IInputSystem
    {
        string GetBuffer();
        void Write(string buffer);
    }
}
