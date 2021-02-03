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

        public double Height { get; set; }
        public double Width { get; set; }
        public UIElement Content { get; set; }

        public double StartXPos => _Settings.XPos - Width / 2;
        public double StartYPos => _Settings.YPos - Height / 2;

        private UIElement GetMazeVisualization()
        {
            var maze = new Grid();

            maze.Children.Add(GetLattice());
            maze.Children.Add(GetBorderWalls());

            return maze;
        }

        private Grid GetBorderWalls()
        {
            var borderWalls = new Grid();

            //top border
            var wall = new WallView(StartXPos, StartYPos, StartXPos + Width - 1, StartYPos);

            borderWalls.Children.Add(wall);

            //bot border
            wall = new WallView(StartXPos, StartYPos + Height - 1, StartXPos + Width - 1, StartYPos + Height - 1);

            borderWalls.Children.Add(wall);

            //left border
            wall = new WallView(StartXPos, StartYPos, StartXPos, StartYPos + Height - 1);

            borderWalls.Children.Add(wall);

            //right border
            wall = new WallView(StartXPos + Width - 1, StartYPos, StartXPos + Width - 1, StartYPos + Height - 1);

            borderWalls.Children.Add(wall);


            return borderWalls;
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
            var currentX = StartXPos;
            var currentY = StartYPos;

            for(int rowNumber = 1; rowNumber <= _Settings.QuantityOfRows; rowNumber++)
            {
                for(int columnNumber = 1; columnNumber <= _Settings.QuantityOfColumns; columnNumber++)
                {
                    var cell = new CellView(currentX, currentY, _Settings.SizeOfCell);
                    cells.Add(cell);
                    currentX += _Settings.SizeOfCell;
                }

                currentY += _Settings.SizeOfCell;
                currentX = StartXPos;
            }

            return cells;
        }
    }
}
