using MazeWpfApp.Helpers;
using MazeWpfApp.Views;
using Q_Learning;
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
        private MazeViewModel _MazeViewModel;
        private Maze _Maze;

        public GameBoardViewModel(double width, double height, Maze maze)
        {
            Height = height;
            Width = width;
            Maze = maze;
        }

        public double Height { get; set; }
        public double Width { get; set; }
        public UIElement Content { get; set; }
        public Maze Maze
        {
            get
            {
                return _Maze;
            }
            set
            {
                _Maze = value;
                _MazeViewModel = new MazeViewModel(GetMazeSettings());
                Content = GetContent();
            }
        }

        private Grid GetContent()
        {
            var grid = new Grid();

            grid.Children.Add(new MazeView(_MazeViewModel));
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
            button.Margin = new Thickness((Width / 2) - 75, 10, 0, 0);
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.Click += StartButtonClicked;

            return button;
        }

        private void StartButtonClicked(object sender, RoutedEventArgs e)
        {
            _MazeViewModel.VisualizeWalk(Maze);
        }

        private MazeSettings GetMazeSettings()
        {
            var settings = new MazeSettings();

            settings.XPos = Width / 2;
            settings.YPos = Height / 2;
            settings.WindowHeight = Height;
            settings.WindowWidth = Width;
            settings.Maze = Maze;

            return settings;
        }

    }
}
