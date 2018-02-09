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
        List<string> workList;
        List<string> complitWork;
        public MainWindow()
        {
            InitializeComponent();
            myPlan = new Class.Plan_Work();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            AddAndEdit Temp = new AddAndEdit();
            Temp.ShowDialog();
            if (Temp.DialogResult == true)
            {
                workList.Add(Temp.Path);

                _worcList.Items.Clear();

                foreach (string t in workList)
                {
                    _worcList.Items.Add(new Label().Content = t);
                }

                myPlan.Add(Temp);
            }
        }
    }
}
