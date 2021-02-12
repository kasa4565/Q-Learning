using MazeWpfApp.Helpers;
using MazeWpfApp.Views;
using Q_Learning;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MazeWpfApp.ViewModels
{
    public class MazeViewModel
    {
        private readonly MazeSettings _Settings;
        private readonly MazeConstructor _Constructor;
        private readonly IEnumerable<CellViewModel> _CellsViewModelsList;

        public MazeViewModel(MazeSettings settings)
        {
            _Settings = settings;
            _Constructor = new MazeConstructor(settings);
            _CellsViewModelsList = GetCellsViewModelsList();

            Content = GetMazeVisualization();
        }

        public UIElement Content { get; set; }

        private UIElement GetMazeVisualization()
        {
            var maze = new Grid();

            maze.Children.Add(GetLatticeGrid());
            maze.Children.Add(GetBorderWalls());
            maze.Children.Add(GetMazeWalls());

            return maze;
        }

        public void VisualizeWalk()
        {
            var intelligence = new Intelligence(_Settings.Maze);
            var moves = intelligence.GetMoves();
            moves = moves.Skip(1);
            moves = moves.Take(moves.Count() - 1);

            
            foreach(var move in moves)
            {
                _CellsViewModelsList.Where(cell => cell.Id == move).First().State = ESquareState.Crossed;
            }
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
            var wall = new WallView(new WallViewModel(_Settings.StartXPos, _Settings.StartYPos, _Settings.StartXPos + _Settings.MazeWidth - 1, _Settings.StartYPos));

            borderWalls.Children.Add(wall);

            //bot border
            wall = new WallView(new WallViewModel(_Settings.StartXPos, _Settings.StartYPos + _Settings.MazeHeight - 1, _Settings.StartXPos + _Settings.MazeWidth - 1, _Settings.StartYPos + _Settings.MazeHeight - 1));

            borderWalls.Children.Add(wall);

            //left border
            wall = new WallView(new WallViewModel(_Settings.StartXPos, _Settings.StartYPos, _Settings.StartXPos, _Settings.StartYPos + _Settings.MazeHeight - 1));

            borderWalls.Children.Add(wall);

            //right border
            wall = new WallView(new WallViewModel(_Settings.StartXPos + _Settings.MazeWidth - 1, _Settings.StartYPos, _Settings.StartXPos + _Settings.MazeWidth - 1, _Settings.StartYPos + _Settings.MazeHeight - 1));

            borderWalls.Children.Add(wall);


            return borderWalls;
        }

        private Grid GetLatticeGrid()
        {
            var lattice = new Grid();

            foreach(var cellViewModel in _CellsViewModelsList)
            {
                if(cellViewModel.Id == _Settings.Maze.Start)
                {
                    cellViewModel.State = ESquareState.IsStart;
                }
                else if(cellViewModel.Id == _Settings.Maze.Goal)
                {
                    cellViewModel.State = ESquareState.IsGoal;
                }

                lattice.Children.Add(new CellView(cellViewModel));
            }

            return lattice;
        }

        private IEnumerable<CellViewModel> GetCellsViewModelsList()
        {
            var cellsViewModels = new List<CellViewModel>();
            var currentX = _Settings.StartXPos;
            var currentY = _Settings.StartYPos;
            int cellId = 0;

            for(int rowNumber = 1; rowNumber <= _Settings.Maze.QuantityOfRows; rowNumber++)
            {
                for(int columnNumber = 1; columnNumber <= _Settings.Maze.QuantityOfColumns; columnNumber++)
                {
                    var cellViewModel = new CellViewModel(cellId, currentX, currentY, _Settings.Maze.SizeOfCell);
                    cellsViewModels.Add(cellViewModel);
                    cellId++;
                    currentX += _Settings.Maze.SizeOfCell;
                }

                currentY += _Settings.Maze.SizeOfCell;
                currentX = _Settings.StartXPos;
            }

            return cellsViewModels;
        }
    }
}
