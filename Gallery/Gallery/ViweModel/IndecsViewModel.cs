using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Gallery
{
    class IndecsViewModel : ViewModelBase
    {

        public IndecsViewModel(string i_autor)
        {
            // my_photo = new СontainerPhoto();
            // my_photo.SetSerializer(new XMLSerializer());
            //  my_photo.Load("photo");
            _i_autor = i_autor;
            my_photo = new ObservableCollection<PhotoViewModel>();


            Load();
        }

        void OpenMessege(string s, string title)
        {
            Window1 messege = new Window1();
            MessegeViewModel messege_view_Model = new MessegeViewModel(System.Windows.Visibility.Visible, System.Windows.Visibility.Hidden, System.Windows.Visibility.Hidden);

            if (messege_view_Model._OK == null)
                messege_view_Model._OK = new Action(messege.Close);


            messege.DataContext = messege_view_Model;
            messege_view_Model.Messege = s;
            messege_view_Model.Messeg_Titel = title;
            messege.ShowDialog();
        }

        #region
        FileStream stream = null;
        XmlSerializer serializer = null;
        public void Save()
        {
            try
            {
                stream = new FileStream("../../photo.xml", FileMode.Create);
                serializer = new XmlSerializer(typeof(ObservableCollection<PhotoViewModel>));
                serializer.Serialize(stream, my_photo);
                stream.Close();
            }
            catch (Exception ex)
            {

                if (stream != null)
                    stream.Close();
            };

        }
        public void Load()
        {

            try
            {
                stream = new FileStream("../../photo.xml", FileMode.Open);
                serializer = new XmlSerializer(typeof(ObservableCollection<PhotoViewModel>));
                my_photo = (ObservableCollection<PhotoViewModel>)serializer.Deserialize(stream);


                stream.Close();


            }
            catch (Exception ex)
            {

                if (stream != null)
                    stream.Close();
            };


        }

        #endregion


        #region Pole 
        //   СontainerPhoto my_photo;
        string _i_autor;

        #region radio      
        bool m1;
        public bool M1
        {
            get
            {
                return m1;
            }
            set
            {
              
                m1 = value;
                OnPropertyChanged(nameof(M1));
            }
        }

        bool m2;
        public bool M2
        {
            get
            {
                return m2;
            }
            set
            {
               
                m2 = value;
                OnPropertyChanged(nameof(M2));
            }
        }

        bool m3;
        public bool M3
        {
            get
            {
                return m3;
            }
            set
            {
               
                m3 = value;
                OnPropertyChanged(nameof(M3));
            }
        }

        bool m4;
        public bool M4
        {
            get
            {
                return m4;
            }
            set
            {
              
                m4 = value;
                OnPropertyChanged(nameof(M4));
            }
        }

        bool m5;
        public bool M5
        {
            get
            {
                return m5;
            }
            set
            {
              
                m5 = value;
                OnPropertyChanged(nameof(M5));
            }
        }
        #endregion radio

        public ObservableCollection<PhotoViewModel> my_photo { get; set; }

        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
     
        string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        string autor;
        public string Autor
        {
            get
            {
                return autor;
            }
            set
            {
                autor = value;
                OnPropertyChanged(nameof(Autor));
            }
        }

      
        public int Mark
        {
            get
            {
                if(_select_Item!=null)
                return _select_Item.Mark;
                return 0;
            }
            set
            {
                _select_Item.Mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }

        PhotoViewModel _select_Item;
        public PhotoViewModel Select_Item
        {
            get { return _select_Item; }
            set
            {
                _select_Item = value;
                OnPropertyChanged(nameof(Select_Item));

                switch (Mark)
                {
                    case 1:
                        M1 = true;
                        break;
                    case 2:
                        M2 = true;
                        break;
                    case 3:
                        M3 = true;
                        break;
                    case 4:
                        M4 = true;
                        break;
                    case 5:
                        M5 = true;
                        break;
                }

            }
        }

        #endregion Pole 



        #region Command_button

        private DelegateCommand _Command_next;
        public ICommand Button_clik_next
        {
            get
            {
                if (_Command_next == null)
                {
                    _Command_next = new DelegateCommand(Execute_next, CanExecute_next);
                }
                return _Command_next;
            }
        }
        private void Execute_next(object o)
        {
            
            for(int i=0;i< my_photo.Count;i++)
            {
                if(Select_Item == my_photo[i])
                {
                    Select_Item = my_photo[i + 1];
                    return;
                }
            }

        }
        private bool CanExecute_next(object o)
        {

            for (int i = 0; i < my_photo.Count; i++)
            {
                if (_select_Item == my_photo[i] && i+1 < my_photo.Count)
                {
                    return true;
                }
            }

            return false;


        }

        private DelegateCommand _Command_back;
        public ICommand Button_clik_back
        {
            get
            {
                if (_Command_back == null)
                {
                    _Command_back = new DelegateCommand(Execute_back, CanExecute_back);
                }
                return _Command_back;
            }
        }
        private void Execute_back(object o)
        {

            for (int i = 0; i < my_photo.Count; i++)
            {
                if (Select_Item == my_photo[i])
                {
                    Select_Item = my_photo[i - 1];
                    return;
                }
            }

        }
        private bool CanExecute_back(object o)
        {
            if (my_photo.Count != 0)
            {
                if (Select_Item == my_photo[0])
                {
                    return false;

                }
                return true;
            }
            return false;
        }

        private DelegateCommand _Command_start;
        public ICommand Button_clik_start
        {
            get
            {
                if (_Command_start == null)
                {
                    _Command_start = new DelegateCommand(Execute_start, CanExecute_start);
                }
                return _Command_start;
            }
        }
        private void Execute_start(object o)
        {

            Select_Item = my_photo[0];

        }
        private bool CanExecute_start(object o)
        {
            if (my_photo.Count != 0)
            {
                if (Select_Item == my_photo[0])
                {
                    return false;

                }
                return true;
            }
            return false;


        }

        private DelegateCommand _Command_end;
        public ICommand Button_clik_end
        {
            get
            {
                if (_Command_end == null)
                {
                    _Command_end = new DelegateCommand(Execute_end, CanExecute_end);
                }
                return _Command_end;
            }
        }
        private void Execute_end(object o)
        {

            Select_Item = my_photo[my_photo.Count-1];

        }
        private bool CanExecute_end(object o)
        {
            if (my_photo.Count != 0)
            {
                if (Select_Item == my_photo[my_photo.Count - 1])
                {
                    return false;

                }
                return true;
            }
            return false;

        }

        private DelegateCommand _Command_specific;
        public ICommand Button_clik_specific
        {
            get
            {
                if (_Command_specific == null)
                {
                    _Command_specific = new DelegateCommand(Execute_specific, CanExecute_specific);
                }
                return _Command_specific;
            }
        }
        private void Execute_specific(object o)
        {

            SerchImageView my_serch = new SerchImageView();

            SelectViewModel my_model_serch = new SelectViewModel(my_photo);

            if (my_model_serch._OK == null)
                my_model_serch._OK = new Action(my_serch.Ok);

            my_serch.DataContext = my_model_serch;

            my_serch.ShowDialog();

            if(my_model_serch.is_ok)
            {
                Select_Item = my_model_serch._select_Item;
            }

        }
        private bool CanExecute_specific(object o)
        {

            if (my_photo.Count != 0)
            {
                return true;
            }
            return false;

        }

        private DelegateCommand _Command_add;
        public ICommand Button_clik_add
        {
            get
            {
                if (_Command_add == null)
                {
                    _Command_add = new DelegateCommand(Execute_add, CanExecute_add);
                }
                return _Command_add;
            }
        }
        private void Execute_add(object o)
        {

            Add_Image my_add = new Add_Image();

            AddViewModel my_model_add = new AddViewModel();


            if (my_model_add._Add== null)
                my_model_add._Add = new Action(my_add.Close);

            my_add.DataContext = my_model_add;

            my_model_add.Autor = _i_autor;

            my_add.ShowDialog();
            if(my_model_add.is_add)
            {
                my_photo.Add(new PhotoViewModel(my_model_add.Temp.Clone() as Photos));
            }
            
        }
        private bool CanExecute_add(object o)
        {
            return true;
        }


        private DelegateCommand _Command_del;
        public ICommand Button_clik_del
        {
            get
            {
                if (_Command_del == null)
                {
                    _Command_del = new DelegateCommand(Execute_del, CanExecute_del);
                }
                return _Command_del;
            }
        }
        private void Execute_del(object o)
        {
            for (int i = 0; i < my_photo.Count; i++)
            {
                if (Select_Item == my_photo[i])
                {
                    my_photo.Remove(_select_Item);

                    if (my_photo.Count < i)
                    {
                        Select_Item = my_photo[i];
                    }
                    else if (my_photo.Count > i-1 && i-1>=0)
                    {
                        Select_Item = my_photo[i-1];
                    }
                    else if (my_photo.Count ==1)
                    {
                        Select_Item = my_photo[0];
                    }
                    else
                    {
                        Select_Item = null;
                    }
                    return;
                }
            }
        }
        private bool CanExecute_del(object o)
        {
            if (_select_Item != null)
                return true;
            return false;
          

        }

        private DelegateCommand _Command_exit;
        public ICommand Button_clik_exit
        {
            get
            {
                if (_Command_exit == null)
                {
                    _Command_exit = new DelegateCommand(Execute_exit, CanExecute_exit);
                }
                return _Command_exit;
            }
        }
        private void Execute_exit(object o)
        {



        }
        private bool CanExecute_exit(object o)
        {

            return true;

        }








        private DelegateCommand _Command_marc1;
        public ICommand Button_clik_marc1
        {
            get
            {
                if (_Command_marc1 == null)
                {
                    _Command_marc1 = new DelegateCommand(Execute_marc1, CanExecute_marc1);
                }
                return _Command_marc1;
            }
        }
        private void Execute_marc1(object o)
        {

            Mark = 1;
           
        }
        private bool CanExecute_marc1(object o)
        {


            return true;


        }

        private DelegateCommand _Command_marc2;
        public ICommand Button_clik_marc2
        {
            get
            {
                if (_Command_marc2 == null)
                {
                    _Command_marc2 = new DelegateCommand(Execute_marc2, CanExecute_marc2);
                }
                return _Command_marc2;
            }
        }
        private void Execute_marc2(object o)
        {

            Mark = 2;
           
        }
        private bool CanExecute_marc2(object o)
        {


            return true;


        }

        private DelegateCommand _Command_marc3;
        public ICommand Button_clik_marc3
        {
            get
            {
                if (_Command_marc3 == null)
                {
                    _Command_marc3= new DelegateCommand(Execute_marc3, CanExecute_marc3);
                }
                return _Command_marc3;
            }
        }
        private void Execute_marc3(object o)
        {
            Mark = 3;
         

        }
        private bool CanExecute_marc3(object o)
        {


            return true;


        }

        private DelegateCommand _Command_marc4;
        public ICommand Button_clik_marc4
        {
            get
            {
                if (_Command_marc4 == null)
                {
                    _Command_marc4 = new DelegateCommand(Execute_marc4, CanExecute_marc4);
                }
                return _Command_marc4;
            }
        }
        private void Execute_marc4(object o)
        {

            Mark = 4;
           
        }
        private bool CanExecute_marc4(object o)
        {


            return true;


        }

        private DelegateCommand _Command_marc5;
        public ICommand Button_clik_marc5
        {
            get
            {
                if (_Command_marc5 == null)
                {
                    _Command_marc5 = new DelegateCommand(Execute_marc5, CanExecute_marc5);
                }
                return _Command_marc5;
            }
        }
        private void Execute_marc5(object o)
        {

            Mark = 5;
           
        }
        private bool CanExecute_marc5(object o)
        {


            return true;


        }

        #endregion Command_button


        public bool is_ok;

        public bool is_no;


        public Action _OK { get; set; }
        public Action _NO { get; set; }


      

    }
}
