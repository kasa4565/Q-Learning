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

            maze.Id = 1;
            maze.NumberOfSquares = 12;
            maze.Start = 8;
            maze.Goal = 11;
            maze.QuantityOfColumns = 4;
            maze.QuantityOfRows = 3;
            maze.SizeOfCell = 50;
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

        public static Maze Example_2()
        {
            var maze = new Maze();

            maze.Id = 2;
            maze.NumberOfSquares = 60;
            maze.Start = 0;
            maze.Goal = 9;
            maze.QuantityOfColumns = 10;
            maze.QuantityOfRows = 6;
            maze.SizeOfCell = 50;
            maze.Matrix = CreateMatrix();
            maze.Reward = CreateReward();
            maze.Quality = CreateQuality(maze.NumberOfSquares);

            int[][] CreateMatrix()
            {
                int[][] FT = new int[maze.NumberOfSquares][];
                for (int i = 0; i < maze.NumberOfSquares; ++i) FT[i] = new int[maze.NumberOfSquares];
                FT[0][1] = FT[1][0] = FT[1][2] = FT[2][1] = FT[2][12] = FT[3][4] = 1;
                FT[3][13] = FT[4][3] = FT[4][5] = FT[5][4] = FT[5][6] = 1;
                FT[6][5] = FT[6][7] = FT[7][6] = FT[8][18] = FT[10][20] = 1;
                FT[11][12] = FT[12][11] = FT[12][2] = FT[12][13] = FT[13][12] = 1;
                FT[13][3] = FT[13][23] = FT[14][15] = FT[14][24] = FT[15][14] = 1;
                FT[15][16] = FT[15][25] = FT[16][15] = FT[16][17] = FT[17][16] = 1;
                FT[17][18] = FT[18][17] = FT[18][8] = FT[19][9] = FT[19][29] = 1;
                FT[20][10] = FT[20][21] = FT[21][20] = FT[21][22] = FT[22][21] = 1;
                FT[22][23] = FT[22][32] = FT[23][22] = FT[23][13] = FT[23][24] = 1;
                FT[24][23] = FT[24][14] = FT[24][34] = FT[25][15] = FT[25][26] = 1;
                FT[25][35] = FT[26][25] = FT[26][27] = FT[27][26] = FT[27][28] = 1;
                FT[28][27] = FT[28][38] = FT[29][19] = FT[29][39] = FT[30][31] = 1;
                FT[30][40] = FT[31][30] = FT[31][32] = FT[32][31] = FT[32][22] = 1;
                FT[32][42] = FT[33][34] = FT[34][33] = FT[34][24] = FT[34][44] = 1;
                FT[35][25] = FT[35][45] = FT[36][37] = FT[36][46] = FT[37][36] = 1;
                FT[37][47] = FT[38][28] = FT[38][48] = FT[39][29] = FT[39][49] = 1;
                FT[40][30] = FT[40][50] = FT[41][51] = FT[42][32] = FT[42][52] = 1;
                FT[43][53] = FT[44][34] = FT[44][54] = FT[45][35] = FT[45][55] = 1;
                FT[46][36] = FT[47][37] = FT[47][57] = FT[48][38] = FT[48][49] = 1;
                FT[49][48] = FT[49][39] = FT[50][40] = FT[50][51] = FT[51][50] = 1;
                FT[51][41] = FT[52][42] = FT[52][53] = FT[53][52] = FT[53][43] = 1;
                FT[54][44] = FT[55][45] = FT[55][56] = FT[56][55] = FT[56][57] = 1;
                FT[57][56] = FT[57][47] = FT[57][58] = FT[58][57] = FT[58][59] = 1;
                FT[59][58] = 1;
                FT[9][9] = 1; //Goal
                return FT;
            };

            double[][] CreateReward()
            {
                double[][] R = new double[maze.NumberOfSquares][];
                for (int i = 0; i < maze.NumberOfSquares; ++i) R[i] = new double[maze.NumberOfSquares];
                R[0][1] = R[1][2] = R[2][1] = R[2][12] = R[3][4] = -0.01;
                R[3][13] = R[4][3] = R[4][5] = R[5][4] = R[5][6] = -0.01;
                R[6][5] = R[6][7] = R[7][6] = R[8][18] = R[10][20] = -0.01;
                R[11][12] = R[12][11] = R[12][2] = R[12][13] = R[13][12] = -0.01;
                R[13][3] = R[13][23] = R[14][15] = R[14][24] = R[15][14] = -0.01;
                R[15][16] = R[15][25] = R[16][15] = R[16][17] = R[17][16] = -0.01;
                R[17][18] = R[18][17] = R[18][8] = R[19][9] = R[19][29] = -0.01;
                R[20][10] = R[20][21] = R[21][20] = R[21][22] = R[22][21] = -0.01;
                R[22][23] = R[22][32] = R[23][22] = R[23][13] = R[23][24] = -0.01;
                R[24][23] = R[24][14] = R[24][34] = R[25][15] = R[25][26] = -0.01;
                R[25][35] = R[26][25] = R[26][27] = R[27][26] = R[27][28] = -0.01;
                R[28][27] = R[28][38] = R[29][19] = R[29][39] = R[30][31] = -0.01;
                R[30][40] = R[31][30] = R[31][32] = R[32][31] = R[32][22] = -0.01;
                R[32][42] = R[33][34] = R[34][33] = R[34][24] = R[34][44] = -0.01;
                R[35][25] = R[35][45] = R[36][37] = R[36][46] = R[37][36] = -0.01;
                R[37][47] = R[38][28] = R[38][48] = R[39][29] = R[39][49] = -0.01;
                R[40][30] = R[40][50] = R[41][51] = R[42][32] = R[42][52] = -0.01;
                R[43][53] = R[44][34] = R[44][54] = R[45][35] = R[45][55] = -0.01;
                R[46][36] = R[47][37] = R[47][57] = R[48][38] = R[48][49] = -0.01;
                R[49][48] = R[49][39] = R[50][40] = R[50][51] = R[51][50] = -0.01;
                R[51][41] = R[52][42] = R[52][53] = R[53][52] = R[53][43] = -0.01;
                R[54][44] = R[55][45] = R[55][56] = R[56][55] = R[56][57] = -0.01;
                R[57][56] = R[57][47] = R[57][58] = R[58][57] = R[58][59] = -0.01;
                R[59][58] = -0.1;
                R[19][9] = 100000; //Goal
                return R;
            }

            return maze;
        }

        public static Maze Example_3()
        {
            //TODO

            var maze = new Maze();

            maze.Id = 1;
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
