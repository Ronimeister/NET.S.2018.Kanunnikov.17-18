using System;
using System.Collections;
using System.Collections.Generic;

namespace MatrixLib
{
    public abstract class Matrix<T> : IEnumerable<T>
    {
        #region Constants
        private const int DEFAULT_DEMENSION = 4;
        #endregion

        #region Properties, event and indexer
        public event EventHandler<MatrixEventArgs> MatrixChanged;

        public int Size { get; }

        public T this[int i, int j]
        {
            get
            {
                IndexerArgumentsValidation(i, j);
                return GetValue(i, j);
            }
            set
            {
                IndexerArgumentsValidation(i, j);
                ChangeElement(value, i, j);
            }
        }
        #endregion

        #region .ctors
        public Matrix()
        {
            Size = DEFAULT_DEMENSION;
        }

        public Matrix(int size)
        {
            if (size <= 1)
            {
                throw new ArgumentException($"{nameof(size)} can't be less that 2!");
            }

            Size = size;
        }
        #endregion

        #region Private methods
        private void IndexerArgumentsValidation(int i, int j)
        {
            if (i < 0 || j < 0)
            {
                throw new ArgumentOutOfRangeException("Parametrs need to be not less than 0!");
            }

            if (i > Size || j > Size)
            {
                throw new ArgumentOutOfRangeException($"Parametrs need to be not bigger than {nameof(Size)}");
            }
        }
        #endregion

        #region Abstract methods
        public abstract void PrintMatrix();

        protected abstract void SetValue(int i, int j, T value);

        protected abstract T GetValue(int i, int j);        
        #endregion

        #region Event methods
        protected void OnMatrixChanged(object sender, MatrixEventArgs e)
        {
            //Console.WriteLine("Changed!");
            MatrixChanged?.Invoke(sender, e);
        }

        protected void ChangeElement(T value, int i, int j)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} can't be equal to null!");
            }

            IndexerArgumentsValidation(i, j);
            SetValue(i, j, value);
            OnMatrixChanged(this, new MatrixEventArgs(i, j));
        }
        #endregion

        #region IEnumerable methods
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion        
    }

    public sealed class MatrixEventArgs : EventArgs
    {
        private readonly int _row;
        private readonly int _column;

        public int Row => _row;
        public int Column => _column;

        public MatrixEventArgs(int i, int j)
        {
            _row = i;
            _column = j;
        }
    }
}
