using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookFood.Models
{
    [Serializable(), XmlInclude(typeof(Food))]
    public class Food : ICloneable
    {
        public object Clone()
        {
            return new Food(name_food, image_path, info_food, list_ingridient);
        }
        public Food()
        {
            name_food = "";
            image_path = "";
            list_ingridient = new ObservableCollection<string>();
            info_food = "";
        }
        public Food(Food book)
        {
            name_food = book.name_food;
            image_path = book.image_path;
            list_ingridient = book.list_ingridient;
            info_food = book.info_food;
        }
        public Food(string Name_food, string Image_path, string Info_food, ObservableCollection<string> List_ingridient)
        {
            name_food = Name_food;
            image_path = Image_path;
            list_ingridient = List_ingridient;
            info_food = Info_food;
        }
       
        public string name_food { get; set; }
       
        public string image_path { get; set; }
        public ObservableCollection<string> list_ingridient{ get; set; }
        public string info_food { get; set; }


    }
}
