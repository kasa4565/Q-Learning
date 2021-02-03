﻿using MazeWpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MazeWpfApp.ViewModels
{
    public class GameBoardViewModel
    {
        public GameBoardViewModel()
        {
            Height = 450;
            Width = 800;
            Content = new MazeView();
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public UIElement Content { get; set; }
    }
}
