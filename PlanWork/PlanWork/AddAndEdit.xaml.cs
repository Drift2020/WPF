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
using System.Windows.Forms;

namespace PlanWork
{
    /// <summary>
    /// Interaction logic for AddAndEdit.xaml
    /// </summary>
    public partial class AddAndEdit : Window
    {
       
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public AddAndEdit()
        {
            InitializeComponent();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.ShowDialog();
           
            temp = datePicker1.SelectedDate.Value;
            
        }
    }
}
