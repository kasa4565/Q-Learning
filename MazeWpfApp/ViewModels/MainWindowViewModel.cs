using MazeWpfApp.Views;
using System.Windows.Controls;

namespace MazeWpfApp.ViewModels
{
    public class MainWindowViewModel
    {
        private const double _Height = 400;
        private const double _Width = 600;
        private const string _Title = "Maze Game";

        public MainWindowViewModel()
        {
            Height = _Height;
            Width = _Width;
            Title = _Title;
            View = new MenuView(new MenuViewModel(Width, Height));
        }

        public UserControl View { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string Title { get; set; }
    }
}
