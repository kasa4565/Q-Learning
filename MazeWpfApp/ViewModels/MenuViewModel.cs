using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using MazeWpfApp.Views;

namespace MazeWpfApp.ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel(double width, double height)
        {
            Width = width;
            Height = height;
            GameBoard = new GameBoardView(Width, Height);
            Content = GetButtons();
        }

        public UIElement Content { get; set; }
        public double Width { get; private set; }
        public double Height { get; private set; }
        public UIElement Menu { get; set; }
        public UIElement GameBoard { get; set; }

        private UIElement GetButtons()
        {
            var canvas = new Canvas();
            canvas.HorizontalAlignment = HorizontalAlignment.Left;
            canvas.VerticalAlignment = VerticalAlignment.Top;
            canvas.Margin = new Thickness((Width / 2) - 75, 0, 0, 0);

            for (int i = 1; i < 4; i++)
            {
                var button = new Button();
                button.Content = "MAZE " + i;
                button.MaxHeight = 50;
                button.MinHeight = 50;
                button.MaxWidth = 150;
                button.MinWidth = 150;
                button.Margin = new Thickness(0, i * 75, 0, 0);
                button.Click += MazeButtonClicked;

                canvas.Children.Add(button);
            }

            Menu = canvas;

            var grid = new Grid();
            grid.Children.Add(canvas);
            GameBoard.Visibility = Visibility.Collapsed;
            grid.Children.Add(GameBoard);

            return grid;
        }

        private void MazeButtonClicked(object sender, RoutedEventArgs e)
        {
            Menu.Visibility = Visibility.Collapsed;
            GameBoard.Visibility = Visibility.Visible;
        }
    }
}
