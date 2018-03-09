using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
         

            MainWindow view = new MainWindow();

            LoginViewModel viewModel = new MainViewModel();
            view.DataContext = viewModel;
            if (viewModel.Not_Element == null)
                viewModel.Not_Element = new Action(view.Show_Sellect_Item);

            if (viewModel.Exit == null)
                viewModel.Exit = new Action(view.Close);

            if (viewModel.Question == null)
                viewModel.Question = new Action(view.Question);


            view.Closing += viewModel.OnWindowClosing;
            view.Show();
        }
    }

}
