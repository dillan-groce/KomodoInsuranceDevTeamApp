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
                "1. View all developers\n" +
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
                        GetListOfDevelopers();
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
        private void GetListOfDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetListOfDevelopers();
            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"Name: {developer.Name}, Email: {developer.Email}, Salary: {developer.Salary}, Employee ID: {developer.ID}");
            }
        }
        private void UpdateExistingDeveloperEntry()
        {

        }
        private void DeleteDeveloper()
        {

        }
        private void SeedDeveloperList()
        {
            Developer developerSeedOne = new Developer("John Doe", "john.doe@myemail.com", 65000, 0 /*DevTeam.TeamOne*/);
            Developer developerSeedTwo = new Developer("Janie Rains", "janie.rains@myemail.com", 69000, 1 /*DevTeam.TeamTwo*/);
            _developerRepo.AddDeveloperToList(developerSeedOne);
            _developerRepo.AddDeveloperToList(developerSeedTwo);
        }
    }
}
