﻿using System;
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

namespace BookFood
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DefaultStyle();
        }
        public void DefaultStyle()
        {
            this.Background = new SolidColorBrush(Colors.DarkGray);
            var core = new Uri("Core.xaml", UriKind.Relative);
            var brush = new Uri("Brushes.xaml", UriKind.Relative);
            var ico = new Uri("Icons.xaml", UriKind.Relative);

            ResourceDictionary resourceDictionary = Application.LoadComponent(core) as ResourceDictionary;
            ResourceDictionary bru = Application.LoadComponent(brush) as ResourceDictionary;
            ResourceDictionary ic = Application.LoadComponent(ico) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(bru);
            Application.Current.Resources.MergedDictionaries.Add(ic);

        }
         public void Show_Sellect_Item()
        {
            MessageBox.Show("Для начала выберите элемент из списка");
        }
        public MessageBoxResult _result;
        public void Question()
        {

            _result= MessageBox.Show("Точно хотите удалить выбраный элемент?","Удаление",MessageBoxButton.YesNo,MessageBoxImage.Question);
        }
    }
}
