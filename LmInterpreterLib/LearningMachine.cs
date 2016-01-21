﻿namespace LmInterpreterLib
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
