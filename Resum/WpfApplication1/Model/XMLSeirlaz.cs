﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApplication1.Model
{
    class XMLSerializer : ISerializer
    {
        FileStream stream = null;
        XmlSerializer serializer = null;
        public void Save(ICollection<Info> collection)
        {

            stream = new FileStream("../../list.xml", FileMode.Create);
            serializer = new XmlSerializer(typeof(List<Info>));
            serializer.Serialize(stream, collection);
            stream.Close();
           
        }
        public ICollection<Info> Load()
        {
            List<Info> temp;
            try
            {
                stream = new FileStream("../../list.xml", FileMode.Open);
                serializer = new XmlSerializer(typeof(List<Info>));
                temp = (List<Info>)serializer.Deserialize(stream);


                stream.Close();

                return temp;
            }
            catch (Exception ex) { };
          
            return new List<Info>();
        }

    }
}
