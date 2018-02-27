using BookFood.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookFood.Models;
using System.Xml.Serialization;

namespace BookFood
{
    [Serializable(), XmlInclude(typeof(FoodViewModel))]
    public class FoodViewModel : ViewModelBase , ICloneable
    {
        public object Clone()
        {
            string[] t = new string[List_ingridient.Count];
            List_ingridient.CopyTo(t, 0);


            return new FoodViewModel(Name_food, Image_path, Info_food,new ObservableCollection<string>(t));
        }


        private Food food;
        public FoodViewModel()
        {
            food = new Food();
        }
        public FoodViewModel(Food food)
        {
            this.food = food;
        }
        public FoodViewModel(FoodViewModel food)
        {
            this.food = new Food(food.Name_food, food.Image_path, food.Info_food, food.List_ingridient);
           
        }
        public FoodViewModel(string Name_food, string Image_path, string Info_food, ObservableCollection<string>List_ingridient)
        {
            this.food = new Food(Name_food, Image_path, Info_food, List_ingridient);

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
        public ObservableCollection<string> List_ingridient
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
