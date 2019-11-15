using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkGenerator
{
    public class Matrix
    {
        public readonly int row;
        public readonly int col;
        private int[,] matrix;

        public Matrix(int row, int col)
        {
            this.row = row;
            this.col = col;

            matrix = new int[row, col];
            for(int r = 0; r < row; r++)
            {
                for(int c = 0; c < col; col++)
                {
                    matrix[r, c] = 0;
                }
            }
        }

        public int GetValue(int row, int col)
        {
            return matrix[row, col];
        }

        public void SetValue(int row, int col, int value)
        {
            matrix[row, col] = value;
        }
    }
}
