using MazeWpfApp.ViewModels;
using System.Windows.Controls;

namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView(MenuViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
