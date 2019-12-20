﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.InterfaceAndAbstract
{
    public abstract class AbstractSession
    {
        public Guid SessionId { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Ended { get; set; }
        public int TotalTime { get; set; }
        public string ToShow { get; set; }

    }
}
