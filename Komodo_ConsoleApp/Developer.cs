using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_ConsoleApp
{
    
    public class Developer
    {
        //this should host the POCOs for the DEVELOPERS
        /*Developers have names and ID numbers; we need to be able to identify one developer without mistaking them for another. We also need to know whether or not they have access to the online learning tool: Pluralsight.*/
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
