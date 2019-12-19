using Sudoku.Manipulation;
using Sudoku.Model;
using Sudoku.Repository;

using System;

namespace Sudoku.Repository
{
    class Program
    {
        static void Main(string[] args)
        {


            var repos = new Repository();
            Console.Write($"{repos.BestSessionCheck(1)} with {repos.Check()}");
            Matrix matrix = new Matrix();
            var randomized = new RandomizeMatrix();
            HintGenerator generator = new HintGenerator(2);
            for (int a = 0; a < 9; a++)
            {

                Console.WriteLine($"{randomized.finalmatrix[a][0]} {randomized.finalmatrix[a][1]} {randomized.finalmatrix[a][2]} {randomized.finalmatrix[a][3]} {randomized.finalmatrix[a][4]} {randomized.finalmatrix[a][5]} {randomized.finalmatrix[a][6]} {randomized.finalmatrix[a][7]} {randomized.finalmatrix[a][8]}");
                Console.ReadKey();
            }
            foreach (int[] coord in generator.coordinates)
            {

                Console.WriteLine($"{randomized.finalmatrix[coord[0]][coord[1]]} at coord{coord[0]} and {coord[1]}");
                Console.ReadKey();
            }


            Console.ReadKey();
        }
    }
}
