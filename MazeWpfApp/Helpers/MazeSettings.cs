﻿using Q_Learning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWpfApp.Helpers
{
    public class MazeSettings
    {
        public Maze Maze { get; set; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double MazeWidth => Maze.QuantityOfColumns * Maze.SizeOfCell;
        public double MazeHeight => Maze.QuantityOfRows * Maze.SizeOfCell;
        public double StartXPos => XPos - MazeWidth / 2;
        public double StartYPos => YPos - MazeHeight / 2;
        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }
    }
}
