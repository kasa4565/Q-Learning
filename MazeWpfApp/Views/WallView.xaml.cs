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
