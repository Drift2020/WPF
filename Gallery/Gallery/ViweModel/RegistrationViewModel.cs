using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gallery
{
    class RegistrationViewModel:ViewModelBase
    {

        public RegistrationViewModel()
        {
            my_users = new СontainerUser();
            my_users.SetSerializer(new XMLSerializer());
            my_users.Load("user");



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
        #region Pole 
        СontainerUser my_users;
       


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


        string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }


        string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        string password2;
        public string Password2
        {
            get
            {
                return password2;
            }
            set
            {
                password2 = value;
                OnPropertyChanged(nameof(Password2));
            }
        }

        #endregion Pole 



        #region Command_button

        private DelegateCommand _Command_ok;
        public ICommand Button_clik_ok
        {
            get
            {
                if (_Command_ok == null)
                {
                    _Command_ok = new DelegateCommand(Execute_ok, CanExecute_ok);
                }
                return _Command_ok;
            }
        }
        private void Execute_ok(object o)
        {
            if(password!=password2)
            {
                OpenMessege("Passwords do not match, the minimum length is 4 characters.", "Error");
                return;
            }

            for (int i = 0; i < my_users.Count(); i++)
            {
                if (my_users.Element(i).login == login)
                {
                   
                    OpenMessege("This login is already in use.", "Error");
                    break;
                }
            }

            my_users.Add(new Users(name, surname, login, password));
            is_ok = true;

            my_users.Save("user");
            _OK();


        }
        private bool CanExecute_ok(object o)
        {

            if ((login != null && login != "") &&
                (password != null && password != "")&&
                (password2 != null && password2 != "") &&
                (name != null && name != "")&&
                (surname != null && surname != ""))
                return true;
            return false;

        }





        private DelegateCommand _Command_no;
        public ICommand Button_clik_no
        {
            get
            {
                if (_Command_no == null)
                {
                    _Command_no = new DelegateCommand(Execute_no, CanExecute_no);
                }
                return _Command_no;
            }
        }
        private void Execute_no(object o)
        {

            is_no = true;
            _OK();
        }
        private bool CanExecute_no(object o)
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
