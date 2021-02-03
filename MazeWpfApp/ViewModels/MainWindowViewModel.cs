using MazeWpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MazeWpfApp.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Height = 400;
            Width = 600;
            Title = "Maze Game";
            View = new GameBoardView(Width, Height);
        }

        public UserControl View { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string Title { get; set; }
    }
}
