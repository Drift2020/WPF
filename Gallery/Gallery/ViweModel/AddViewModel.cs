using BookFood.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gallery
{
    class AddViewModel:ViewModelBase
    {

       Photos temp;
        public Photos Temp { get { return temp; } private set { } }

       public AddViewModel()
        {
            temp = new Photos();
            is_add = false;
        }

        #region pole 
      
        public string Path
        {
            get
            {
                return temp.path;
            }
            set
            {
                temp.path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        public string Autor
        {
            get
            {
                return temp.author;
            }
            set
            {
                temp.author = value;
                OnPropertyChanged(nameof(Autor));
            }
        }

       public bool is_add;

        #endregion pole

        #region command
        private DelegateCommand _Command_open;
        public ICommand Button_clik_open
        {
            get
            {
                if (_Command_open == null)
                {
                    _Command_open = new DelegateCommand(Execute_open, CanExecute_open);
                }
                return _Command_open;
            }
        }
        private void Execute_open(object o)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.ShowDialog();

            Path = openFileDialog.FileName;
            temp.date = DateTime.Now.ToString();
            temp.name = openFileDialog.SafeFileName;
            temp.mark = 1;
        }
        private bool CanExecute_open(object o)
        {


            return true;


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
            is_add = true;
            _Add();
        }
        private bool CanExecute_add(object o)
        {

            if(Path!=null || Path != "")
            return true;
            return false;

        }
        #endregion command

        public Action _Add { get; set; }
    }
}
