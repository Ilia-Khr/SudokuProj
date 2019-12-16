using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj.InterfaceAndAbstract
{
    public interface IArea
    {
        int[] element1 { get; }
        int[] element2 { get; }
        int[] element3 { get; }
    }
}
