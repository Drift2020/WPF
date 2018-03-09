using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    class LoginViewModel
    {

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

            is_ok = true;
            _OK();
        }
        private bool CanExecute_ok(object o)
        {

            return true;


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

        private DelegateCommand _Command_cancel;
        public ICommand Button_clik_cancel
        {
            get
            {
                if (_Command_cancel == null)
                {
                    _Command_cancel = new DelegateCommand(Execute_cancel, CanExecute_cancel);
                }
                return _Command_cancel;
            }
        }
        private void Execute_cancel(object o)
        {

            is_cancel = true;
            _CANCEL();
        }
        private bool CanExecute_cancel(object o)
        {

            return true;


        }

        #endregion Command_button


        public bool is_ok;
        public bool is_no;
        public bool is_cancel;
    }
}
