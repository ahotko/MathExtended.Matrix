using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Annex.MathExtended.Matrices
{
    public partial class Matrix
    {
        #region Overloaded operators
        public static Matrix operator !(Matrix matrix)
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

        public static Matrix operator -(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.Sub(second);
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
    }
}
