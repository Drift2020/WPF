using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gallery
{
    [Serializable(), XmlInclude(typeof(Photos))]
    public class СontainerPhoto
    {

        List<Photos> informs = new List<Photos>();

        ISerializer serialize;
        public СontainerPhoto() {
            informs = new List<Photos>();
        }

        public void SetSerializer(ISerializer serialize)
        {
            this.serialize = serialize;

        }

        public void Add(Photos Info)
        {
            this.informs.Add(Info);
            //  log.Write("Данные успешно добавлены!");
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= informs.Count)
                return;
            informs.RemoveAt(index);
            // log.Write("Удаление успешно выполнено!");
        }
        public void Remove(Photos obj)
        {
            
            informs.Remove(obj);
            // log.Write("Удаление успешно выполнено!");
        }

        public void RemoveAll()
        {
            informs.RemoveRange(0, informs.Count);
            // log.Write("Все данные успешно удалены!");
        }
        public void Save(string s)
        {
            serialize.Save<Photos>(informs,s);
            //  log.Write("Сериализация успешно выполнена!");
        }
        public void Load(string s)
        {
            informs = serialize.Load<Photos>(s) as List<Photos>;
            //  log.Write("Десериализация успешно выполнена!");
        }
        public Photos Element(int index)
        {
            return informs[index];
        }
        public int Count()
        {
            return informs.Count;
        }
   

    }
}
