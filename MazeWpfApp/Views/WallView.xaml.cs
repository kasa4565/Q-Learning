using MazeWpfApp.ViewModels;
using System.Windows.Controls;

namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for WallView.xaml
    /// </summary>
    public partial class WallView : UserControl
    {
        public WallView(WallViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
