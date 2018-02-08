using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PlanWork.Model
{
    [Serializable(), XmlInclude(typeof(Info))]
    public class Сontainer
    {

        List<Info> ques = new List<Info>();

        ISerializer serialize;
        public Сontainer() { }

        public void SetSerializer(ISerializer serialize)
        {
            this.serialize = serialize;

        }

        public void Add(Info Info)
        {
            this.ques.Add(Info);
            //  log.Write("Данные успешно добавлены!");
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= ques.Count)
                return;
            ques.RemoveAt(index);
            // log.Write("Удаление успешно выполнено!");
        }

        public void RemoveAll()
        {
            ques.RemoveRange(0, ques.Count);
            // log.Write("Все данные успешно удалены!");
        }
        public void Save()
        {
            serialize.Save(ques);
            //  log.Write("Сериализация успешно выполнена!");
        }
        public void Load()
        {
            ques = serialize.Load() as List<Info>;
            //  log.Write("Десериализация успешно выполнена!");
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
