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

namespace PlanWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window , Interfese.IFront
    {
        private Class.Plan_Work myPlan;
        public string NewMesege { get; set; }
        


        public List<string> WorkList { get { return workList; } set { workList = value; } }
      
        public ListBox Worc { get { return _worcList; } set { _worcList = value; }}
      


        List<string> workList;

        private void EditList(object sender, EventArgs e)
        {
       
                _complitWork.Items.Add(new Label().Content = NewMesege);
        }

        public MainWindow()
        {
            InitializeComponent();
          
        
           
            workList = new List<string>();

            myPlan = new Class.Plan_Work(this);
            myPlan.EditList += new EventHandler<EventArgs>(EditList);
            foreach (string t in workList)
            {
                _worcList.Items.Add(new Label().Content = t);
            }
        }
   
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try { 
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            myPlan.Save();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if(_worcList.SelectedIndex!=-1)
            myPlan.Delete(_worcList.SelectedIndex);
        }

        private void _worcList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
