using MazeWpfApp.Helpers;
using MazeWpfApp.ViewModels;
using System.Windows.Controls;
namespace MazeWpfApp.Views
{
    /// <summary>
    /// Interaction logic for MazeView.xaml
    /// </summary>
    public partial class MazeView : UserControl
    {
        public MazeView(MazeSettings settings)
        {
            InitializeComponent();
            ViewModel = new MazeViewModel(settings);
            DataContext = ViewModel; 
        }

        public MazeViewModel ViewModel { get; private set; }
    }
}
