using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gallery
{
    class LoginViewModel : ViewModelBase
    {


        #region Pole 
        List<Model.Users> my_users;


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
            foreach (Model.Users e in my_users)
            {
                if(e.login==login && e.password == password)
                {
                    is_ok = true;
                    _OK();
                }
            }

            is_none_user = true;
            _NONE_USER();         
        }
        private bool CanExecute_ok(object o)
        {

            if((login!=null&& login!="")&& (password != null && password != ""))
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
            _NO();
        }
        private bool CanExecute_no(object o)
        {

            return true;


        }

       
        #endregion Command_button


        public bool is_ok;
        public bool is_none_user;
        public bool is_no;


        public Action _OK { get; set; }
        public Action _NO { get; set; }
        public Action _NONE_USER { get; set; }
    }
}
