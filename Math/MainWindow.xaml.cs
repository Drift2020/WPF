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

namespace Math
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result.Text = (Int32.Parse(b1.Text) * Int32.Parse(b5.Text) * Int32.Parse(b9.Text)
                + Int32.Parse(b2.Text) * Int32.Parse(b6.Text) * Int32.Parse(b7.Text)
                + Int32.Parse(b3.Text) * Int32.Parse(b4.Text) * Int32.Parse(b8.Text)
                - Int32.Parse(b1.Text) * Int32.Parse(b6.Text) * Int32.Parse(b8.Text)
                - Int32.Parse(b2.Text) * Int32.Parse(b4.Text) * Int32.Parse(b9.Text)
                 - Int32.Parse(b3.Text) * Int32.Parse(b5.Text) * Int32.Parse(b7.Text)).ToString();
        }
    }
}
