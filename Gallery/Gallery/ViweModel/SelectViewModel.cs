using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Gallery
{
    class SelectViewModel : ViewModelBase
    {

        public ObservableCollection<PhotoViewModel> my_photo { get; set; }
        public bool is_ok;     
        public Action _OK { get; set; }
        public PhotoViewModel _select_Item;
        public SelectViewModel(ObservableCollection<PhotoViewModel> _my_photo)
        {
            my_photo = _my_photo;
        }

        string name;
        public string Name
        {
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
            get
            {
                return name;
            }
        }

        private DelegateCommand _Command_search;
        public ICommand Button_clik_search
        {
            get
            {
                if (_Command_search == null)
                {
                    _Command_search = new DelegateCommand(Execute_search, CanExecute_search);
                }
                return _Command_search;
            }
        }
        private void Execute_search(object o)
        {
            for (int i = 0; i < my_photo.Count; i++)
            {
                if (my_photo[i].Name==name)
                {
                    _select_Item = my_photo[i];
                    is_ok = true;
                    _OK();
                }
            }

        }
        private bool CanExecute_search(object o)
        {

            if(name!=null && name != "")
            return true;

            return false;

        }

      
       
    }
}
