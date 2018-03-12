using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gallery
{
    class XMLSerializer : ISerializer
    {
        FileStream stream = null;
        XmlSerializer serializer = null;
        public void Save<T>(ICollection<T> collection, string s)
        {

            stream = new FileStream("../../" + s + ".xml", FileMode.Create);
            serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(stream, collection);
            stream.Close();
            Console.WriteLine("Сериализация успешно выполнена!");
        }
        public ICollection<T> Load<T>(string s)
        {
            List<T> temp;
            try
            {
                stream = new FileStream("../../"+s+".xml", FileMode.Open);
                serializer = new XmlSerializer(typeof(List<T>));
                temp = (List<T>)serializer.Deserialize(stream);


                stream.Close();

                return temp;
            }
            catch (Exception ex)
            {
                
                if (stream != null)
                    stream.Close();
            };
          
            return new List<T>();
        }

    }
}
