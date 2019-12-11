using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj.InterfaceAndAbstract
{
    public interface IArea
    {

        int[][] _area { get; }
        int[] _element1 { get; }
        int[] _element2 { get; }
        int[] _element3 { get; }

    }
}
