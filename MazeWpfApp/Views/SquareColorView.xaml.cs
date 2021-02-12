using MazeWpfApp.ViewModels;
using System.Windows.Controls;

namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for SquareColorView.xaml
    /// </summary>
    public partial class SquareColorView : UserControl
    {
        public SquareColorView(SquareColorViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
