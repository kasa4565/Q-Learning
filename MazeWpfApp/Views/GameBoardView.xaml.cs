using MazeWpfApp.ViewModels;
using Q_Learning;
using System.Windows.Controls;
namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for GameBoardView.xaml
    /// </summary>
    public partial class GameBoardView : UserControl
    {
        public GameBoardView(double width, double height, Maze maze)
        {
            InitializeComponent();
            DataContext = new GameBoardViewModel(width, height, maze);
        }
    }
}
