using System;
using System.Text;

namespace Data.Annex.MathExtended.Matrices
{
    public partial class Matrix
    {
        private double[,] _matrix;

        public int Rows { get { return _matrix.GetLength(0); } }
        public int Columns { get { return _matrix.GetLength(1); } }

        public double this[int row, int column]
        {
            get
            {
                return _matrix[row - 1, column - 1];
            }

            set
            {
                _matrix[row - 1, column - 1] = value;
            }
        }

        public Matrix(int Rows, int Columns)
        {
            _matrix = new double[Rows, Columns];
        }

        /// <summary>
        /// Square Matrix constructor; Creates matrox of size m*x
        /// </summary>
        /// <param name="m"></param>
        public Matrix(int m) : this(m, m)
        { }

        #region Overloaded operators
        public static Matrix operator ~(Matrix matrix)
        {
            var result = matrix.Duplicate();
            result.Inverse();
            return result;
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.Add(second);
            return result;
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.Multiply(second);
            return result;
        }

        public static Matrix operator *(Matrix matrix, double scalar)
        {
            var result = matrix.Duplicate();
            result.Multiply(scalar);
            return result;
        }

        public static Matrix operator *(double scalar, Matrix matrix)
        {
            var result = matrix.Duplicate();
            result.Multiply(scalar);
            return result;
        }

        public static Boolean operator ==(Matrix first, Matrix second)
        {
            bool result = false;
            result = (first.Rows == second.Rows) && (first.Columns == second.Columns);
            if (result)
            {
                for (int row = 1; row <= first.Rows; row++)
                {
                    for (int col = 1; col <= first.Columns; col++)
                    {
                        result &= (first[row, col] == second[row, col]);
                    }
                }
            }
            return result;
        }

        public static Boolean operator !=(Matrix first, Matrix second)
        {
            bool result = false;
            result = (first.Rows != second.Rows) || (first.Columns != second.Columns);
            if (!result)
            {
                for (int row = 1; row <= first.Rows; row++)
                {
                    for (int col = 1; col <= first.Columns; col++)
                    {
                        result |= (first[row, col] != second[row, col]);
                    }
                }
            }
            return result;
        }

        public static Boolean operator >(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) > (second.Rows * second.Columns);
        }

        public static Boolean operator <(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) < (second.Rows * second.Columns);
        }

        public static Boolean operator >=(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) >= (second.Rows * second.Columns);
        }

        public static Boolean operator <=(Matrix first, Matrix second)
        {
            return (first.Rows * first.Columns) <= (second.Rows * second.Columns);
        }

        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix;
            if (obj == null)
            {
                return false;
            }
            bool result = false;
            result = (this.Rows == matrix.Rows) && (this.Columns == matrix.Columns);
            if (result)
            {
                for (int row = 1; row <= this.Rows; row++)
                {
                    for (int col = 1; col <= this.Columns; col++)
                    {
                        result &= (this[row, col] == matrix[row, col]);
                    }
                }
            }
            return result;
        }

        public override int GetHashCode()
        {
            var _matrixString = new StringBuilder();
            _matrixString.Append(this.Rows).Append("x").Append(this.Columns).Append("=");
            for (int row = 1; row <= this.Rows; row++)
            {
                for (int col = 1; col <= this.Columns; col++)
                {
                    _matrixString.Append(this[row, col]).Append(";");
                }
            }
            return _matrixString.ToString().GetHashCode();
        }
        #endregion

        public void Multiply(Matrix Matrix)
        {
            if (Columns != Matrix.Rows)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            var _result = new double[Rows, Matrix.Columns];
            for (int _row = 0; _row < Rows; _row++)
                for (int _col = 0; _col < Matrix.Columns; _col++)
                {
                    double _sum = 0;
                    for (int i = 0; i < Columns; i++)
                        _sum += _matrix[_row, i] * Matrix[i + 1, _col + 1];
                    _result[_row, _col] = _sum;
                }
            _matrix = _result;
        }

        public void HadamardProduct(Matrix Matrix)
        {
            if (Columns != Matrix.Columns || Rows != Matrix.Rows)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            for (int _row = 0; _row < Rows; _row++)
                for (int _col = 0; _col < Columns; _col++)
                {
                    _matrix[_row, _col] *= Matrix[_row + 1, _col + 1];
                }
        }

        public void Multiply(double Scalar)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] *= Scalar;
                }
        }

        public void Add(Matrix Matrix)
        {
            if (Rows != Matrix.Rows || Columns != Matrix.Columns)
                throw new InvalidOperationException("Cannot add matrices of different sizes.");
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] += Matrix[_row + 1, _col + 1];
                }
        }

        public void Zero()
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = 0.0;
                }
        }

        public void Identity()
        {
            if (Rows != Columns)
                throw new InvalidOperationException("Identity matrix must be square.");
            Zero();
            for (int n = 0; n < Rows; n++)
                _matrix[n, n] = 1.0;
        }

        public void Inverse()
        {
            if (Rows != Columns)
                throw new InvalidOperationException("Only square matrices can be inverted.");
            int _dimension = Rows;
            var _result = _matrix.Clone() as double[,];
            var _identity = _matrix.Clone() as double[,];
            //make identity matrix
            for (int _row = 0; _row < _dimension; _row++)
                for (int _col = 0; _col < _dimension; _col++)
                {
                    _identity[_row, _col] = (_row == _col) ? 1.0 : 0.0;
                }
            //invert
            for (int i = 0; i < _dimension; i++)
            {
                double _tmp = _result[i, i];
                for (int j = 0; j < _dimension; j++)
                {
                    _result[i, j] = _result[i, j] / _tmp;
                    _identity[i, j] = _identity[i, j] / _tmp;
                }
                for (int k = 0; k < _dimension; k++)
                {
                    if (i != k)
                    {
                        _tmp = _result[k, i];
                        for (int n = 0; n < _dimension; n++)
                        {
                            _result[k, n] = _result[k, n] - _tmp * _result[i, n];
                            _identity[k, n] = _identity[k, n] - _tmp * _identity[i, n];
                        }
                    }
                }
            }
            _matrix = _identity;
        }

        public void Transpose()
        {
            var _result = new double[Columns, Rows];
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result[_col, _row] = _matrix[_row, _col];
                }
            _matrix = _result;
        }

        public void Map(Func<double, double> func)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = func(_matrix[_row, _col]);
                }
        }

        public void Randomize(double lowest, double highest)
        {
            Random _random = new Random();
            double _diff = highest - lowest;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = (_random.NextDouble() * _diff) + lowest;
                }
        }

        public void Randomize()
        {
            Randomize(0.0, 1.0);
        }

        public Matrix Duplicate()
        {
            var _result = new Matrix(Rows, Columns);
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                {
                    _result[row + 1, col + 1] = _matrix[row, col];
                }
            return _result;
        }
    }
}
