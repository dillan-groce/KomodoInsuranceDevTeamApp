using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo_ConsoleApp;
using static Komodo_ConsoleApp.Developer_Repo;

namespace Komodo_ConsoleApp
{
    public class ProgramUI
    {
        private Developer_Repo _developerRepo = new Developer_Repo();
        public void Run()
        {
            SeedDeveloperList();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                //Console.Clear();
                Console.WriteLine("Hello! Welcome to Komodo Insurance\n" +
                    "\n" +
                    "\n" +
                    "1. View Developers Menu\n" +
                    "2. View DevTeams Menu\n" +
                    "3. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //developersmenu
                        RunDevelopersMenu();
                        break;
                    case "2":
                        //devteamsmenu
                        break;
                    case "3":
                        Console.WriteLine("You have chosen to exit the program... Press any key to continue...");
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response.");
                        break;
                }
            }
        }
        public void RunDevelopersMenu()
        {
            Console.Clear();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("You have chosen to view the Developers menu.\n" +
                "\n" +
                "1. Search developers\n" +
                "2. Add a new developer\n" +
                "3. Update a developer's information\n" +
                "4. Delete a developer from the system\n" +
                "5. Main Menu\n" +
                "\n" +
                "Please enter a selection: ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SearchMenu();
                        break;
                    case "2":
                        AddDeveloperToList();
                        break;
                    case "3":
                        UpdateExistingDeveloperEntry();
                        break;
                    case "4":
                        DeleteDeveloper();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Back to the main menu we go!\n");
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response.");
                        break;
                }
            }
            Console.Clear();
        }
        private void AddDeveloperToList()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();
            Console.WriteLine("Please enter the Developer's name:");
            newDeveloper.Name = Console.ReadLine();
            Console.WriteLine("Please enter the Developer's email address:");
            newDeveloper.Email = Console.ReadLine();
            Console.WriteLine("Please enter the Developer's ID #:");
            string idAsString = Console.ReadLine();
            newDeveloper.ID = int.Parse(idAsString);
            Console.WriteLine("Please enter the Developer's Salary:");
            string salaryAsString = Console.ReadLine();
            newDeveloper.Salary = int.Parse(salaryAsString);
            _developerRepo.AddDeveloperToList(newDeveloper);
        }
        private void SearchMenu()
        {
            Console.Clear();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Search\n" +
                    "\n" +
                    "1. View all developers\n" +
                    "2. Search by name\n" +
                    "3. Search by ID");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        GetListOfDevelopers();
                        break;
                    case "2":
                        SearchDevelopersByName();
                        break;
                    case "3":
                        SearchDevelopersByID();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
            }
        }
        private void GetListOfDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetListOfDevelopers();
            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.Name}, Email: {developer.Email}, Salary: {developer.Salary}, Employee ID: {developer.ID}, Team: {developer.DevelopersTeam}");
            }
        }
        private void SearchDevelopersByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the Developer you're searching for:");
            string name = Console.ReadLine();
            Developer developer = _developerRepo.SearchDevelopersByName(name);
            if(developer != null)
            {
                Console.WriteLine($"Name: {developer.Name}, Email: {developer.Email}, Salary: {developer.Salary}, Employee ID: {developer.ID}, Team: {developer.DevelopersTeam}");
            }
            else
            {
                Console.WriteLine("No developer by that name in our system.");
            }
        }
        private void SearchDevelopersByID()
        {
            Console.Clear();
            Console.WriteLine("Please enter an ID number:");
            string userInput = Console.ReadLine();
            int userInputAsInt = int.Parse(userInput);
            Developer developer = _developerRepo.SearchDevelopersByID(userInputAsInt);
            if(developer != null)
            {
                Console.WriteLine($"Name: {developer.Name}, Email: {developer.Email}, Salary: {developer.Salary}, Employee ID: {developer.ID}, Team: {developer.DevelopersTeam}");
            }
            else
            {
                Console.WriteLine("Please enter a valid ID.");
            }
        }
        private void UpdateExistingDeveloperEntry()
        {
            GetListOfDevelopers();
            Console.WriteLine("Enter the ID of the developer you'd like to update:");
            string oldInfo = Console.ReadLine();
            int oldInfoAsInt = int.Parse(oldInfo);

            Developer newDeveloper = new Developer();
            Console.WriteLine("Please enter the Developer's name:");
            newDeveloper.Name = Console.ReadLine();
            Console.WriteLine("Please enter the Developer's email address:");
            newDeveloper.Email = Console.ReadLine();
            Console.WriteLine("Please enter the Developer's ID #:");
            string idAsString = Console.ReadLine();
            newDeveloper.ID = int.Parse(idAsString);
            Console.WriteLine("Please enter the Developer's Salary:");
            string salaryAsString = Console.ReadLine();
            newDeveloper.Salary = int.Parse(salaryAsString);

            bool wasUpdated = _developerRepo.UpdateExistingDeveloperEntry(oldInfo, newDeveloper);
            if(wasUpdated)
            {
                Console.WriteLine("Information has been updated.");
            }
            else
            {
                Console.WriteLine("Information could not be updated.");
            }
        }
        private void DeleteDeveloper()
        {
            GetListOfDevelopers();
            Console.WriteLine("Enter the name of the Developer you'd like to delete.");
            string userInput = Console.ReadLine();
            bool wasDeleted = _developerRepo.DeleteDeveloper(userInput);
            if (wasDeleted)
            {
                Console.WriteLine("Developer successfully deleted.");
            }
            else
            {
                Console.WriteLine("Developer could not be deleted.");
            }
        }
        private void SeedDeveloperList()
        {
            Developer developerSeedOne = new Developer("John Doe", "john.doe@myemail.com", 65000, 0, Team.TeamOne);
            Developer developerSeedTwo = new Developer("Janie Rains", "janie.rains@myemail.com", 69000, 1, Team.TeamTwo);
            Developer developerSeedThree = new Developer("Dillan Groce", "dillan.groce@myemail.com", 58000, 2, Team.TeamThree);
            Developer developerSeedFour = new Developer("Janie Rains", "janie.rains@myemail.com", 69000, 3, Team.TeamFour);
            Developer developerSeedFive = new Developer("Severa Cox", "severa.cox@myemail.com", 100000, 4, Team.TeamFive);
            Developer developerSeedSix = new Developer("Erick Forson", "erick.forson@myemail.com", 100000, 5, Team.TeamOne);
            Developer developerSeedSeven = new Developer("Austin Hooker", "austin.hooker@myemail.com", 90000, 6, Team.TeamTwo);
            Developer developerSeedEight = new Developer("Sean Dwyer", "sean.dwyer@myemail.com", 90000, 7, Team.TeamThree);
            Developer developerSeedNine = new Developer("Michael deJong", "michael.deJong@myemail.com", 69000, 8, Team.TeamFour);
            Developer developerSeedTen = new Developer("Brandon Murphy", "brandon.murphy@myemail.com", 69000, 9, Team.TeamFive);

            _developerRepo.AddDeveloperToList(developerSeedOne);
            _developerRepo.AddDeveloperToList(developerSeedTwo);
            _developerRepo.AddDeveloperToList(developerSeedThree);
            _developerRepo.AddDeveloperToList(developerSeedFour);
            _developerRepo.AddDeveloperToList(developerSeedFive);
            _developerRepo.AddDeveloperToList(developerSeedSix);
            _developerRepo.AddDeveloperToList(developerSeedSeven);
            _developerRepo.AddDeveloperToList(developerSeedEight);
            _developerRepo.AddDeveloperToList(developerSeedNine);
            _developerRepo.AddDeveloperToList(developerSeedTen);
        }
    }
}
