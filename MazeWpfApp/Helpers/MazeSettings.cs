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
        public double Width => QuantityOfColumns * SizeOfCell;
        public double Height => QuantityOfRows * SizeOfCell;
        public double StartXPos => XPos - Width / 2;
        public double StartYPos => YPos - Height / 2;
    }
}
