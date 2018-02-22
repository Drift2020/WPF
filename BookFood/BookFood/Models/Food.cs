using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFood.Models
{
    class Food
    {
        public Food()
        {

        }
        public Food(Food book)
        {
            name_food = book.name_food;
            image_path = book.image_path;
            list_ingridient = book.list_ingridient;
            info_food = book.info_food;
    }
        public Food( string Name_food, string Image_path, string Info_food, List<string> List_ingridient)
        {
            name_food = Name_food;
            image_path = Image_path;
            list_ingridient = List_ingridient;
            info_food = Info_food;
        }
    
        public string name_food { get; set; }
        public string image_path { get; set; }
        public List<string> list_ingridient{ get; set; }
        public string info_food { get; set; }
    }
}
