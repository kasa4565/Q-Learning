using MazeWpfApp.ViewModels;
using System.Windows.Controls;

namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for SquareColorView.xaml
    /// </summary>
    public partial class SquareColorView : UserControl
    {
        public SquareColorView(double topLeftX, double topLeftY, double height, double width)
        {
            InitializeComponent();
            ViewModel = new SquareColorViewModel(topLeftX, topLeftY, height, width);
            DataContext = ViewModel;
        }

        public SquareColorViewModel ViewModel { get; set; }
    }
}
