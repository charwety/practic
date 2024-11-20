using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic
{
    public class Reader
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Reader(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        public override string ToString()
        {
            return $"{Id}: {Name} ({Email})";
        }
    }
}
