using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    public class Intelligence
    {
        static Random rnd = new Random(1);

        public static void RunInConsole()
        {
            Console.WriteLine("Begin Q-learning maze demo");
            Console.WriteLine("Setting up maze and rewards");

            var maze = MazeExamples.Example_1();
            int[][] FT = maze.Matrix;
            double[][] R = maze.Reward;
            double[][] Q = maze.Quality;
            int goal = maze.Goal;

            Console.WriteLine("Analyzing maze using Q-learning");

            double gamma = 0.5;
            double learnRate = 0.5;
            int maxEpochs = 1000;
            Train(FT, R, Q, goal, gamma, learnRate, maxEpochs);

            Console.WriteLine("Done. Q matrix: ");
            Print(Q);

            Console.WriteLine("Using Q to walk from cell 8 to 11");
            PrintWalk(8, 11, Q);

            Console.WriteLine("End demo");
            Console.ReadLine();
        }

        public static IEnumerable<int> GetMoves()
        {
            var maze = MazeExamples.Example_1();
            int[][] FT = maze.Matrix;
            double[][] R = maze.Reward;
            double[][] Q = maze.Quality;
            int goal = maze.Goal;
            double gamma = 0.5;
            double learnRate = 0.5;
            int maxEpochs = 1000;

            Train(FT, R, Q, goal, gamma, learnRate, maxEpochs);

            return GetWalkMoves(maze.Start, maze.Goal, Q);
        }

        static void Print(double[][] Q)
        {
            int ns = Q.Length;
            Console.WriteLine("[0] [1] . . [11]");
            for (int i = 0; i < ns; ++i)
            {
                for (int j = 0; j < ns; ++j)
                {
                    Console.Write(Q[i][j].ToString("F2") + " ");
                }
                Console.WriteLine();
            }
        }

        static List<int> GetPossNextStates(int s, int[][] FT)
        {
            List<int> result = new List<int>();
            for (int j = 0; j < FT.Length; ++j)
                if (FT[s][j] == 1) result.Add(j);
            return result;
        }

        static int GetRandNextState(int s, int[][] FT)
        {
            List<int> possNextStates = GetPossNextStates(s, FT);
            int ct = possNextStates.Count;
            int idx = rnd.Next(0, ct);
            return possNextStates[idx];
        }

        static void Train(int[][] FT, double[][] R, double[][] Q,
            int goal, double gamma, double lrnRate, int maxEpochs)
        {
            for (int epoch = 0; epoch < maxEpochs; ++epoch)
            {
                int currState = rnd.Next(0, R.Length);

                while (true)
                {
                    int nextState = GetRandNextState(currState, FT);
                    List<int> possNextNextStates = GetPossNextStates(nextState, FT);
                    double maxQ = double.MinValue;
                    for (int j = 0; j < possNextNextStates.Count; ++j)
                    {
                        int nns = possNextNextStates[j];  // short alias
                        double q = Q[nextState][nns];
                        if (q > maxQ) maxQ = q;
                    }

                    Q[currState][nextState] =
                        ((1 - lrnRate) * Q[currState][nextState]) +
                        (lrnRate * (R[currState][nextState] + (gamma * maxQ)));
                    currState = nextState;
                    if (currState == goal) break;
                }
            }
        }

        static IEnumerable<int> GetWalkMoves(int start, int goal, double[][] Q)
        {
            List<int> moves = new List<int>();

            int curr = start; int next;
            moves.Add(curr);

            while (curr != goal)
            {
                next = ArgMax(Q[curr]);
                moves.Add(next);
                curr = next;
            }

            return moves;
        }

        static void PrintWalk(int start, int goal, double[][] Q)
        {
            int curr = start; int next;
            Console.Write(curr + "->");
            while (curr != goal)
            {
                next = ArgMax(Q[curr]);
                Console.Write(next + "->");
                curr = next;
            }
            Console.WriteLine("done");
        }

        static int ArgMax(double[] vector)
        {
            double maxVal = vector[0]; int idx = 0;
            for (int i = 0; i < vector.Length; ++i)
            {
                if (vector[i] > maxVal)
                {
                    maxVal = vector[i]; idx = i;
                }
            }
            return idx;
        }
    }
}

