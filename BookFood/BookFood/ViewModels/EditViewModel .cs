using BookFood.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookFood
{
    public class EditViewModel : ViewModelBase
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

        #region Pol9l
        int? _select_Item;
        public int? Select_Item
        {
            get { return _select_Item; }
            set
            {
                _select_Item = value;
                OnPropertyChanged(nameof(Select_Item));
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

     
        public ObservableCollection<string> List_ingridient
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
        public string Item_food_ingridient
        {
            get
            {
                return _item_ingridient;
            }
            set
            {
                _item_ingridient = value;
                OnPropertyChanged(nameof(Item_food_ingridient));
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
      

        #endregion Pol9l

        public Action CloseAction { get; set; }
        public bool is_ok { get; set; }


        private DelegateCommand _Command_Cansel;
        public ICommand Button_Click_Cansel
        {
            get
            {
                if (_Command_Cansel == null)
                {
                    _Command_Cansel = new DelegateCommand(Execute_Cansel, CanExecute_Cansel);
                }
                return _Command_Cansel;
            }
        }
        private void Execute_Cansel(object o)
        {
            is_ok = false;
            CloseAction();
        }
        private bool CanExecute_Cansel(object o)
        {
          
            return true;
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
            openFileDialog.FileName = Image_path;
            openFileDialog.InitialDirectory = Image_path;
            openFileDialog.ShowDialog();
            Image_path = openFileDialog.FileName;
        }
        private bool CanExecute_Open(object o)
        {
            // if (_name_food == string.Empty || _image_path == string.Empty|| _info_food == string.Empty|| _list_ingridient.Count!=0)
            //    return false;
            return true;
        }

   
        private DelegateCommand _Command_Ok;
        public ICommand Button_Click_Ok
        {
            get
            {
                if (_Command_Ok == null)
                {
                    _Command_Ok = new DelegateCommand(Execute, CanExecute);
                }
                return _Command_Ok;
            }
        }
        private void Execute(object o)
        {
            // DialogResult
            is_ok = true;
            CloseAction();

        }
        private bool CanExecute(object o)
        {
            if (_food.Name_food == string.Empty || _food.Image_path == string.Empty || _food.Info_food == string.Empty || _food.List_ingridient.Count==0)
                return false;
            return true;
        }


        private DelegateCommand _Command_Add;
        public ICommand Button_Click_Add
        {
            get
            {
                if (_Command_Add == null)
                {
                    _Command_Add = new DelegateCommand(Execute_Add, CanExecute_Add);
                }
                return _Command_Add;
            }
        }
        private void Execute_Add(object o)
        {
            // DialogResult
            _food.List_ingridient.Add(Item_food_ingridient);
            Item_food_ingridient = "";
        }
        private bool CanExecute_Add(object o)
        {
            if (Item_food_ingridient == string.Empty || Item_food_ingridient==null)
                return false;
            return true;
        }


        private DelegateCommand _Command_Del;
        public ICommand Button_Click_Del
        {
            get
            {
                if (_Command_Del == null)
                {
                    _Command_Del = new DelegateCommand(Execute_Del, CanExecute_Del);
                }
                return _Command_Del;
            }
        }
        private void Execute_Del(object o)
        {
            // DialogResult
            List_ingridient.RemoveAt(_select_Item.Value);
            _select_Item = null;
        }
        private bool CanExecute_Del(object o)
        {
            if (_select_Item==null)
                return false;
            return true;
        }
    }
}
