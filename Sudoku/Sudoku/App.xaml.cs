using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void OnStartup(object sender, StartupEventArgs e)
        {
           
            MainWindow view = new MainWindow();

            MainViewModel viewModel = new MainViewModel();
            view.DataContext = viewModel;

            if (viewModel.Exit == null)
                viewModel.Exit = new Action(view.Close);

            if (viewModel.Show_M == null)
                viewModel.Show_M = new Action(view.Show_M);

            if (viewModel.Stop == null)
                viewModel.Stop = new Action(view.Stop);

            if (viewModel.Start == null)
                viewModel.Start = new Action(view.Start);

            if (viewModel.Show_Win == null)
                viewModel.Show_Win = new Action(view.Show_Win);
            //view.Closing += viewModel.OnWindowClosing;

            view.Show();
        }
    }
}
