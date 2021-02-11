using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    public static class MazeExamples
    {
        public static Maze Example_1()
        {
            var maze = new Maze();

            maze.NumberOfSquares = 12;
            maze.Start = 8;
            maze.Goal = 11;
            maze.Matrix = CreateMatrix();
            maze.Reward = CreateReward();
            maze.Quality = CreateQuality(maze.NumberOfSquares);

            int[][] CreateMatrix()
            {
                int[][] FT = new int[maze.NumberOfSquares][];
                for (int i = 0; i < maze.NumberOfSquares; ++i) FT[i] = new int[maze.NumberOfSquares];
                FT[0][1] = FT[0][4] = FT[1][0] = FT[1][5] = FT[2][3] = 1;
                FT[2][6] = FT[3][2] = FT[3][7] = FT[4][0] = FT[4][8] = 1;
                FT[5][1] = FT[5][6] = FT[5][9] = FT[6][2] = FT[6][5] = 1;
                FT[6][7] = FT[7][3] = FT[7][6] = FT[7][11] = FT[8][4] = 1;
                FT[8][9] = FT[9][5] = FT[9][8] = FT[9][10] = FT[10][9] = 1;
                FT[11][11] = 1;  // Goal
                return FT;
            };

            double[][] CreateReward()
            {
                double[][] R = new double[maze.NumberOfSquares][];
                for (int i = 0; i < maze.NumberOfSquares; ++i) R[i] = new double[maze.NumberOfSquares];
                R[0][1] = R[0][4] = R[1][0] = R[1][5] = R[2][3] = -0.1;
                R[2][6] = R[3][2] = R[3][7] = R[4][0] = R[4][8] = -0.1;
                R[5][1] = R[5][6] = R[5][9] = R[6][2] = R[6][5] = -0.1;
                R[6][7] = R[7][3] = R[7][6] = R[7][11] = R[8][4] = -0.1;
                R[8][9] = R[9][5] = R[9][8] = R[9][10] = R[10][9] = -0.1;
                R[7][11] = 10.0;  // Goal
                return R;
            }

            return maze;
        }

        private static double[][] CreateQuality(int numberOfSquares)
        {
            double[][] Q = new double[numberOfSquares][];
            for (int i = 0; i < numberOfSquares; ++i)
                Q[i] = new double[numberOfSquares];
            return Q;
        }
    }
}
