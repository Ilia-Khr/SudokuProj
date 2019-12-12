using SudokuProj.Manipulations;
using SudokuProj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            var randomized = new RandomizeMatrix();

            for (int a = 0; a < 9; a++)
            {

                Console.WriteLine($"{randomized.finalmatrix[a][0]} {randomized.finalmatrix[a][1]} {randomized.finalmatrix[a][2]} {randomized.finalmatrix[a][3]} {randomized.finalmatrix[a][4]} {randomized.finalmatrix[a][5]} {randomized.finalmatrix[a][6]} {randomized.finalmatrix[a][7]} {randomized.finalmatrix[a][8]}");
                Console.ReadKey();
            }


            Console.ReadKey();
        }
    }
}
