using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyTren
{
    public interface IFront
    {
         string prow_str { set; get; }
         string my_str { set; get; }

        string my_chars { set; get; }
        bool sensitive { set; get; }

        int fails { set; get; }
        int speed_chars { set; get; }

       

        event EventHandler<EventArgs> DownKey;
        event EventHandler<EventArgs> Start;
        event EventHandler<EventArgs> Stop;

        event EventHandler<EventArgs> Speed_Chars;
        event EventHandler<EventArgs> Fails;
    }
}
