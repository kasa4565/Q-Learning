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
        public GameBoardViewModel()
        {
            Height = 450;
            Width = 800;
            Content = new MazeView(GetMazeSettings());
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public UIElement Content { get; set; }

        private MazeSettings GetMazeSettings()
        {
            var settings = new MazeSettings();

            settings.QuantityOfColumns = 4;
            settings.QuantityOfRows = 3;
            settings.SizeOfCell = 40;
            settings.StartXPos = 10;
            settings.StartYPos = 10;

            return settings;
        }

    }
}
