using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj.InterfaceAndAbstract
{
    public abstract class AbstractSession
    {
        public Guid SessionId { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Ended { get; set; }
        public decimal? TotalTimeMinutes { get; set; }

    }
}
