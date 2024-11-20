using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace practic
{
    public class Reader
    {
        public string Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Reader(string name, string email, string id = null)
        {

            Name = name;
            Email = email;
        }


        public override string ToString()
        {
            return $"Имя: {Name}, Email: {Email}";
        }
    }
}
