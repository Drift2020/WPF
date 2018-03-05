using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sudoku
{
   
    [Serializable(), XmlInclude(typeof(Info))]
    public class Info
    {
        private int levl;

        List<List<int>> pole;

      

        public Info(int Levl, List<List<int>> Pole)
        {       
            levl = Levl;
            pole = Pole;
           
        }
        public Info()
        {
           
        }
        public List<List<int>> Pole { get { return pole; } set { pole = value; } }
    
        public int Levl { get { return levl; } set { levl = value; } }
    }
}
