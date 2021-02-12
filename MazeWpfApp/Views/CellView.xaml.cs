using MazeWpfApp.ViewModels;
using System.Windows.Controls;
namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for CellView.xaml
    /// </summary>
    public partial class CellView : UserControl
    {
        public CellView(int id, double topLeftX, double topLeftY, int sizeOfCell)
        {
            InitializeComponent();
            ViewModel = new CellViewModel(id, topLeftX, topLeftY, sizeOfCell);
            DataContext = ViewModel;
        }

        public CellViewModel ViewModel { get; private set; }
    }
}
