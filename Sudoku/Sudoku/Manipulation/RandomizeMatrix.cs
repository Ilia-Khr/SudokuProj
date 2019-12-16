using Sudoku.InterfaceAndAbstract;
using Sudoku.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Manipulation
{
    class RandomizeMatrix
    {
        private int randomitem;
        private int randomarea;

        private int[][] randomvalues = new[]
        {
            new int[3] { 0, 1, 2},
            new int[3] { 2, 0, 1},
            new int[3] { 1, 2, 0},
            new int[3] { 2, 1, 0},
            new int[3] { 1, 0, 2},
            new int[3] { 0, 2, 1}
        };
        public int[][] finalmatrix;

        public RandomizeMatrix()
        {
            Random random = new Random();
            randomarea = random.Next(0, 6);
            FinalMatrix();
        }



        private int[][] RandomizedMatrix(int[][] area1, int[][] area2, int[][] area3)
        {
            int[][] matrix = new[] { new int[9], new int[9], new int[9], new int[9], new int[9], new int[9], new int[9], new int[9], new int[9] };
            SetValue(0, area1, matrix);
            SetValue(1, area2, matrix);
            SetValue(2, area3, matrix);
            return matrix;
        }



        private void SetValue(int a, int[][] area, int[][] matrix)
        {
            matrix[randomvalues[randomarea][a] * 3] = area[0];
            matrix[randomvalues[randomarea][a] * 3 + 1] = area[1];
            matrix[randomvalues[randomarea][a] * 3 + 2] = area[2];
        }



        private int[][] RandomItem(IArea thing)
        {
            Random random = new Random();
            randomitem = random.Next(0, 6);
            int[][] randomized = new[] { new int[9], new int[9], new int[9] };
            randomized[randomvalues[randomitem][0]] = thing.element1;
            randomized[randomvalues[randomitem][1]] = thing.element2;
            randomized[randomvalues[randomitem][2]] = thing.element3;
            return randomized;
        }



        private void FinalMatrix()
        {
            Random random = new Random();
            int check = random.Next(1, 99);
            if (check % 2 == 0)
            {

                var row1 = RandomItem(new TripleRow(1));
                var row2 = RandomItem(new TripleRow(2));
                var row3 = RandomItem(new TripleRow(3));
                finalmatrix = RandomizedMatrix(row1, row2, row3);

            }
            else
            {
                var col1 = RandomItem(new TripleColumn(1));
                var col2 = RandomItem(new TripleColumn(2));
                var col3 = RandomItem(new TripleColumn(3));
                finalmatrix = RandomizedMatrix(col1, col2, col3);
            }
        }
    }
}
