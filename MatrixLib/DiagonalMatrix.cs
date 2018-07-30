using System;

namespace MatrixLib
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        #region Constants and fields
        private const int DEFAULT_SIZE = 4;
        private T[] _innerMatrix;
        #endregion

        #region .ctors
        public DiagonalMatrix() : base()
        {
            _innerMatrix = new T[DEFAULT_SIZE];
        }

        public DiagonalMatrix(int size) : base(size)
        {
            if (size <= 1)
            {
                throw new ArgumentException($"{nameof(size)} can't be less than 2!");
            }

            _innerMatrix = new T[size];
        }
        #endregion

        #region Overrided methods
        public override void PrintMatrix()
        {
            T def = default;
            for (int i = 0; i < _innerMatrix.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write($" {def} ");
                }

                Console.Write($" {_innerMatrix[i]} ");

                for(int j = i + 1; j < _innerMatrix.Length; j++)
                {
                    Console.Write($" {def} ");
                }

                Console.WriteLine();
            }
        }

        protected override T GetValue(int i, int j)
        {
            if (i != j)
            {
                throw new InvalidOperationException("only diagonal elements of the matrix can be changed!");
            }

            return _innerMatrix[i];
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i != j)
            {
                throw new InvalidOperationException("only diagonal elements of the matrix can be changed!");
            }

            _innerMatrix[i] = value;
        }
        #endregion
    }
}
