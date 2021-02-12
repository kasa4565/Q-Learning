using MazeWpfApp.ViewModels;
using System.Windows.Controls;
namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for WallView.xaml
    /// </summary>
    public partial class WallView : UserControl
    {
        public WallView(double x1, double y1, double x2, double y2)
        {
            InitializeComponent();
            DataContext = new WallViewModel(x1, y1, x2, y2);
        }
    }
}
