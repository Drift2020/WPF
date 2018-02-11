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
        private DateTime dateThis;
        private Work myWork;
        private bool[] days_of_the_week;
        private int number;
        public Info(string Path , DateTime DateThis, Work MyWork,bool[] Days_of_the_week)
        {
            path = Path;
            dateThis = DateThis;
          
            myWork = MyWork;
            days_of_the_week = Days_of_the_week;
           
        }
        public Info()
        {
           
        }
        public string Path { get { return path; } set { path = value; } }
        public DateTime DateThis { get { return dateThis; } set { dateThis = value; } }
        public bool[] Days_of_the_week { get { return days_of_the_week; } set { days_of_the_week = value; } }
        public Work MyWork { get { return myWork; } set { myWork = value; } }

        public int Number { get { return number; } set { number = value; } }
    }
}
