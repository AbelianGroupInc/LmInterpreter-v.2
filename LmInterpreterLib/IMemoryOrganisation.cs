using System.Collections.Generic;

namespace LmInterpreterLib
{
    public interface IMemoryOrganisation
    {
        // Apealing by address represented in hex number
        object GetCellByAddress(string address);

        Dictionary<string, object> MemoryCellList
        {
            get;
        }
    }
}
