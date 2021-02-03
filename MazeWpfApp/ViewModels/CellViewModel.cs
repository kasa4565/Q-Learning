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
        public CellViewModel()
        {
            Height = 40;
            Width = 40;
            Content = CreateCell();
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public Grid Content { get; set; }
        
        private Grid CreateCell()
        {
            var grid = new Grid();

            Line topLine = GetLine(1, 1, 40, 1);
            grid.Children.Add(topLine);

            Line botLine = GetLine(1, 40, 40, 40);
            grid.Children.Add(botLine);

            Line leftLine = GetLine(1, 1, 1, 40);
            grid.Children.Add(leftLine);

            Line rightLine = GetLine(40, 1, 40, 40);
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
