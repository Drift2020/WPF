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
using System.Windows.Shapes;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for Add_Image.xaml
    /// </summary>
    public partial class Add_Image : Window
    {
        public Add_Image()
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

    }
}
