using LmInterpreterLib;

namespace LearningMachineLib
{
    public abstract class LmParser : IParser
    {
        public virtual void Parse(string program)
        {
            program = Cleaner.Clean(program);
        }
        public abstract void CreateProgram();
    }
}
