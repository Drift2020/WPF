using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanWork.Interfese
{
    public interface IEdit
    {
        string Path { get; set; }
        DateTime DateThis { get; set; }
        bool[] Days_of_the_week { get; set; }
        int Number { get; set; }
        Model.Work MyWork { get; set; }
    }
}
