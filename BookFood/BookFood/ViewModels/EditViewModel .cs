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
    class EditViewModel : ViewModelBase
    {
        private FoodViewModel _food;

        public EditViewModel(FoodViewModel food)
        {
            _food = new FoodViewModel(food);
                
            OnPropertyChanged(nameof(Food));
        }

        private DelegateCommand _Command;



       

        public FoodViewModel Food
        {
            get
            {
                return _food;
            }
            set
            {
                _food = value;
                OnPropertyChanged(nameof(Food));
            }
        }

     //   private string _name_food;
        public string Name_food
        {
            get
            {
                return _food.Name_food;
            }
            set
            {
                _food.Name_food = value;
                OnPropertyChanged(nameof(Name_food));
            }
        }

     //   private string _image_path;
        public string Image_path
        {
            get
            {
                return _food.Image_path;
            }
            set
            {
                _food.Image_path = value;
                OnPropertyChanged(nameof(Image_path));
            }
        }

     //   private List<string> _list_ingridient;
        public List<string> List_ingridient
        {
            get
            {
                return _food.List_ingridient;
            }
            set
            {
                _food.List_ingridient = value;
                OnPropertyChanged(nameof(List_ingridient));
            }
        }
        private string _item_ingridient;
        public string Item_ingridient
        {
            get
            {
                return _item_ingridient;
            }
            set
            {
                _item_ingridient = value;
            }
        }

       // private string _info_food;
        public string Info_food
        {
            get
            {
                OnPropertyChanged(nameof(Info_food));
                return _food.Info_food;

            }
            set
            {
                _food.Info_food = value;
                OnPropertyChanged(nameof(Info_food));
            }
        }

        public ICommand Button_Click_Ok
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
           // DialogResult


        }

        private bool CanExecute(object o)
        {
            if (_food.Name_food == string.Empty || _food.Image_path == string.Empty || _food.Info_food == string.Empty || _food.List_ingridient.Count!=0)
                return false;
            return true;
        }
    }
}
