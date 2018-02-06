using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1.Interfese
{
    public interface IFront
    {
        event EventHandler<EventArgs> AddResum;
        event EventHandler<EventArgs> OpenList;

     

        string Nfo
        {
            get;
            set;
        }
         string Value
        {
            get;
            set;
        }
         string FamelyStatys
        {
            get;
            set;
        }
        string Adress
        {
            get;
            set;
        }
        string E_mail
        {
            get;
            set;
        }
        bool[] ChecBoxs
        {
            get;
            set;
        }

        List<string> ElementResum
        {
            get;
            set;
        }

    }
}
