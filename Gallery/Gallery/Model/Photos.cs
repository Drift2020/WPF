using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gallery.Model
{
    [Serializable(), XmlInclude(typeof(Photos))]
    class Photos : ICloneable
    {
        public object Clone()
        {
            return new Photos(name, path, date, author, mark);
        }
        public Photos()
        {

        }

        public Photos(string _name, string _path, string _date, string _author, int _mark)
        {
            name = _name;
            path = _path;
            date = _date;
            author = _author;
            mark = _mark;
        }


        public string name { get; set; }
        public string path { get; set; }
        public string date { get; set; }
        public string author { get; set; }
        public int mark { get; set; }
    }
}
