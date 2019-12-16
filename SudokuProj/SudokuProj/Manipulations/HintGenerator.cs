using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuApp.Manipulations
{
    public class HintGenerator
    {

        public List<int[]> coordinates { get; set; }

        public HintGenerator(int level)
        {
            coordinates = GenerateHint(level);
        }


        private List<int[]> GenerateHint(int level)
        {
            Random random = new Random();
            int hints = 0;
            switch (level)
            {
                default: return null;
                case 1: { hints = 17 * 3; break; }
                case 2: { hints = 17 * 2; break; }
                case 3: { hints = 17; break; }
            }
            List<int[]> coord = new List<int[]>();
            while (coord.Count != hints)
            {
                int a = random.Next(0, 9);
                int b = random.Next(0, 9);
                var match = coord.FirstOrDefault(x => x[0] == a && x[1] == b);
                if (match == null) coord.Add(new int[2] { a, b });
            }
            return coord;
        }
    }
}
