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
        private string program;
        private DateTime timeThis;
        private Work myWork;
        private bool[] days_of_the_week;
        public Info(string Path,string Program,DateTime TimeThis,Work MyWork)
        {
            path = Path;
            program = Program;
            timeThis = TimeThis;
            myWork = MyWork;
        }
        
        public string Path { get { return path; } set { path = value; } }
        public string Program { get { return program; } set { program = value; } }
        public DateTime TimeThis { get { return timeThis; } set { timeThis = value; } }
        public Work MyWork { get { return myWork; } set { myWork = value; } }
    }
}
