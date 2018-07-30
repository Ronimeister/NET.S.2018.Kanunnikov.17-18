using System;

namespace MatrixLib
{
    public class SquareMatrix <T> : Matrix<T>
    {
        #region Constants
        private const int DEFAULT_SIZE = 4;
        #endregion

        #region Private fields
        private T[] _innerArray;
        #endregion

        #region .ctors
        public SquareMatrix() : base()
        {
            _innerArray = new T[DEFAULT_SIZE * DEFAULT_SIZE];
        }

        public SquareMatrix(int size) : base(size)
        {
            if (size <= 1)
            {
                throw new ArgumentException($"{nameof(size)} can't be less than 2!");
            }

            _innerArray = new T[size * size];
        }
        #endregion

        #region Overrided methods
        public override void PrintMatrix()
        {
            for(int i = 0; i < _innerArray.Length; i++)
            {
                if (i != 0 && i % Size != 0)
                {
                    Console.Write(" " + _innerArray[i] + " ");
                }
                else if (i == 0)
                {
                    Console.Write(" " + _innerArray[i] + " ");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(" " + _innerArray[i] + " ");
                }
            }
            Console.WriteLine();
        }

        protected override void SetValue(int i, int j, T value)
        {
            _innerArray[i + j * Size] = value;
        }

        protected override T GetValue(int i, int j)
        {
            return _innerArray[i + j * Size];
        }
        #endregion
    }
}
