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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Interfese.IFront
    {
        private bool[] checBox;
        const int itemChecBox = 14;
        public MainWindow()
        {
            InitializeComponent();

            checBox = new bool[itemChecBox];
          
        }
        #region event
        public event EventHandler<EventArgs> AddResum;
        public event EventHandler<EventArgs> OpenList;
        #endregion event
        List<string> elementResum = new List<string>();

        #region pole
        public string Nfo
        {
            get { return _NFO.Text; }
            set { _NFO.Text = value; }
        }
        public string Value
        {
            get { return _Value.Text; }
            set { _Value.Text = value; }
        }
        public string FamelyStatys
        {
            get { return _FamelyStatys.Text; }
            set { _FamelyStatys.Text = value; }
        }
        public string Adress
        {
            get { return _Adress.Text; }
            set { _Adress.Text = value; }
        }
        public string E_mail
        {
            get { return _E_mail.Text; }
            set { _E_mail.Text= value; }
        }
        public bool[] ChecBox
        {
            get { return checBox; }
            set { checBox = value; }
        }
        public List<string> ElementResum
        {
            get { return elementResum; }
            set { elementResum = value; }
        }
        #endregion pole 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                AddResum?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ListUser_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            try
            {

                OpenList?.Invoke(this, EventArgs.Empty);
                for(int i=0;i<elementResum.Count;i++)
                {
                    iuty
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       
        }
    }
}
