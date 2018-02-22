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
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Models.Food> FoodsList { get; set; }

        public MainViewModel(List<Models.Food> Foods)
        {
            FoodsList = new ObservableCollection<Models.Food>(Foods.Select(b => new Models.Food(b)));
        }

        private DelegateCommand _Command;
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
            Add_food myAdd = new Add_food();


        }

        private bool CanExecute(object o)
        {
           
            return true;
        }
    }
}
