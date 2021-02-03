using MazeWpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MazeWpfApp.ViewModels
{
    public class MazeViewModel
    {
        public MazeViewModel()
        {
            Height = 120;
            Width = 160;
            Content = GetMazeVisualization();
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public UIElement Content { get; set; }

        private UIElement GetMazeVisualization()
        {
            return GetLattice();
        }

        private Grid GetLattice()
        {
            var lattice = new Grid();
            var cells = GetCellsList(4,3);

            foreach(var cell in cells)
            {
                lattice.Children.Add(cell);
            }

            return lattice;
        }

        private IEnumerable<CellView> GetCellsList(int quantityOfColumns, int quantityOfRows)
        {
            var cells = new List<CellView>();
            int startX = 1;
            int startY = 1;
            int currentX = startX;
            int currentY = startY;

            for(int rowNumber = 1; rowNumber <= quantityOfRows; rowNumber++)
            {
                for(int columnNumber = 1; columnNumber <= quantityOfColumns; columnNumber++)
                {
                    var cell = new CellView(currentX, currentY);
                    cells.Add(cell);
                    currentX += 40;
                }

                currentY += 40;
                currentX = startX;
            }

            return cells;
        }
    }
}
