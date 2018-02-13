using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanWork.Class
{
    public class Add_Item: Interfese.IAdd
    {
        private string path;
        Model.Сontainer myInfo;
        private DateTime dateThis;
        private Model.Work myWork;
        private bool[] days_of_the_week;
        private int number;

        public int Number { get { return number; } set { number = value; } }
        public string Path { get { return path; } set { path = value; } }
        public DateTime DateThis { get { return dateThis; } set { dateThis = value; } }
        public bool[] Days_of_the_week { get { return days_of_the_week; } set { days_of_the_week = value; } }
       
        public Model.Work MyWork { get { return myWork; } set { myWork = value; } }


        public Add_Item(string Path, DateTime DateThis, Model.Work MyWork, bool[] Days_of_the_week,int Number)
        {
            myInfo = new Model.Сontainer();
            myInfo.SetSerializer(new Model.XMLSerializer());
            myInfo.Load();

            path = Path;
            dateThis = DateThis;
            number = myInfo.Count();
            myWork = MyWork;
            days_of_the_week = Days_of_the_week;


        }
        public Add_Item(Interfese.IAdd view)
        {
            myInfo = new Model.Сontainer();
            myInfo.SetSerializer(new Model.XMLSerializer());
            myInfo.Load();

            path = view.Path;
            dateThis = view.DateThis;

            number = myInfo.Count();

            myWork = view.MyWork;
            days_of_the_week = view.Days_of_the_week;

            myInfo.Save();

        }
        
    }
}
