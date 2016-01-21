using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmInterpreterLib
{
    public class OutputSystem
    {
        private List<IOutputField> mOutputField;

        public void Add(IOutputField outputField)
        {
            mOutputField.Add(outputField);
        }

        public void Remove(IOutputField outputField)
        {
            mOutputField.Remove(outputField);
        }

        public void Clear()
        {
            foreach (var currentOutputField in mOutputField)
                currentOutputField.Clear();
        }

        public void Write(string buffer)
        {
            foreach (var currentOutputField in mOutputField)
                currentOutputField.Write(buffer);
        }
    }
}
