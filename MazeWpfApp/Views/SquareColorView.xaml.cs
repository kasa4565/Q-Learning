using MazeWpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
