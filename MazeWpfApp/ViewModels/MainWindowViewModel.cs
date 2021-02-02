using MazeWpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MazeWpfApp.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            View = new GameBoardView();
        }

        public UserControl View { get; set; }
    }
}
