using System;
using System.Linq;
using System.Text;

namespace NumberImagination
{
    public class ComplementCode : IComparable
    {
        private static readonly char cTrueSymbol  = '1';
        private static readonly char cFalseSymbol = '0';

        private bool[] mValue;
        private int mBitCapacity;

        public int BitCapacity
        {
            get
            {
                return mBitCapacity;
            }
        }

        public bool Sign
        {
            get
            {
                return mValue.Last();
            }
        }

        #region Constructors

        public ComplementCode(int bitCapacity, string number) : this(bitCapacity)
        {
            if (number.Length > bitCapacity)
                throw new ComplementCodeException(ComplementCodeExceptions.BitCapacityViolation);

            SetNumber(number);
        }

        public ComplementCode(string number) : this(number.Length)
        {
            SetNumber(number);
        }

        public ComplementCode(int bitCapacity)
        {
            if (bitCapacity <= 0)
                throw new ComplementCodeException(ComplementCodeExceptions.InvalidBitCapacity);

            mValue = new bool[bitCapacity];
            mBitCapacity = bitCapacity;
        }

        public ComplementCode(ComplementCode number) : this(number.BitCapacity)
        {
            Array.Copy(number.mValue, mValue, number.mValue.Length);
        }

        #endregion

        #region  Overloaded methods

        public override string ToString()
        {
            StringBuilder number = new StringBuilder();

            foreach (bool bit in mValue.Reverse())
                number.Append(bit ? cTrueSymbol : cFalseSymbol);

            return number.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return mBitCapacity.GetHashCode() ^ mValue.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            const int cGreater =  1;
            const int cLess    = -1;
            const int cEqual   =  0;

            ComplementCode comparableСode = obj as ComplementCode;

            AreBitCapacityEqual(this, comparableСode);

            if (BitIsLess(Sign, comparableСode.Sign))
                return cGreater;

            if (BitIsGreater(Sign, comparableСode.Sign))
                return cLess;

            for (int i = mValue.Length - 2; i >= 0; i--)
            {
                if (BitIsGreater(mValue[i], comparableСode.mValue[i]))
                    return cGreater;

                if (BitIsLess(mValue[i], comparableСode.mValue[i]))
                    return cLess;
            }

            return cEqual;
        }

        #region Comparison operators 

        public static bool operator !=(ComplementCode a, ComplementCode b)
        {
            return !(a == b);
        }

        public static bool operator ==(ComplementCode a, ComplementCode b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator >(ComplementCode a, ComplementCode b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator <(ComplementCode a, ComplementCode b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator >=(ComplementCode a, ComplementCode b)
        {
            return !(a < b);
        }

        public static bool operator <=(ComplementCode a, ComplementCode b)
        {
            return !(a > b);
        }

        #endregion

        #region Arithmetic operators

        public static ComplementCode operator +(ComplementCode a, ComplementCode b)
        {
            AreBitCapacityEqual(a, b);

            ComplementCode result = new ComplementCode(a.BitCapacity);
            bool transfer = false;

            for (int i = 0; i < a.mValue.Length; i++)
            {
                result.mValue[i] = a.mValue[i] ^ b.mValue[i] ^ transfer;
                transfer = BoolMedian(a.mValue[i], b.mValue[i], transfer);
            }

            return result;
        }

        public static ComplementCode operator -(ComplementCode a, ComplementCode b)
        {
            AreBitCapacityEqual(a, b);

            return a + (-b);
        }

        public static ComplementCode operator -(ComplementCode a)
        {
            ComplementCode result = new ComplementCode(a.BitCapacity);

            for (int i = 0; i < a.mValue.Length; i++)
                result.mValue[i] = !a.mValue[i];

            result++;

            return result;
        }

        public static ComplementCode operator *(ComplementCode a, ComplementCode b)
        {
            AreBitCapacityEqual(a, b);
            ComplementCode result = new ComplementCode(a.BitCapacity);

            ComplementCode regA = Abs(a);
            ComplementCode regB = Abs(b);

            bool sign = a.Sign ^ b.Sign;

            for (int i = 0; i < regA.mValue.Length; i++)
                if (regA.mValue[i])
                    result += regB << i;

            if (sign)
                result = -result;

            return result;
        }

        public static ComplementCode operator /(ComplementCode a, ComplementCode b)
        {
            AreBitCapacityEqual(a, b);

            ComplementCode result = new ComplementCode(a.BitCapacity);
            ComplementCode temp = new ComplementCode(a.BitCapacity);

            ComplementCode regA = Abs(a);
            ComplementCode regB = Abs(b);

            bool sign = a.Sign ^ b.Sign;

            foreach (bool bit in regA.mValue.Reverse())
            {
                temp <<= 1;

                if (bit)
                    temp++;

                result <<= 1;
                if (regB <= temp)
                {
                    result++;
                    temp -= regB;
                }
            }

            if (sign)
                result = -result;

            return result;
        }

        public static ComplementCode operator %(ComplementCode a, ComplementCode b)
        {
            AreBitCapacityEqual(a, b);

            ComplementCode temp = new ComplementCode(a.BitCapacity);

            foreach (bool bit in a.mValue.Reverse())
            {
                temp <<= 1;

                if (bit)
                    temp++;

                if (b <= temp)
                    temp -= b;
            }

            return temp;
        }

        public static ComplementCode operator ++(ComplementCode a)
        {
            ComplementCode cOne = new ComplementCode(a.BitCapacity, cTrueSymbol.ToString());
            ComplementCode result = new ComplementCode(a.BitCapacity);

            result = a + cOne;

            return result;
        }

        public static ComplementCode operator --(ComplementCode a)
        {
            ComplementCode cOne = new ComplementCode(a.BitCapacity, cTrueSymbol.ToString());
            ComplementCode result = new ComplementCode(a.BitCapacity);

            result = a - cOne;

            return result;
        }

        #endregion

        #region Boolean operators
        public static ComplementCode operator >>(ComplementCode a, int shiftLength)
        {
            ComplementCode result = new ComplementCode(a.BitCapacity);

            for (int i = 0; i + shiftLength < a.mValue.Length; i++)
                result.mValue[i] = a.mValue[i + shiftLength];

            return result;
        }

        public static ComplementCode operator <<(ComplementCode a, int shiftLength)
        {
            ComplementCode result = new ComplementCode(a.BitCapacity);

            for (int i = a.mValue.Length - 1; i - shiftLength >= 0; i--)
                result.mValue[i] = a.mValue[i - shiftLength];

            return result;
        }

        #endregion

        #endregion

        #region Ancillary methods

        private void SetNumber(string number)
        {
            // выбор позиции вставки числа
            int numberPosition = number.Length - 1;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != cFalseSymbol && number[i] != cTrueSymbol)
                    throw new ComplementCodeException(ComplementCodeExceptions.InvalidChar);

                mValue[numberPosition - i] = (number[i] == cTrueSymbol);
            }
        }

        private static void AreBitCapacityEqual(ComplementCode a, ComplementCode b)
        {
            if (a.BitCapacity != b.BitCapacity)
                throw new ComplementCodeException(ComplementCodeExceptions.MismatchBitCapacity);
        }

        private static bool BitIsLess(bool a, bool b)
        {
            return a == false && b == true;
        }

        private static bool BitIsGreater(bool a, bool b)
        {
            return a == true && b == false;
        }

        private static bool BoolMedian(bool a, bool b, bool c)
        {
            return (a & b) || (a & c) || (b & c);
        }

        private static ComplementCode Abs(ComplementCode a)
        {
            ComplementCode result = new ComplementCode(a);

            if (a.Sign)
                result = -result;

            return result;

        }

        #endregion
    }
}
