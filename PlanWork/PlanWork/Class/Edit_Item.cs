using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanWork.Class
{
    class Edit_Item :Interfese.IEdit
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


    }
}
