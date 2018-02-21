using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using System.Drawing;
//using System.Windows.Forms;
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
        public System.Windows.Media.Brush startBrush;
        public System.Windows.Controls.Button temp;
      
    }

    public partial class MainWindow : Window, IFront
    {
        

        bool capital_key_is_activ = false;
        bool shift_key_Up=true;

        KeySpeed Hell_keys;
       Size len = new Size();
        #region svoistva
        public bool is_Enable_text_box { set { _Str_My.IsEnabled = value; } get { return _Str_My.IsEnabled; } }
        public bool is_Start { set; get; }

        public bool is_Start_button { set { _start.IsEnabled = value; } get { return _start.IsEnabled; } }
        public bool is_Stop_button { set { _stop.IsEnabled = value; } get { return _stop.IsEnabled; } }

        public bool is_Enable_slad_box { set { sld.IsEnabled = value; } get { return sld.IsEnabled; } }
        public bool is_Enable_chek_box { set { _registr.IsEnabled = value; } get { return _registr.IsEnabled; } }

        public int level { set { _Difficulty.Content = value; } get { return Int32.Parse(_Difficulty.Content.ToString()); } }

        public string prow_str { set { _Str_Program.Text = value; } get { return _Str_Program.Text.ToString(); } }
        public string my_str { set { _Str_My.Text = value; } get { return _Str_My.Text; } }

        public string my_chars { set; get; }
        public bool sensitive { set; get; }
        public bool is_Fail { get; set; }

        public int fails { set; get; }
        public int speed_chars { set; get; }
        #endregion svoistva

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

        void Spehil_Key(System.Windows.Input.KeyEventArgs e)
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
            else if((e.Key.ToString() == "LeftShift" || e.Key.ToString() == "LeftShift") && shift_key_Up == true && capital_key_is_activ == false)
            {
                shift_key_Up = false;
                App.Language = new CultureInfo("ru-RU");
            }
            else if((e.Key.ToString() == "LeftShift" || e.Key.ToString() == "LeftShift") && shift_key_Up == false && capital_key_is_activ == false)
            {
                shift_key_Up = true;
                App.Language = new CultureInfo("ja-JP");
            }
            else if((e.Key.ToString() == "LeftShift" || e.Key.ToString() == "LeftShift") && shift_key_Up == true && capital_key_is_activ == true)
            {
                shift_key_Up = false;
                App.Language = new CultureInfo("en-JM");
            }
            else if ((e.Key.ToString() == "LeftShift"|| e.Key.ToString() == "LeftShift") && shift_key_Up == false && capital_key_is_activ == true)
            {
                shift_key_Up = true;
                App.Language = new CultureInfo("en-US");
            }

        }


        public void ScrollToHOffset()
        {
            
                _Scroll_Prow_Str.ScrollToHorizontalOffset((len.Width*2-0.2 + _Scroll_Prow_Str.ContentHorizontalOffset));         
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           


            if (is_Start)
            {

               

                System.Windows.Controls.Button temp = Keys.FindName(e.Key.ToString()) as System.Windows.Controls.Button;
                if (temp != null)
                {
                    if (e.Key.ToString() == "System")
                    temp = Keys.FindName("Alt") as System.Windows.Controls.Button;
              
                if (temp.Content.ToString().Length == 1|| temp.Content.ToString()=="Space")
                {
                        if (temp.Content.ToString() != "Space")
                            my_chars = temp.Content.ToString();
                        else
                            my_chars = " ";

                    

                        FormattedText formattedText = new FormattedText(my_chars,CultureInfo.CurrentCulture,
                            System.Windows.FlowDirection.LeftToRight,
                             new Typeface(this._Scroll_Prow_Str.FontFamily, this._Scroll_Prow_Str.FontStyle, this._Scroll_Prow_Str.FontWeight, 
                             this._Scroll_Prow_Str.FontStretch),this._Scroll_Prow_Str.FontSize, System.Windows.Media.Brushes.Black, new NumberSubstitution(), TextFormattingMode.Display);

                          
                        len = new Size(formattedText.Width, formattedText.Height);

                        DownKey?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    my_chars = "";
                    is_Fail = false;
                }


                   

                    if (is_Fail==false)
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

                        temp.Background = System.Windows.Media.Brushes.IndianRed;
                    }
                   else
                    {
                        System.Windows.MessageBox.Show(string.Format("The character you entered({0}) is incorrect.",my_chars));
                    }
                }


               
            }
        }
        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (is_Start)
            {
                System.Windows.Controls.Button temp = Keys.FindName(e.Key.ToString()) as System.Windows.Controls.Button;
                if (e.Key.ToString() == "System")
                    temp = Keys.FindName("Alt") as System.Windows.Controls.Button;



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
