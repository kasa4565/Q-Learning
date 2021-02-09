using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    public static class MazeExamples
    {
        public static int[][] Example_1()
        {
            int[][] FT = new int[12][];
            for (int i = 0; i < 12; ++i) FT[i] = new int[12];
            FT[0][1] = FT[0][4] = FT[1][0] = FT[1][5] = FT[2][3] = 1;
            FT[2][6] = FT[3][2] = FT[3][7] = FT[4][0] = FT[4][8] = 1;
            FT[5][1] = FT[5][6] = FT[5][9] = FT[6][2] = FT[6][5] = 1;
            FT[6][7] = FT[7][3] = FT[7][6] = FT[7][11] = FT[8][4] = 1;
            FT[8][9] = FT[9][5] = FT[9][8] = FT[9][10] = FT[10][9] = 1;
            FT[11][11] = 1;  // Goal
            return FT;
        }
    }
}
