using MazeWpfApp.Views;
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
            View = new MenuView(new MenuViewModel(Width, Height));
        }

        public UserControl View { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string Title { get; set; }
    }
}
