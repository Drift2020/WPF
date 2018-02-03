using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApplication1.Model
{
    [Serializable(), XmlInclude(typeof(Info))]
    public class Info
    {

        //public object Clone()
        //{
        //    return new Info(nfo, value, famelyStatys, adress, e_mail);
        //}

        string nfo;
        string value;
        string famelyStatys;
        string adress;
        string e_mail;

        bool [] checBox;



        public string Nfo
        {
            get { return nfo; }
            set { nfo = value; }
        }
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public string FamelyStatys
        {
            get { return famelyStatys; }
            set { famelyStatys = value; }
        }
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        public string E_mail
        {
            get { return e_mail; }
            set { e_mail = value; }
        }
        public bool [] ChecBox
        {
            get { return checBox; }
            set { checBox = value; }
        }

        public bool ChecBoxElement(int i)
        {

             return checBox[i]; 
           
        }
        public Info(string nfo, string value, string famelyStatys, string adress, string e_mail, bool[] checBox)
        {
            this.nfo = nfo;
            this.value = value;
            this.famelyStatys = famelyStatys;
            this.adress = adress;
            this.e_mail = e_mail;
            this.checBox = checBox;
        }
        // для XML-сериализации необходим конструктор по умолчанию
        public Info()
        {
            this.nfo = "";
            this.value = "";
            this.famelyStatys = "";
            this.adress = "";
            this.e_mail = "";
            this.checBox = new  bool[1];
        }

        public bool IsCorect()
        {
            return nfo != "" && value != "" && famelyStatys != "" && adress != "" && e_mail != "";

        }

    }
}
