using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PlanWork.Model
{
    public enum Work { daily, weekly, monthly, once }
    [Serializable(), XmlInclude(typeof(Info))]
    public class Info
    {
        private string path;
        private string timeThis;
        private string dateThis;
        private Work myWork;
        private bool[] days_of_the_week;

        public Info(string Path, string TimeThis ,string DateThis, Work MyWork,bool[] Days_of_the_week)
        {
            path = Path;
            dateThis = DateThis;
            timeThis = TimeThis;
            myWork = MyWork;
            days_of_the_week = Days_of_the_week;
        }
        public Info()
        {
           
        }
        public string Path { get { return path; } set { path = value; } }
        public string DateThis { get { return dateThis; } set { dateThis = value; } }
        public bool[] Days_of_the_week { get { return days_of_the_week; } set { days_of_the_week = value; } }
        public string TimeThis { get { return timeThis; } set { timeThis = value; } }
        public Work MyWork { get { return myWork; } set { myWork = value; } }
    }
}
