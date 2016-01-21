using System.Collections.Generic;

namespace LmInterpreterLib
{
    public class OutputSystem
    {
        private List<IOutputField> mOutputField = new List<IOutputField>();

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
