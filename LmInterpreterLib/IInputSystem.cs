namespace LmInterpreterLib
{
    public interface IInputSystem
    {
        string GetBuffer();
        void Write(string buffer);
    }
}
