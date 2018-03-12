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




            bool work = true;

            MainWindow view = new MainWindow();

            LoginViewModel viewModel = new LoginViewModel();
            view.DataContext = viewModel;

            if (viewModel._Visibility_off == null)
                viewModel._Visibility_off = new Action(view.Visibility_off);


            if (viewModel._Visibility_on == null)
                viewModel._Visibility_on = new Action(view.Visibility_on);

            if (viewModel._NO == null)
                viewModel._NO = new Action(view.No);

            if (viewModel._OK == null)
                viewModel._OK = new Action(view.Ok);

            if (viewModel._NONE_USER == null)
                viewModel._NONE_USER = new Action(view.None_user);


            //view.Closing += viewModel.OnWindowClosing;

            //do
            //{
                view.ShowDialog();

              

           // } while (work);
            
        }
    }

}
