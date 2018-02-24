using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookFood.ViewModels
{
    class AddViewModel : ViewModelBase
    {
        public AddViewModel()
        {
            
        }

        private DelegateCommand _Command;



        private ObservableCollection<Models.Food> _food = new ObservableCollection<Models.Food>();

        public ObservableCollection<Models.Food> Food
        {
            get
            {
                return _food;
            }
            set
            {
                _food = value;
              //  OnPropertyChanged(nameof(Persons));
            }
        }

        private string _name_food;
        public string Name_food
        {
            get
            {
                return _name_food;
            }
            set
            {
                _name_food = value;
            }
        }

        private string _image_path;
        public string Image_path
        {
            get
            {
                return _image_path;
            }
            set
            {
                _image_path = value;
              //  RaisePropertyChanged(nameof(CurrentName));
            }
        }

        private List<string> _list_ingridient;
        public List<string> List_ingridient
        {
            get
            {
                return _list_ingridient;
            }
            set
            {
                _list_ingridient = value;
            }
        }

        private string _info_food;
        public string Info_food
        {
            get
            {
                return _info_food;
            }
            set
            {
                _info_food = value;
            }
        }

        public ICommand ButtonClick
        {
            get
            {
                if (_Command == null)
                {
                    _Command = new DelegateCommand(Execute, CanExecute);
                }
                return _Command;
            }
        }
        private void Execute(object o)
        {
            Food.Add(new Models.Food() { name_food = _name_food, image_path = _image_path, list_ingridient = _list_ingridient, info_food = _info_food });
           
        }

        private bool CanExecute(object o)
        {
            if (_name_food == string.Empty || _image_path == string.Empty|| _info_food == string.Empty|| _list_ingridient.Count!=0)
                return false;
            return true;
        }
    }
}
