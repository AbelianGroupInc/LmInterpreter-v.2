﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmInterpreterLib
{
    public interface IOutputField
    {
        void Clear();
        void Write(string buffer);
    }
}
