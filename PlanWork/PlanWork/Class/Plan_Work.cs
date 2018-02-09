using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanWork.Class
{
    class Plan_Work
    {
        Model.Сontainer myInfo;
        private string path;
        private string timeThis;
        private string dateThis;
        private Model.Work myWork;
        private bool[] days_of_the_week;

        public string Path { get { return path; } set { path = value; } }
        public string DateThis { get { return dateThis; } set { dateThis = value; } }
        public bool[] Days_of_the_week { get { return days_of_the_week; } set { days_of_the_week = value; } }
        public string TimeThis { get { return timeThis; } set { timeThis = value; } }
        public Model.Work MyWork { get { return myWork; } set { myWork = value; } }


        public void Add(Interfese.IAdd viwe)
        {
            path = viwe.Path;
            dateThis = viwe.DateThis;
            timeThis = viwe.TimeThis;
            myWork = viwe.MyWork;
            days_of_the_week = viwe.Days_of_the_week;

            myInfo.Add(new Model.Info(path, timeThis, dateThis, myWork, days_of_the_week));

        }
        public Plan_Work()
        {
        
        }
    }
}
