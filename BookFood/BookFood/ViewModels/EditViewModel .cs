using BookFood.Commands;
using Microsoft.Win32;
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

        private DelegateCommand _Command_Open;
        public ICommand Button_Click_Open
        {
            get
            {
                if (_Command_Open == null)
                {
                    _Command_Open = new DelegateCommand(Execute_Open, CanExecute_Open);
                }
                return _Command_Open;
            }
        }
        private void Execute_Open(object o)
        {
            // Food.Add(new Models.Food() { name_food = _name_food, image_path = _image_path, list_ingridient = _list_ingridient, info_food = _info_food });
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

        }

        private bool CanExecute_Open(object o)
        {
            // if (_name_food == string.Empty || _image_path == string.Empty|| _info_food == string.Empty|| _list_ingridient.Count!=0)
            //    return false;
            return true;
        }

        private DelegateCommand _Command;
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
