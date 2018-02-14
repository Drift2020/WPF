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
using System.Windows.Shapes;

namespace KeyTren
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    struct mycolor
    {
        public Brush startBrush;
        public Button temp;
      
    }
    public partial class MainWindow : Window
    {
        List<mycolor> startBrush;
        public MainWindow()
        {
            InitializeComponent();
            startBrush = new List<mycolor>();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            Button temp =   Keys.FindName(e.Key.ToString()) as Button;

            if (e.Key.ToString()=="System")
                temp = Keys.FindName("Alt") as Button;
           
            if (temp != null )
            {
                for (int i = 0; i < startBrush.Count; i++)
                {
                    if (startBrush[i].temp.Content == temp.Content)
                        return;
                }
                mycolor tempM = new mycolor();

                tempM.temp = temp;
                tempM.startBrush = temp.Background;
                startBrush.Add(tempM);

                temp.Background = Brushes.IndianRed;
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            Button temp = Keys.FindName(e.Key.ToString()) as Button;
            if (e.Key.ToString() == "System")
                temp = Keys.FindName("Alt") as Button;

            if (temp != null)
            {
                for (int i = 0; i < startBrush.Count; i++)
                {
                    if (startBrush[i].temp.Content == temp.Content)
                    {
                        temp.Background = startBrush[i].startBrush;
                        startBrush.RemoveAt(i);
                        break;
                    }
                }
            }

           
        }

        private void Keys_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
