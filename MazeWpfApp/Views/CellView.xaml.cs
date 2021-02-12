using MazeWpfApp.ViewModels;
using System.Windows.Controls;

namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for CellView.xaml
    /// </summary>
    public partial class CellView : UserControl
    {
        public CellView(CellViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
