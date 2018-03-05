using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        int _row = 9;
        int _coll = 9;

       
        //  Grid _start_pole;
        Button _start, _load;
        public void Start_Menu()
        {

        }
        public MainWindow()
        {
            InitializeComponent();
            My_game.Visibility = Visibility.Hidden;
            //_start_pole = new Grid();
            //for (int x = 0; x < _coll; x++)
            //{
            //    ColumnDefinition colDef2 = new ColumnDefinition();
            //    _start_pole.ColumnDefinitions.Add(colDef2);
            //}
            //for (int y = 0; y < _row + 1; y++)
            //{
            //    RowDefinition rowDef1 = new RowDefinition();
            //    _start_pole.RowDefinitions.Add(rowDef1);
            //}
            //_start_pole.Name = "StartPole";
            //Grid.SetRow(_start_pole, 1);
            //Main.Children.Add(_start_pole);
        }
        
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void MenuItem_Click_Stop(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void OnKeyDown(object obj, TextCompositionEventArgs e)
        {
            try
            {

                if (Int32.Parse(e.Text) >= 1 && Int32.Parse(e.Text) <= 9 && (e.Source as TextBox).Text.Length < 1)
                {
                    return;
                }
                else
                    e.Handled = true;

            }
            catch
            {
                e.Handled = true;

            }
        }

        public void Stop()
        {
            //_start_pole.Visibility = Visibility.Hidden;
            myMediaElement.Visibility = Visibility.Visible;
            My_game.Visibility = Visibility.Hidden;
        }

        public void Start()
        {
            myMediaElement.Visibility = Visibility.Hidden;
            My_game.Visibility = Visibility.Visible;

            //_start_pole.Visibility = Visibility.Visible;
            //_start_pole.Children.Clear();
            //Grid.SetRow(_start_pole, 1);

            //for (int x = 0; x < _coll; x++)
            //{
            //    for (int y = 0; y < _row; y++)
            //    {
            //        TextBox temp = new TextBox();
            //        temp.Name = ("P" + x) + y;
            //        temp.TextAlignment = TextAlignment.Center;
            //        temp.VerticalContentAlignment = VerticalAlignment.Center;
            //        Rectangle temp_Rect = new Rectangle();
            //        temp_Rect.Stroke = Brushes.Black;
            //        .Fill = Brushes.Transparent;
            //        temp.PreviewTextInput += new TextCompositionEventHandler(OnKeyDown);

            //        Binding bind = new Binding();
            //        bind.Path = new PropertyPath("Text");              
            //        bind.Mode = BindingMode.TwoWay;
            //        temp.SetBinding(TextBox.FontSizeProperty, bind);

            //        Grid.SetRow(temp_Rect, y);
            //        Grid.SetColumn(temp_Rect, x);
            //        Grid.SetRow(temp, y);
            //        Grid.SetColumn(temp, x);
            //        _start_pole.Children.Add(temp_Rect);
            //        _start_pole.Children.Add(temp);
            //    }
            //}
            //Button is_true = new Button();
            //is_true.Content = "Is true?";
            //Grid.SetRow(is_true, _row);
            //Grid.SetColumn(is_true, _coll / 2);
            //_start_pole.Children.Add(is_true);



        }

        public void Show_Win()
        {
            MessageBox.Show("Yor WIN!!!!");
        }
        public void Show_M()
        {
            MessageBox.Show("No, try again.");
        }
    }
}

