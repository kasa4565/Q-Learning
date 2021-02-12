using MazeWpfApp.ViewModels;
using System.Windows.Controls;

namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for MazeView.xaml
    /// </summary>
    public partial class MazeView : UserControl
    {
        public MazeView(MazeViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel; 
        }
    }
}
