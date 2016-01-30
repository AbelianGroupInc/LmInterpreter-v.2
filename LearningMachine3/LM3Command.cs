using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningMachineLib;

namespace LearningMachineLib.LearningMachine3
{
    class LM3Command : LMCommand
    {
        private int mA1;
        private int mA2;
        private int mA3;

        public LM3Command(int cmd, int a1, int a2, int a3) : base(cmd)
        {
            mA1 = a1;
            mA2 = a2;
            mA3 = a3;
        }

        public int A1 
        {
            get
            {
                return mA1;
            }
        }
        public int A2
        {
            get
            {
                return mA2;
            }
        }
        public int A3
        {
            get
            {
                return mA3;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", CommandNumber, mA1, mA2, mA3);
        }
    }
}
