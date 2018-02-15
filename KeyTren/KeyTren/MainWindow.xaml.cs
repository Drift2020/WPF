using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class MainWindow : Window, IFront
    {
        bool key_Up;

        KeySpeed Hell_keys;
        
        public bool is_Start { set; get; }

        public bool is_Start_button { set { _start.IsEnabled = value; } get { return _start.IsEnabled; } }
        public bool is_Stop_button { set { _stop.IsEnabled = value; } get { return _stop.IsEnabled; } }

        public string prow_str { set; get; }
        public string my_str { set; get; }

        public string my_chars { set; get; }
        public bool sensitive { set; get; }

        public int fails { set; get; }
        public int speed_chars { set; get; }

        public event EventHandler<EventArgs> DownKey;
        public event EventHandler<EventArgs> Start;
        public event EventHandler<EventArgs> Stop;
        public event EventHandler<EventArgs> Start_program;
        public event EventHandler<EventArgs> Speed_Chars;
        public event EventHandler<EventArgs> Fails;

        List<mycolor> startBrush;
        
        public MainWindow()
        {

           

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
            InitializeComponent();
            startBrush = new List<mycolor>();
            Hell_keys = new KeySpeed(this);
        }

      

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (is_Start)
            {
                Button temp = Keys.FindName(e.Key.ToString()) as Button;

                if (e.Key.ToString() == "System")
                    temp = Keys.FindName("Alt") as Button;

                
             


                if (temp != null)
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

                    if(e.Key.ToString()== "LeftShift" && key_Up == true)
                    {
                        if (App.Language.ToString() == "ru-RU")
                            App.Language = new CultureInfo("en-US");
                        else
                            App.Language = new CultureInfo("ru-RU");
                        key_Up = false;
                    }
                }


               
            }
        }
        //   if (e.Key.ToString() == "Capital" && key_Up == true)
        //        {
        //            if (App.Language.ToString() == "ru-RU")
        //                App.Language = new CultureInfo("en-US");
        //            else
        //                App.Language = new CultureInfo("ru-RU");
        //key_Up = false;
        //        }
    private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (is_Start)
            {
                Button temp = Keys.FindName(e.Key.ToString()) as Button;
                if (e.Key.ToString() == "System")
                    temp = Keys.FindName("Alt") as Button;



                if (e.Key.ToString() == "Capital")
                {
                    if (e.IsToggled == false)
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
                else if (temp != null)
                {
                    for (int i = 0; i < startBrush.Count; i++)
                    {
                        if (startBrush[i].temp.Content == temp.Content)
                        {
                            temp.Background = startBrush[i].startBrush;
                            startBrush.RemoveAt(i);

                            if (e.Key.ToString() == "LeftShift")
                            {
                                if (App.Language.ToString() == "ru-RU")
                                    App.Language = new CultureInfo("en-US");
                                else
                                    App.Language = new CultureInfo("ru-RU");
                                key_Up = true;
                            }
                               
                            break;
                        }
                    }


                }
            }
           
        }

        private void Keys_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Start?.Invoke(this, EventArgs.Empty);
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Stop?.Invoke(this, EventArgs.Empty);
        }
    }
}
