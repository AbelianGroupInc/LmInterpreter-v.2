using System.Collections.Generic;

namespace LmInterpreterLib
{
    public interface IMemoryOrganisation
    {
        string GetAddressValue();
        Dictionary<string, string> GetWholeMemory();
    }
}
