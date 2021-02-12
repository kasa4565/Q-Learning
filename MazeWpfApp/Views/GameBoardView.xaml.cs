using MazeWpfApp.ViewModels;
using System.Windows.Controls;

namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for GameBoardView.xaml
    /// </summary>
    public partial class GameBoardView : UserControl
    {
        public GameBoardView(GameBoardViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
