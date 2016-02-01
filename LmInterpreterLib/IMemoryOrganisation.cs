using System.Collections.Generic;

namespace LmInterpreterLib
{
    public interface IMemoryOrganisation
    {
        // Apealing by address represented in hex number
        IMemoryCell GetCellByAddress(string address);

        Dictionary<string, IMemoryCell> MemoryCellList
        {
            get;
        }
    }
}
