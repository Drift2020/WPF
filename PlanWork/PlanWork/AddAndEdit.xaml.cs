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
    public partial class AddAndEdit : Window , Interfese.IAdd
    {
        DateTimePicker dateTimePicker;
        public Class.Add_Item add_item;
        private Model.Work myWork;
        private DateTime dateThis;
        private bool[] days_of_the_week;
        private int number;

        public int Number { get { return number; } set { number = value; } }
        public string Path { get { return _Path.Text; } set { _Path.Text = value; } }
        public DateTime DateThis { get { return dateThis; } set { dateThis = value; } }
        public bool[] Days_of_the_week { get { return days_of_the_week; } set { days_of_the_week = value; } }
      
        public Model.Work MyWork { get { return myWork; } set { myWork = value; } }

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public AddAndEdit()
        {
            InitializeComponent();

            _program.Items.Add("Ежедневно");
            _program.Items.Add("Еженедельно");
            _program.Items.Add("Ежемесячно");
            _program.Items.Add("Однократно");
            _program.SelectedIndex = 0;
            days_of_the_week = new bool[7];
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                Path =  openFileDialog1.FileName;
            }
        
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
                myWork = (Model.Work)_program.SelectedIndex;

                for (int i = 0; i < 7; i++)
                {
                    days_of_the_week[i] = ((System.Windows.Controls.CheckBox)_days_of_the_week.FindName("Ch" + (i + 1))).IsChecked.Value;

                }
                
                 add_item = new Class.Add_Item(this);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if ((Path == null || Path == ""))
            {
                System.Windows.MessageBox.Show("Заполните путь к файлу.");
                return;
            }
            if(myWork != Model.Work.daily)
            {
                bool isChek = false;
                for (int i = 0; i < days_of_the_week.Length; i++)
                {
                    if (days_of_the_week[i] == true)
                    {
                        isChek = true;
                    }

                }
                if (isChek == false)
                {
                    System.Windows.MessageBox.Show("Заполните дни недели.");
                    return;
                }
            }
            if (datePicker1.Text == "" || datePicker1.Text == null)
            {
                System.Windows.MessageBox.Show("Заполните Дату начала.");
                return;
            }
            DateThis = new DateTime(datePicker1.DisplayDate.Year, datePicker1.DisplayDate.Month, datePicker1.DisplayDate.Day, dateTimePicker.Value.Hour, dateTimePicker.Value.Minute, dateTimePicker.Value.Second);
         
   
            DialogResult = true;
        }
          
            
    

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void _program_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myWork = (Model.Work)_program.SelectedIndex;
            switch (_program.SelectedIndex)
            {

                case 0:
                    _days_of_the_week.IsEnabled = false;
                    break;
                default:
                    _days_of_the_week.IsEnabled = true;
                    break;
             
            }
        }
    }
}
