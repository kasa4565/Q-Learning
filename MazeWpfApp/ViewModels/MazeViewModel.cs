using MazeWpfApp.Helpers;
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
        private readonly MazeSettings _Settings;

        public MazeViewModel(MazeSettings settings)
        {
            _Settings = settings;
            Height = _Settings.QuantityOfRows * _Settings.SizeOfCell;
            Width = _Settings.QuantityOfColumns * _Settings.SizeOfCell;
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
            var cells = GetCellsList();

            foreach(var cell in cells)
            {
                lattice.Children.Add(cell);
            }

            return lattice;
        }

        private IEnumerable<CellView> GetCellsList()
        {
            var cells = new List<CellView>();
            int currentX = _Settings.StartXPos;
            int currentY = _Settings.StartYPos;

            for(int rowNumber = 1; rowNumber <= _Settings.QuantityOfRows; rowNumber++)
            {
                for(int columnNumber = 1; columnNumber <= _Settings.QuantityOfColumns; columnNumber++)
                {
                    var cell = new CellView(currentX, currentY, _Settings.SizeOfCell);
                    cells.Add(cell);
                    currentX += _Settings.SizeOfCell;
                }

                currentY += _Settings.SizeOfCell;
                currentX = _Settings.StartXPos;
            }

            return cells;
        }
    }
}
