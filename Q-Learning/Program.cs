﻿using System;
using System.Collections.Generic;

namespace Q_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Q-learning maze demo");
            Console.WriteLine("Setting up mazes and rewards");

            List<Maze> mazes = new List<Maze>();
            mazes.Add(MazeExamples.Example_1());
            mazes.Add(MazeExamples.Example_2());

            var intelligence = new Intelligence();
            intelligence.RunExamplesInConsole(mazes);

            Console.WriteLine("End demo");
            Console.ReadLine();
        }
    }
        
}