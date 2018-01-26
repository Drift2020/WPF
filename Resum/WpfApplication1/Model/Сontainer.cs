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
      
       

            List<Info> ques = new List<Info>();

            ISerializer serialize;
            public Сontainer() { }
            public void SetSerializer(ISerializer serialize)
            {
                this.serialize = serialize;

            }

            public void Add(Info question)
            {
                this.ques.Add(question);
              
            }
            public void Remove(int index)
            {
                if (index < 0 || index >= ques.Count)
                    return;
                ques.RemoveAt(index);
              
            }

            public void RemoveAll()
            {
                ques.RemoveRange(0, ques.Count);
               
            }
            public void Save()
            {
                serialize.Save(ques);
                
            }
            public void Load()
            {
                ques = serialize.Load() as List<Info>;
                
            }
            public Info Element(int index)
            {
                return ques[index];
            }
            public int Count()
            {
                return ques.Count;
            }               
    }
}
