using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookFood.Models;

namespace BookFood.ViewModels
{
    class FoodViewModel : ViewModelBase
    {
        private Food food;

        public FoodViewModel(Food food)
        {
            this.food = food;
        }

        public string Name_food
        {
            get { return food.name_food; }
            set
            {
                food.name_food = value;
                OnPropertyChanged(nameof(Name_food));
            }
        }

        public string Image_path
        {
            get { return food.image_path; }
            set
            {
                food.image_path = value;
                OnPropertyChanged(nameof(Image_path));
            }
        }
        public List<string> List_ingridient
        {
            get { return food.list_ingridient; }
            set
            {
                food.list_ingridient = value;
                OnPropertyChanged(nameof(List_ingridient));
            }
        }

        public string Info_food
        {
            get { return food.info_food; }
            set
            {
                food.info_food = value;
                OnPropertyChanged(nameof(Info_food));
            }
        }
        

    }
}
