using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.InterfaceAndAbstract
{
    public interface IArea
    {
        int[] element1 { get; }
        int[] element2 { get; }
        int[] element3 { get; }
    }
}
