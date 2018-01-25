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
            try { 
            result.Text = (float.Parse(b1.Text) * float.Parse(b5.Text) * float.Parse(b9.Text)
                + float.Parse(b2.Text) * float.Parse(b6.Text) * float.Parse(b7.Text)
                + float.Parse(b3.Text) * float.Parse(b4.Text) * float.Parse(b8.Text)
                - float.Parse(b1.Text) * float.Parse(b6.Text) * float.Parse(b8.Text)
                - float.Parse(b2.Text) * float.Parse(b4.Text) * float.Parse(b9.Text)
                 - float.Parse(b3.Text) * float.Parse(b5.Text) * float.Parse(b7.Text)).ToString();
            }
            catch (Exception ex)
            {
                result.Text = "";
                MessageBox.Show(ex.Message);
            }
            }

    }
}
