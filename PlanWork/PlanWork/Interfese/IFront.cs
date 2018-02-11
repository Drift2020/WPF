using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlanWork.Interfese
{
    public interface IFront
    {
        List<string> WorkList { get; set; }
        ListBox Worc{get;set;}
         string NewMesege { get; set; }


    }
}
