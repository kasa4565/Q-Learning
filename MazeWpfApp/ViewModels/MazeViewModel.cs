using MazeWpfApp.Helpers;
using MazeWpfApp.Views;
using Q_Learning;
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
        private readonly MazeConstructor _Constructor;
        private readonly IEnumerable<CellView> _CellsList;

        public MazeViewModel(MazeSettings settings)
        {
            _Settings = settings;
            _Constructor = new MazeConstructor(MazeExamples.Example_1(), settings);
            _CellsList = GetCellsList();

            Content = GetMazeVisualization();
        }

        public UIElement Content { get; set; }

        

        private UIElement GetMazeVisualization()
        {
            var maze = new Grid();

            maze.Children.Add(GetLatticeGrid(_CellsList));
            maze.Children.Add(GetBorderWalls());
            maze.Children.Add(GetMazeWalls());

            return maze;
        }

        private Grid GetMazeWalls()
        {
            var walls = new Grid();
            var wallsList = _Constructor.GetMazeWallsViews();

            foreach(var wall in wallsList)
            {
                walls.Children.Add(wall);
            }

            return walls;
        }

        private Grid GetBorderWalls()
        {
            var borderWalls = new Grid();

            //top border
            var wall = new WallView(_Settings.StartXPos, _Settings.StartYPos, _Settings.StartXPos + _Settings.MazeWidth - 1, _Settings.StartYPos);

            borderWalls.Children.Add(wall);

            //bot border
            wall = new WallView(_Settings.StartXPos, _Settings.StartYPos + _Settings.MazeHeight - 1, _Settings.StartXPos + _Settings.MazeWidth - 1, _Settings.StartYPos + _Settings.MazeHeight - 1);

            borderWalls.Children.Add(wall);

            //left border
            wall = new WallView(_Settings.StartXPos, _Settings.StartYPos, _Settings.StartXPos, _Settings.StartYPos + _Settings.MazeHeight - 1);

            borderWalls.Children.Add(wall);

            //right border
            wall = new WallView(_Settings.StartXPos + _Settings.MazeWidth - 1, _Settings.StartYPos, _Settings.StartXPos + _Settings.MazeWidth - 1, _Settings.StartYPos + _Settings.MazeHeight - 1);

            borderWalls.Children.Add(wall);


            return borderWalls;
        }

        private Grid GetLatticeGrid(IEnumerable<CellView> cells)
        {
            var lattice = new Grid();

            foreach(var cell in cells)
            {
                if(cell.ViewModel.Id == _Settings.StartSquareIndex)
                {
                    cell.ViewModel.State = ESquareState.IsStart;
                }
                else if(cell.ViewModel.Id == _Settings.MetaSquareIndex)
                {
                    cell.ViewModel.State = ESquareState.IsMeta;
                }

                lattice.Children.Add(cell);
            }

            return lattice;
        }

        private IEnumerable<CellView> GetCellsList()
        {
            var cells = new List<CellView>();
            var currentX = _Settings.StartXPos;
            var currentY = _Settings.StartYPos;
            int cellId = 0;

            for(int rowNumber = 1; rowNumber <= _Settings.QuantityOfRows; rowNumber++)
            {
                for(int columnNumber = 1; columnNumber <= _Settings.QuantityOfColumns; columnNumber++)
                {
                    var cell = new CellView(cellId, currentX, currentY, _Settings.SizeOfCell);
                    cells.Add(cell);
                    cellId++;
                    currentX += _Settings.SizeOfCell;
                }

                currentY += _Settings.SizeOfCell;
                currentX = _Settings.StartXPos;
            }

            return cells;
        }
    }
}
