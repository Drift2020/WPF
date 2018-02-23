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
            myAdd.ShowDialog();

        }

        private bool CanExecute(object o)
        {                
                return true;
          
        }




    }
}
