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
       
        private DateTime dateThis;
        private Model.Work myWork;
        private bool[] days_of_the_week;

        public string Path { get { return path; } set { path = value; } }
        public DateTime DateThis { get { return dateThis; } set { dateThis = value; } }
        public bool[] Days_of_the_week { get { return days_of_the_week; } set { days_of_the_week = value; } }
       
        public Model.Work MyWork { get { return myWork; } set { myWork = value; } }


        public Add_Item(string Path, DateTime DateThis, Model.Work MyWork, bool[] Days_of_the_week)
        {
            path = Path;
            dateThis = DateThis;
           
            myWork = MyWork;
            days_of_the_week = Days_of_the_week;
        }
        public Add_Item(Interfese.IAdd view)
        {
            path = view.Path;
            dateThis = view.DateThis;
         
            myWork = view.MyWork;
            days_of_the_week = view.Days_of_the_week;
        }
        
    }
}
