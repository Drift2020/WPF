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
        DateTimePicker dateTimePicker;
        public Class.Add_Item add_item;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public AddAndEdit()
        {
            InitializeComponent();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.ShowDialog();

        
            //temp = datePicker1.SelectedDate.Value;

        }
       
        private void TimeSpiker_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the interop host control.
            System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            // Create the MaskedTextBox control.

            dateTimePicker = new DateTimePicker();
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "HH:mm:ss";
            dateTimePicker.ShowUpDown = true;

            // Assign the MaskedTextBox control as the host control's child.
            host.Child = dateTimePicker;

            // Add the interop host control to the Grid
            // control's collection of child controls.
            this.TimePiker.Children.Add(host);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (DialogResult==true)
            {
                bool[] temp = new bool[7];

                for (int i = 0; i < 7; i++)
                {
                    temp[i] = ((System.Windows.Controls.CheckBox)_days_of_the_week.FindName("Ch" + (i + 1))).IsChecked.Value;

                }

                add_item = new Class.Add_Item(this._Path.Text, dateTimePicker.Text, datePicker1.Text, (Model.Work)_program.SelectedIndex, temp);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
