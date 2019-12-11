using SudokuProj.InterfaceAndAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj.Model
{
    public class TripleRow : IArea
    {
        Matrix matrix = new Matrix();
        public int[][] _area { get; private set; }
        public int[] _element1 { get; set; } = new int[9];
        public int[] _element2 { get; set; } = new int[9];
        public int[] _element3 { get; set; } = new int[9];

        public TripleRow(int area)
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
            _element1 = matrix.initialmatrix[a];
            _element2 = matrix.initialmatrix[b];
            _element3 = matrix.initialmatrix[c];
            _area = new int[][] { _element1, _element2, _element3 };


        }

    }
}
