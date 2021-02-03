using MazeWpfApp.Helpers;
using MazeWpfApp.Views;
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
        public GameBoardViewModel(double width, double height)
        {
            Height = height;
            Width = width;
            Content = new MazeView(GetMazeSettings());
        }

        public double Height { get; set; }
        public double Width { get; set; }
        public UIElement Content { get; set; }

        private MazeSettings GetMazeSettings()
        {
            var settings = new MazeSettings();

            settings.QuantityOfColumns = 4;
            settings.QuantityOfRows = 3;
            settings.SizeOfCell = 50;
            settings.XPos = Width/2;
            settings.YPos = Height/2;

            return settings;
        }

    }
}
