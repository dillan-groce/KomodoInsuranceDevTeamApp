using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_ConsoleApp
{
    public class Developer_Repo
    {
        private readonly List<Developer> _developerList = new List<Developer>();
        public bool AddDeveloperToList(Developer developer)
        {
            int initialCountOfDevelopers = _developerList.Count();
            _developerList.Add(developer);

            if (_developerList.Count > initialCountOfDevelopers)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Developer> GetListOfDevelopers()
        {
            return _developerList;
        }
        public Developer SearchDevelopersByName(string name)
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
        public Developer SearchDevelopersByID(int id)
        {
            foreach (Developer developer in _developerList)
            {
                if (developer.ID == id)
                {
                    return developer;
                }
            }
            return null;
        }
        public bool UpdateExistingDeveloperEntry(Developer originalEntry, Developer newEntry)
        {
            if (originalEntry != null)
            {
                originalEntry.Name = newEntry.Name;
                originalEntry.Email = newEntry.Email;
                originalEntry.ID = newEntry.ID;
                originalEntry.Salary = newEntry.Salary;
                originalEntry.HasAccessToPluralsight = newEntry.HasAccessToPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDeveloper(string developerName)
        {
            Developer developer = SearchDevelopersByName(developerName);
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
