using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMachineLib
{
    public class CommandPosition
    {
        private int mLine;
        private int mStartColumn;
        private int mEndColumn;

        public CommandPosition(int line, int startColumn, int endColumn)
        {
            CheckValue(line);
            CheckValue(startColumn);
            CheckValue(endColumn);

            mLine = line;
            mStartColumn = startColumn;
            mEndColumn = endColumn;
        }

        private void CheckValue(int value)
        {
            if (value < 0)
                throw new Exception();
        }

        public int Line {
            get
            {
                return mLine;
            }
        }

        public int StartColumn
        {
            get
            {
                return mStartColumn;
            }
        }

        public int EndColumn
        {
            get
            {
                return mEndColumn;
            }
        }
    }
}
