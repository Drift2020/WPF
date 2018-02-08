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

namespace PlanWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        private Class.Plan_Work myPlan;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            AddAndEdit Temp = new AddAndEdit();
            Temp.ShowDialog();
            if (Temp.DialogResult == true)
            {
                myPlan.Add(new Model.Info(Temp.add_item.Path, Temp.add_item.TimeThis, Temp.add_item.DateThis, Temp.add_item.MyWork, Temp.add_item.Days_of_the_week));
            }
        }
    }
}
