using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    public class Maze
    {
        public int NumberOfSquares { get; set; }
        public int Start { get; set; }
        public int Goal { get; set; }
        public int[][] Matrix { get; set; }
        public double[][] Reward { get; set; }
        public double[][] Quality { get; set; }
    }
}
