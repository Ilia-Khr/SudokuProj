using SudokuProj.InterfaceAndAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj.Model
{
    public class TripleColumn : IArea
    {
        Matrix matrix = new Matrix();
        public int[][] _area { get; private set; }
        public int[] _element1 { get; set; } = new int[9];
        public int[] _element2 { get; set; } = new int[9];
        public int[] _element3 { get; set; } = new int[9];

        public TripleColumn(int area)
        {
            int a; int b; int c;
            if (area == 1)
            {
                a = 0;
                b = 1;
                c = 2;
            }
            if (area == 2)
            {
                a = 3;
                b = 4;
                c = 5;
            }
            if (area == 3)
            {
                a = 6;
                b = 7;
                c = 8;
            }
            else return;
            _element1 = new int[] { matrix.initialmatrix[0][a], matrix.initialmatrix[1][a], matrix.initialmatrix[2][a], matrix.initialmatrix[3][a], matrix.initialmatrix[4][a], matrix.initialmatrix[5][a], matrix.initialmatrix[6][a], matrix.initialmatrix[7][a], matrix.initialmatrix[8][a] };
            _element2 = new int[] { matrix.initialmatrix[0][b], matrix.initialmatrix[1][b], matrix.initialmatrix[2][b], matrix.initialmatrix[3][b], matrix.initialmatrix[4][b], matrix.initialmatrix[5][b], matrix.initialmatrix[6][b], matrix.initialmatrix[7][b], matrix.initialmatrix[8][b] };
            _element2 = new int[] { matrix.initialmatrix[0][c], matrix.initialmatrix[1][c], matrix.initialmatrix[2][c], matrix.initialmatrix[3][c], matrix.initialmatrix[4][c], matrix.initialmatrix[5][c], matrix.initialmatrix[6][c], matrix.initialmatrix[7][c], matrix.initialmatrix[8][c] };
        }

    }
}
