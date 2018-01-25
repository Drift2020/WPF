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

namespace dz2
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] myColor = { "Navy", "Blue", "Aqua", "Teal", "Olive", "Green", "Lime", "Yellow", "Orange",
            "Red", "Maroon", "Fuchsia", "Purple", "Black", "Silver", "Gray", "White" };
        Brush[] myBrush ={ Brushes.Navy, Brushes.Blue, Brushes.Aqua, Brushes.Teal, Brushes.Olive, Brushes.Green, Brushes.Lime, Brushes.Yellow, Brushes.Orange,
            Brushes.Red, Brushes.Maroon, Brushes.Fuchsia, Brushes.Purple, Brushes.Black, Brushes.Silver, Brushes.Gray, Brushes.White};
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 17; i++)
            {
                Button MyControl = new Button();
                
                MyControl.Content = myColor[i];
                MyControl.Margin = new Thickness(2, 2, 2, 2);


                MyControl.Foreground = myBrush[i];
                WARP.Children.Add(MyControl);
            }
        }
    }
}
