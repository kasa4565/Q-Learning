using MazeWpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MazeWpfApp.ViewModels
{
    public class MazeViewModel
    {
        public MazeViewModel()
        {
            Height = 120;
            Width = 160;
            Content = GetMazeVisualization();
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public UIElement Content { get; set; }

        private UIElement GetMazeVisualization()
        {
            return new CellView();
        }
    }
}
