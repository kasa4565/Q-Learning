using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWpfApp.Helpers
{
    public class MazeSettings
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
        public int QuantityOfColumns { get; set; }
        public int QuantityOfRows { get; set; }
        public int SizeOfCell { get; set; }
        public double MazeWidth => QuantityOfColumns * SizeOfCell;
        public double MazeHeight => QuantityOfRows * SizeOfCell;
        public double StartXPos => XPos - MazeWidth / 2;
        public double StartYPos => YPos - MazeHeight / 2;
        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }
    }
}
