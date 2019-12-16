using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Model
{
    public class TripleRow : IArea
    {
        Matrix matrix = new Matrix();

        public int[] element1 { get; set; } = new int[9];
        public int[] element2 { get; set; } = new int[9];
        public int[] element3 { get; set; } = new int[9];

        public TripleRow(int area)
        {

            if (area == 1)
            {
                Initiate(0, 1, 2);
            }
            if (area == 2)
            {
                Initiate(3, 4, 5);
            }
            if (area == 3)
            {
                Initiate(6, 7, 8);
            }
            else return;
        }

        private void Initiate(int a, int b, int c)
        {
            element1 = matrix.initialmatrix[a];
            element2 = matrix.initialmatrix[b];
            element3 = matrix.initialmatrix[c];

        }

    }
}
