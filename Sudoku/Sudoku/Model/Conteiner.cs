using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sudoku
{
    [Serializable(), XmlInclude(typeof(Info))]
    public class Сontainer
    {

        List<Info> informs = new List<Info>();

        ISerializer serialize;
        public Сontainer() { }

        public void SetSerializer(ISerializer serialize)
        {
            this.serialize = serialize;

        }

        public void Add(Info Info)
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
        public void Remove(Info obj)
        {
            
            informs.Remove(obj);
            // log.Write("Удаление успешно выполнено!");
        }

        public void RemoveAll()
        {
            informs.RemoveRange(0, informs.Count);
            // log.Write("Все данные успешно удалены!");
        }
        public void Save()
        {
            serialize.Save(informs);
            //  log.Write("Сериализация успешно выполнена!");
        }
        public void Load()
        {
            informs = serialize.Load() as List<Info>;
            //  log.Write("Десериализация успешно выполнена!");
        }
        public Info Element(int index)
        {
            return informs[index];
        }
        public int Count()
        {
            return informs.Count;
        }
   

    }
}
