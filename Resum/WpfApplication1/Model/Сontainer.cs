using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApplication1.Model
{
    [Serializable(), XmlInclude(typeof(Info))]
    class Сontainer
    {
      
       

            List<Info> InfoUser = new List<Info>();

            ISerializer serialize;
            public Сontainer() { }
            public void SetSerializer(ISerializer serialize)
            {
                this.serialize = serialize;

            }

            public void Add(Info InfoUser)
            {
                this.InfoUser.Add(InfoUser);
              
            }
            public void Remove(int index)
            {
                if (index < 0 || index >= InfoUser.Count)
                    return;
                InfoUser.RemoveAt(index);
              
            }

            public void RemoveAll()
            {
                InfoUser.RemoveRange(0, InfoUser.Count);
               
            }
            public void Save()
            {
                serialize.Save(InfoUser);
                
            }
            public void Load()
            {
                InfoUser = serialize.Load() as List<Info>;
                
            }
            public Info Element(int index)
            {
                return InfoUser[index];
            }
            public int Count()
            {
                return InfoUser.Count;
            }               
    }
}
