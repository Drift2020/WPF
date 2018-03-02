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

        private int levl_pos;

        public Info(int Levl, List<List<int>> Pole, int Levl_pos)
        {       
            levl = Levl;
            pole = Pole;
            levl_pos = Levl_pos;
        }
        public Info()
        {
           
        }
        public List<List<int>> Pole { get { return pole; } set { pole = value; } }
        public int Levl_pos { get { return levl_pos; } set { levl_pos = value; } }
        public int Levl { get { return levl; } set { levl = value; } }
    }
}
