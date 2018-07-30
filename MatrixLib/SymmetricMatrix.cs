using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        #region Constants and fields
        private const int DEFAULT_SIZE = 4;
        private T[] _innerMatrix;
        #endregion

        #region .ctors
        public SymmetricMatrix() : base()
        {
            _innerMatrix = new T[DEFAULT_SIZE * DEFAULT_SIZE];
        }

        public SymmetricMatrix(int size) : base(size)
        {
            if (size <= 1)
            {
                throw new ArgumentException($"{nameof(size)} can't be less than 2!");
            }

            _innerMatrix = new T[size * size];
        }
        #endregion

        #region Overrided methods
        public override void PrintMatrix()
        {
            for (int i = 0; i < _innerMatrix.Length; i++)
            {
                if (i != 0 && i % Size != 0)
                {
                    Console.Write(" " + _innerMatrix[i] + " ");
                }
                else if (i == 0)
                {
                    Console.Write(" " + _innerMatrix[i] + " ");
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(" " + _innerMatrix[i] + " ");
                }
            }
            Console.WriteLine();
        }

        protected override T GetValue(int i, int j)
        {
            return _innerMatrix[i * Size + j];
        }

        protected override void SetValue(int i, int j, T value)
        {
            _innerMatrix[i * Size + j] = value;

            if (i != j)
            {
                _innerMatrix[j * Size + i] = value;
            }
        }
        #endregion
    }
}
