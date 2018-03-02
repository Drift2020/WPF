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

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button _start,_load;
        public void Start_Menu()
        {

        }
        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
          
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            video.Position = TimeSpan.Zero;
            video.Play();
        }

        void Start()
        {
            
        }
    }
}
