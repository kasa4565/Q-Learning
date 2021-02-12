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
            _Constructor = new MazeConstructor(settings);
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

        public void VisualizeWalk(Maze maze)
        {
            var intelligence = new Intelligence(maze);
            var moves = intelligence.GetMoves();
            moves = moves.Skip(1);
            moves = moves.Take(moves.Count() - 1);

            
            foreach(var move in moves)
            {
                _CellsList.Where(cell => cell.ViewModel.Id == move).First().ViewModel.State = ESquareState.Crossed;
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
                if(cell.ViewModel.Id == _Settings.Maze.Start)
                {
                    cell.ViewModel.State = ESquareState.IsStart;
                }
                else if(cell.ViewModel.Id == _Settings.Maze.Goal)
                {
                    cell.ViewModel.State = ESquareState.IsGoal;
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

            for(int rowNumber = 1; rowNumber <= _Settings.Maze.QuantityOfRows; rowNumber++)
            {
                for(int columnNumber = 1; columnNumber <= _Settings.Maze.QuantityOfColumns; columnNumber++)
                {
                    var cell = new CellView(cellId, currentX, currentY, _Settings.Maze.SizeOfCell);
                    cells.Add(cell);
                    cellId++;
                    currentX += _Settings.Maze.SizeOfCell;
                }

                currentY += _Settings.Maze.SizeOfCell;
                currentX = _Settings.StartXPos;
            }

            return cells;
        }
    }
}
