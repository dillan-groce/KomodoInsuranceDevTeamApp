using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_ConsoleApp
{
    
    public class Developer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public int ID { get; set; }
        public bool HasAccessToPluralsight { get; set; }

        public Developer() { }
        public Developer(string name, string email, int salary, int id, bool hasAccess )
        {
            Name = name;
            Email = email;
            Salary = salary;
            ID = id;
            HasAccessToPluralsight = hasAccess;
        }

    }
}
