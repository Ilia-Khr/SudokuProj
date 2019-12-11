using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj.InterfaceAndAbstract
{
    public abstract class AbstractSession
    {
        private Guid SessionId { get; set; }
        public DateTime Started { get; set; }
        private DateTime? Ended { get; set; }
        public decimal? TotalTimeMinutes { get => (decimal)Ended?.Subtract(Started).TotalMinutes; }

    }
}
