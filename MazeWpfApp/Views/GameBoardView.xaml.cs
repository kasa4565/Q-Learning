using MazeWpfApp.ViewModels;
using Q_Learning;
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
    /// Interaction logic for GameBoardView.xaml
    /// </summary>
    public partial class GameBoardView : UserControl
    {
        private readonly GameBoardViewModel _ViewModel;

        public GameBoardView(double width, double height, Maze maze)
        {
            InitializeComponent();
            _ViewModel = new GameBoardViewModel(width, height, maze);
            DataContext = _ViewModel;
        }
    }
}
