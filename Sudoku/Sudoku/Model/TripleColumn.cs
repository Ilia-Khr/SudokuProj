using Sudoku.InterfaceAndAbstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Model
{
    public class TripleColumn : IArea
    {
        Matrix matrix = new Matrix();

        public int[] element1 { get; set; } = new int[9];
        public int[] element2 { get; set; } = new int[9];
        public int[] element3 { get; set; } = new int[9];

        public TripleColumn(int area)
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
            element1 = SetValue(a);
            element2 = SetValue(b);
            element3 = SetValue(c);


        }

        private int[] SetValue(int a)
        {
            var element = new[] { matrix.initialmatrix[0][a], matrix.initialmatrix[1][a], matrix.initialmatrix[2][a], matrix.initialmatrix[3][a], matrix.initialmatrix[4][a], matrix.initialmatrix[5][a], matrix.initialmatrix[6][a], matrix.initialmatrix[7][a], matrix.initialmatrix[8][a] };
            return element;
        }
    }
}
