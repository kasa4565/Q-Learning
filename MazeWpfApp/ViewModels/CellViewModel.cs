using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MazeWpfApp.ViewModels
{
    public class CellViewModel
    {
        public CellViewModel(double topLeftX, double topLeftY)
        {
            Height = 40;
            Width = 40;
            Content = CreateCell(topLeftX, topLeftY);
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public Grid Content { get; set; }
        
        private Grid CreateCell(double topLeftX, double topLeftY)
        {
            var grid = new Grid();

            int shiftBeyondCornersInX = Width - 1;
            int shiftBeyondCornersInY = Height - 1;

            Line topLine = GetLine(topLeftX, topLeftY, topLeftX + shiftBeyondCornersInX, topLeftY);
            grid.Children.Add(topLine);

            Line botLine = GetLine(topLeftX, topLeftY + shiftBeyondCornersInY, topLeftX + shiftBeyondCornersInX, topLeftY + shiftBeyondCornersInY);
            grid.Children.Add(botLine);

            Line leftLine = GetLine(topLeftX, topLeftY, topLeftX, topLeftY + shiftBeyondCornersInY);
            grid.Children.Add(leftLine);

            Line rightLine = GetLine(topLeftX + shiftBeyondCornersInX, topLeftY, topLeftX + shiftBeyondCornersInX, topLeftY + shiftBeyondCornersInY);
            grid.Children.Add(rightLine);

            return grid;
        }

        private static Line GetLine(double x1, double y1, double x2, double y2)
        {
            var line = new Line();

            line.X1 = x1;
            line.Y1 = y1;

            line.X2 = x2;
            line.Y2 = y2;

            line.Stroke = Brushes.Black;
            line.StrokeThickness = 4;

            return line;
        }
    }
}
