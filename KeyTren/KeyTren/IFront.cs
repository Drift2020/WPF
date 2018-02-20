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
        int level { set; get; }

        bool is_Fail { get; set; }
        bool is_Start { set; get; }

        bool is_Start_button { set; get; }
        bool is_Stop_button { set; get; }
        bool is_Enable_text_box { set; get; }
        bool is_Enable_slad_box { set; get; }
        bool is_Enable_chek_box { set; get; }


      
        event EventHandler<EventArgs> DownKey;
        event EventHandler<EventArgs> Start;
        event EventHandler<EventArgs> Stop;
        event EventHandler<EventArgs> Start_program;
        event EventHandler<EventArgs> Speed_Chars;
        event EventHandler<EventArgs> Fails;
    }
}
