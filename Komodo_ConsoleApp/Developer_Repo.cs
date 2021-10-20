using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_ConsoleApp
{
    public class Developer_Repo
    {
        //this should host CRUD methods for the DEVELOPERS
        private readonly List<Developer> _developerList = new List<Developer>();
        //CREATE
        public void AddDeveloperToList(Developer developer)
        {
            _developerList.Add(developer);
        }
        //READ
        public List<Developer> GetListOfDevelopers()
        {
            return _developerList;
        }
        public Developer GetDeveloperByName(string name)
        {
            foreach (Developer developer in _developerList)
            {
                if (developer.Name.ToLower() == name.ToLower())
                {
                    return developer;
                }
            }
            return null;
        }
        //UPDATE
        public void UpdateExistingDeveloperEntry(string originalEntry, Developer newEntry)
        {
            Developer oldEntry = GetDeveloperByName(originalEntry);
            if (oldEntry != null)
            {
                oldEntry.Name = newEntry.Name;
                oldEntry.Email = newEntry.Email;
                oldEntry.ID = newEntry.ID;
                oldEntry.Salary = newEntry.Salary;
            }
        }
        //DELETE
        public bool DeleteDeveloper(string developerName)
        {
            Developer developer = GetDeveloperByName(developerName);
            if(developer == null)
            {
                return false;
            }
            int initialCount = _developerList.Count;
            _developerList.Remove(developer);
            if (initialCount > _developerList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
