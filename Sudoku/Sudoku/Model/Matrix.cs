using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Model
{
    public class Matrix
    {
        public readonly int[][] initialmatrix = {
            new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new int[9] { 4, 5, 6, 7, 8, 9, 1, 2, 3 },
            new int[9] { 7, 8, 9, 1, 2, 3, 4, 5, 6 },
            new int[9] { 2, 3, 4, 5, 6, 7, 8, 9, 1 },
            new int[9] { 5, 6, 7, 8, 9, 1, 2, 3, 4 },
            new int[9] { 8, 9, 1, 2, 3, 4, 5, 6, 7 },
            new int[9] { 3, 4, 5, 6, 7, 8, 9, 1, 2 },
            new int[9] { 6, 7, 8, 9, 1, 2, 3, 4, 5 },
            new int[9] { 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        };
    }
}
