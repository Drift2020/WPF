using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    public interface ISerializer
    {
        void Save<T>(ICollection<T> collection, string s);
        ICollection<T> Load<T>(string s);
    }


}
