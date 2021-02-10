using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MazeWpfApp.ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel(double viewWidth)
        {
            Content = GetButtons(viewWidth);
        }

        public Canvas Content { get; set; }

        private Canvas GetButtons(double viewWidth)
        {
            var canvas = new Canvas();
            canvas.HorizontalAlignment = HorizontalAlignment.Left;
            canvas.VerticalAlignment = VerticalAlignment.Top;
            canvas.Margin = new Thickness((viewWidth / 2) - 75, 0, 0, 0);

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

            return canvas;
        }

        private void MazeButtonClicked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
