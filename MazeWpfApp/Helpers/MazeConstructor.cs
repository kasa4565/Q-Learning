using MazeWpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWpfApp.Helpers
{
    public class MazeConstructor
    {
        private readonly int[][] _AllowableMoves;
        private readonly MazeSettings _Settings;

        public MazeConstructor(int[][] allowableMoves, MazeSettings settings)
        {
            _AllowableMoves = allowableMoves;
            _Settings = settings;
        }

        public IEnumerable<WallView> GetMazeWallsViews()
        {
            var walls = new List<WallView>();
            int countOfSquares = _Settings.QuantityOfColumns * _Settings.QuantityOfRows;

            for (int i = 0; i < countOfSquares; i++)
            {
                for(int j = 0; j < countOfSquares; j++)
                {
                    if (ShouldBeWallBetween(i, j))
                    {
                        var endpoints = GetEndpointsOfWall(i, j);
                        var wall = new WallView(endpoints.x1, endpoints.y1, endpoints.x2, endpoints.y2);
                        walls.Add(wall);
                    }
                }
            }

            return walls;
        }

        private bool ShouldBeWallBetween(int firstSquareIndex, int secondSquareIndex)
        {
            var indexesAreNotTheSame = firstSquareIndex != secondSquareIndex;
            var squaresAreNeighbors = (firstSquareIndex - secondSquareIndex == 1) ||
                                      (secondSquareIndex - firstSquareIndex == 1) ||
                                      (firstSquareIndex - secondSquareIndex == _Settings.QuantityOfColumns) ||
                                      (secondSquareIndex - firstSquareIndex == _Settings.QuantityOfColumns);
            var moveIsNotAllowed = _AllowableMoves[firstSquareIndex][secondSquareIndex] == 0;

            return indexesAreNotTheSame && squaresAreNeighbors && moveIsNotAllowed;
        }

        private (double x1, double y1, double x2, double y2) GetEndpointsOfWall(int firstSquareId, int secondSquareId)
        {
            (double x, double y) firstSquareTopLeftCornerPosition = GetPositionOfSquareTopLeftCorner(firstSquareId);
            double x1 = -1, y1 = -1, x2 = -1, y2 = -1;

            //top wall of first square
            if(firstSquareId == (secondSquareId + _Settings.QuantityOfColumns))
            {
                x1 = firstSquareTopLeftCornerPosition.x;
                y1 = firstSquareTopLeftCornerPosition.y;
                x2 = firstSquareTopLeftCornerPosition.x + _Settings.SizeOfCell;
                y2 = firstSquareTopLeftCornerPosition.y;
            }

            //bottom wall of first square
            if(firstSquareId == (secondSquareId - _Settings.QuantityOfColumns))
            {
                x1 = firstSquareTopLeftCornerPosition.x;
                y1 = firstSquareTopLeftCornerPosition.y + _Settings.SizeOfCell;
                x2 = firstSquareTopLeftCornerPosition.x + _Settings.SizeOfCell;
                y2 = firstSquareTopLeftCornerPosition.y + _Settings.SizeOfCell;
            }

            //left wall of first square
            if(firstSquareId == (secondSquareId + 1))
            {
                x1 = firstSquareTopLeftCornerPosition.x;
                y1 = firstSquareTopLeftCornerPosition.y;
                x2 = firstSquareTopLeftCornerPosition.x;
                y2 = firstSquareTopLeftCornerPosition.y + _Settings.SizeOfCell;
            }

            //right wall of first square
            if(firstSquareId == (secondSquareId - 1))
            {
                x1 = firstSquareTopLeftCornerPosition.x + _Settings.SizeOfCell;
                y1 = firstSquareTopLeftCornerPosition.y;
                x2 = firstSquareTopLeftCornerPosition.x + _Settings.SizeOfCell;
                y2 = firstSquareTopLeftCornerPosition.y + _Settings.SizeOfCell;
            }

            return (x1, y1, x2, y2);
        }

        private (double x, double y) GetPositionOfSquareTopLeftCorner(int index)
        {
            var matrix = GetLatticeMatrix();

            for (int row = 0; row < _Settings.QuantityOfRows; row++)
            {
                for (int column = 0; column < _Settings.QuantityOfColumns; column++)
                {
                    if(matrix[row,column] == index)
                    {
                        double x = (column * _Settings.SizeOfCell) + _Settings.StartXPos;
                        double y = (row * _Settings.SizeOfCell) + _Settings.StartYPos;
                         
                        return (x, y);
                    }
                }
            }

            throw new InvalidOperationException();
        }

        private int[,] GetLatticeMatrix()
        {
            int[,] matrix = new int[_Settings.QuantityOfRows,_Settings.QuantityOfColumns];
            int index = 0;
            
            for(int row = 0; row < _Settings.QuantityOfRows; row++)
            {
                for(int column = 0; column < _Settings.QuantityOfColumns; column++)
                {
                    matrix[row,column] = index;
                    index++;
                }
            }

            return matrix;
        }
    }
}
