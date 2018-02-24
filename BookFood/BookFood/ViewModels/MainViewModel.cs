using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookFood.Models;
using System.Windows.Controls;

namespace BookFood.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<FoodViewModel> FoodsList { get; set; }

        public MainViewModel(List<Food> Foods)
        {
            FoodsList = new ObservableCollection<FoodViewModel>(Foods.Select(f => new FoodViewModel(f)));
        }

        FoodViewModel _select_Item;
        public FoodViewModel Select_Item
        {
            get { return _select_Item; }
            set
            {
                _select_Item = value;
                OnPropertyChanged(nameof(Select_Item));
            }
        }


        private DelegateCommand _Command;
        public ICommand ButtonClick_New_Food
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

            Add_food myAdd = new Add_food();
            AddViewModel myViewModel = new AddViewModel();
            myAdd.DataContext = myViewModel;
            myAdd.ShowDialog();

        }

        private bool CanExecute(object o)
        {                
                return true;
          
        }


        private DelegateCommand _Command_edit;
        public ICommand ButtonClick_Edit_Food
        {
            get
            {
                if (_Command_edit == null)
                {
                    _Command_edit = new DelegateCommand(Execute_Edit, CanExecute_Edit);
                }
                return _Command_edit;
            }
        }



        private void Execute_Edit(object o)
        {

            Add_food myEdit = new Add_food();
            EditViewModel myViewModel = new EditViewModel(_select_Item);
            myEdit.DataContext = myViewModel;
            myEdit.ShowDialog();

        }

        private bool CanExecute_Edit(object o)
        {
            return true;

        }


    }
}
