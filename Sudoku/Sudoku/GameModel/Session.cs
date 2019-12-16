using Sudoku.InterfaceAndAbstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.GameModel
{
    public class Session : AbstractSession
    {
        public Session()
        {
            SessionId = Guid.NewGuid();
            Started = DateTime.Now;
        }
    }
}
