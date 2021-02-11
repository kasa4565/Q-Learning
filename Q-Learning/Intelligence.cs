using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q_Learning
{
    public class Intelligence
    {
        private static Random _Random = new Random(1);
        private const double _Gamma = 0.5;
        private const double _LearnRate = 0.5;
        private const int _MaxEpochs = 1000;


        public static IEnumerable<int> GetMoves(Maze maze)
        {
            Train(maze);

            var moves = GetWalkMoves(maze);

            return moves;
        }

        static void Train(Maze maze)
        {
            for (int epoch = 0; epoch < _MaxEpochs; ++epoch)
            {
                int currState = _Random.Next(0, maze.Reward.Length);

                while (true)
                {
                    int nextState = GetRandNextState(currState, maze.Matrix);
                    List<int> possNextNextStates = GetPossNextStates(nextState, maze.Matrix);
                    double maxQ = double.MinValue;
                    for (int j = 0; j < possNextNextStates.Count; ++j)
                    {
                        int nns = possNextNextStates[j];  // short alias
                        double q = maze.Quality[nextState][nns];
                        if (q > maxQ) maxQ = q;
                    }

                    maze.Quality[currState][nextState] =
                        ((1 - _LearnRate) * maze.Quality[currState][nextState]) +
                        (_LearnRate * (maze.Reward[currState][nextState] + (_Gamma * maxQ)));
                    currState = nextState;
                    if (currState == maze.Goal) break;
                }
            }
        }

        static IEnumerable<int> GetWalkMoves(Maze maze)
        {
            List<int> moves = new List<int>();

            int curr = maze.Start; int next;
            moves.Add(curr);

            while (curr != maze.Goal)
            {
                next = ArgMax(maze.Quality[curr]);
                moves.Add(next);
                curr = next;
            }

            return moves;
        }

        static List<int> GetPossNextStates(int s, int[][] matrix)
        {
            List<int> result = new List<int>();
            for (int j = 0; j < matrix.Length; ++j)
                if (matrix[s][j] == 1) result.Add(j);
            return result;
        }

        static int GetRandNextState(int s, int[][] matrix)
        {
            List<int> possNextStates = GetPossNextStates(s, matrix);
            int ct = possNextStates.Count;
            int idx = _Random.Next(0, ct);
            return possNextStates[idx];
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

        #region Console Run

        public static void RunExamplesInConsole()
        {
            Console.WriteLine("Begin Q-learning maze demo");
            Console.WriteLine("Setting up mazes and rewards");

            List<Maze> mazes = new List<Maze>();
            mazes.Add(MazeExamples.Example_1());

            foreach(var maze in mazes)
            {
                Console.WriteLine($"Analyzing maze {maze.Id} using Q-learning");
                Train(maze);

                Console.WriteLine($"Done. Q matrix for maze {maze.Id}: ");
                Print(maze);

                Console.WriteLine($"Using Q to walk from cell {maze.Start} to {maze.Goal}");
                PrintWalk(maze);
            }

            Console.WriteLine("End demo");
            Console.ReadLine();
        }

        private static void Print(Maze maze)
        {
            int ns = maze.Quality.Length;
            Console.WriteLine($"[0] [1] . . [{maze.NumberOfSquares}]");
            for (int i = 0; i < ns; ++i)
            {
                for (int j = 0; j < ns; ++j)
                {
                    Console.Write(maze.Quality[i][j].ToString("F2") + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintWalk(Maze maze)
        {
            int curr = maze.Start; int next;
            Console.Write(curr + "->");
            while (curr != maze.Goal)
            {
                next = ArgMax(maze.Quality[curr]);
                Console.Write(next + "->");
                curr = next;
            }
            Console.WriteLine("done");
        }

        #endregion

    }
}

