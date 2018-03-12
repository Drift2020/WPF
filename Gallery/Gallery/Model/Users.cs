using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gallery
{
    [Serializable(), XmlInclude(typeof(Users))]
    public class Users : ICloneable
    {
        public object Clone()
        {
            return new Users(login, password, name, surname);
        }

        public Users(string _name, string _surname, string _login, string _password)
        {
            name = _name;
            surname = _surname;
            login = _login;
            password = _password;

        }

        public Users()
        {
            name = "";
            surname = "";
            login = "";
            password = "";

        }


        public string name { get; set; }
        public string surname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
