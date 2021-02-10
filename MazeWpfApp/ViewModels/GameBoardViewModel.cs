using MazeWpfApp.Helpers;
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
    public class GameBoardViewModel
    {
        private readonly MazeView _MazeView;

        public GameBoardViewModel(double width, double height)
        {
            Height = height;
            Width = width;
            _MazeView = new MazeView(GetMazeSettings());
            Content = GetContent();
        }

        public double Height { get; set; }
        public double Width { get; set; }
        public UIElement Content { get; set; }

        private Grid GetContent()
        {
            var grid = new Grid();

            grid.Children.Add(_MazeView);
            grid.Children.Add(GetButton());

            return grid;
        }

        private Button GetButton()
        {
            var button = new Button();

            button.Content = "START";
            button.MaxHeight = 50;
            button.MinHeight = 50;
            button.MaxWidth = 150;
            button.MinWidth = 150;
            button.Margin = new Thickness((Width/2) - 75, 40, 0, 0);
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.Click += StartButtonClicked;

            return button;
        }

        private void StartButtonClicked(object sender, RoutedEventArgs e)
        {
            _MazeView.ViewModel.VisualizeWalk();
        }

        private MazeSettings GetMazeSettings()
        {
            var settings = new MazeSettings();

            settings.QuantityOfColumns = 4;
            settings.QuantityOfRows = 3;
            settings.SizeOfCell = 50;
            settings.XPos = Width/2;
            settings.YPos = Height/2;
            settings.WindowHeight = Height;
            settings.WindowWidth = Width;
            settings.StartSquareIndex = 8;
            settings.MetaSquareIndex = 11;

            return settings;
        }

    }
}
