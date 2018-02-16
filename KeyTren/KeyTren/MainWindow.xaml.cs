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
    /// 

    public partial class Slad : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            double a = Double.Parse(value.ToString());
            int a1 = System.Convert.ToInt32(a);
            return (a1.ToString()); // Do the conversion from bool to visibility
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
            // Do the conversion from visibility to bool
        }
    }
    struct mycolor
    {
        public Brush startBrush;
        public Button temp;
      
    }

    public partial class MainWindow : Window, IFront
    {


        bool capital_key_is_activ = false;
        bool shift_key_Up=true;

        KeySpeed Hell_keys;
        
        public bool is_Enable_text_box { set { _Str_My.IsEnabled = value; } get { return _Str_My.IsEnabled; } }
        public bool is_Start { set; get; }

        public bool is_Start_button { set { _start.IsEnabled = value; } get { return _start.IsEnabled; } }
        public bool is_Stop_button { set { _stop.IsEnabled = value; } get { return _stop.IsEnabled; } }

        public bool is_Enable_slad_box { set { sld.IsEnabled = value; } get { return sld.IsEnabled; } }
        public bool is_Enable_chek_box { set { _registr.IsEnabled = value; } get { return _registr.IsEnabled; } }


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

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ja-JP");



            InitializeComponent();
            startBrush = new List<mycolor>();
            Hell_keys = new KeySpeed(this);

            App.Language = new CultureInfo("ja-JP");
        }

        void Spehil_Key(KeyEventArgs e)
        {
            if(e.Key.ToString() == "Capital" && capital_key_is_activ == false && shift_key_Up == true)
            {
                capital_key_is_activ = true;
                App.Language = new CultureInfo("en-US");
            }
            else if(e.Key.ToString() == "Capital" && capital_key_is_activ == true && shift_key_Up == true)
            {
                capital_key_is_activ = false;
                App.Language = new CultureInfo("ja-JP");               
            }
            else if(e.Key.ToString() == "Capital" && capital_key_is_activ == false && shift_key_Up == false)
            {
                capital_key_is_activ = true;
                App.Language = new CultureInfo("en-JM");
            }
            else if (e.Key.ToString() == "Capital" && capital_key_is_activ == true && shift_key_Up == false)
            {
                capital_key_is_activ = false;
                App.Language = new CultureInfo("ru-RU");
            }
            else if(e.Key.ToString() == "LeftShift" && shift_key_Up == true && capital_key_is_activ == false)
            {
                shift_key_Up = false;
                App.Language = new CultureInfo("ru-RU");
            }
            else if(e.Key.ToString() == "LeftShift" && shift_key_Up == false && capital_key_is_activ == false)
            {
                shift_key_Up = true;
                App.Language = new CultureInfo("ja-JP");
            }
            else if(e.Key.ToString() == "LeftShift" && shift_key_Up == true && capital_key_is_activ == true)
            {
                shift_key_Up = false;
                App.Language = new CultureInfo("en-JM");
            }
            else if (e.Key.ToString() == "LeftShift" && shift_key_Up == false && capital_key_is_activ == true)
            {
                shift_key_Up = true;
                App.Language = new CultureInfo("en-US");
            }

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
                    Spehil_Key(e);
                    tempM.temp = temp;
                    tempM.startBrush = temp.Background;
                    startBrush.Add(tempM);

                    temp.Background = Brushes.IndianRed;

                   
                }


               
            }
        }
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

                                Spehil_Key(e);


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

                            Spehil_Key(e);

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
               App.Language = new CultureInfo("ja-JP");
            App.Language.ToString();
        }
    }
}
