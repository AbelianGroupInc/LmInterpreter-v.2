using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUT
{
    public class SyntaxException : Exception
    {
        private int mRow;
        private int mСolumn;

        public SyntaxException(string message) : base(message) { }

        public SyntaxException(string message, int row, int column) : base(message)
        {
            mRow = row;
            mСolumn = column;
        }

        public int Row
        {
            get
            {
                return mRow;
            }
        }

        public int Column
        {
            get
            {
                return mСolumn;
            }
        }
    }
}
