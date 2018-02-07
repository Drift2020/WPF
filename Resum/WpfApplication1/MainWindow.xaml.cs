using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Controls.Theming;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Interfese.IFront
    {
        private bool[] checBox;
        const int itemChecBox = 14;


        private Model.Сontainer myContainer = new Model.Сontainer();
       

        public MainWindow()
        {
            InitializeComponent();

            checBox = new bool[itemChecBox];

         

            myContainer.SetSerializer(new Model.XMLSerializer());
            myContainer.Load();

           
            // Презентер подписывается на уведомления о событиях Представления

           AddResum += new EventHandler<EventArgs>(AddResum1);
           OpenList += new EventHandler<EventArgs>(OpenList1);

        }
        #region event
        public event EventHandler<EventArgs> AddResum;
        public event EventHandler<EventArgs> OpenList;
        #endregion event

        #region EventFunct
        private void AddResum1(object sender, EventArgs e)
        {
             if (Nfo != "" && Nfo != null)
                myContainer.Add(new Model.Info(Nfo,Value, FamelyStatys,Adress,E_mail,ChecBoxs));
            else
                throw new Exception("поле ФИО должо быть заполненно");
        }
        private void OpenList1(object sender, EventArgs e)
        {
            for (int i = 0; i < myContainer.Count(); i++)
            {
                ElementResum.Add(myContainer.Element(i).Nfo);
            }

        }
        #endregion EventFunct

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
        public bool[] ChecBoxs
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
                for (int i = 0; i < itemChecBox; i++)
                {

                    checBox[i] = false;
                }
                for (int i=0;i<itemChecBox;i++)
                {

                    CheckBox t =  (CheckBox)checGroup.FindName("Ch"+(i+1));
                
                    if (t.IsChecked == true)
                    {
                     checBox[i] = true;
                    }
                }
                AddResum?.Invoke(this, EventArgs.Empty);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    

        private void ListUser_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                elementResum.Clear();
                ListUser.Items.Clear();
                OpenList?.Invoke(this, EventArgs.Empty);
               
                for (int i = 0; i < elementResum.Count; i++)
                {
                    ListUser.Items.Add("1." + (elementResum[i]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            MainWindow win=new MainWindow();

            for (int i = 0; i < elementResum.Count; i++)
            {
               if (ListUser.SelectedItem.ToString()==("1." + (elementResum[i])))
               {
                    win.Title= win.Nfo = myContainer.Element(i).Nfo;
                    win.Adress = myContainer.Element(i).Adress;
                    win.E_mail = myContainer.Element(i).E_mail;
                    win.Value = myContainer.Element(i).Value;
                    win.FamelyStatys = myContainer.Element(i).FamelyStatys;

                    win.checBox = myContainer.Element(i).ChecBox;

                    for (int i1 = 0; i1 < itemChecBox; i1++)
                    {

                        CheckBox t = (CheckBox)win.checGroup.FindName("Ch" + (i1 + 1));

                        if (win.checBox[i1] == true)
                        {
                            t.IsChecked = true;
                        }
                    }
                }
            }
          

            // Show the window.
            win.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            myContainer.Save();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < elementResum.Count; i++)
            {
                if (ListUser.SelectedItem.ToString() == ("1." + (elementResum[i])))
                {
                    myContainer.Remove(i);
                }
            }
        }
    }
}
