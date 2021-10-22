using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komodo_ConsoleApp;
using static Komodo_ConsoleApp.Developer_Repo;
using static Komodo_ConsoleApp.DevTeam_Repo;

namespace Komodo_ConsoleApp
{
    public class ProgramUI
    {
        private Developer_Repo _developerRepo = new Developer_Repo();
        private DevTeam_Repo _devTeamRepo = new DevTeam_Repo();
        public void Run()
        {
            SeedContent();
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
                        RunDevelopersMenu();
                        break;
                    case "2":
                        RunDevTeamsMenu();
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
            Console.WriteLine("Does this developer have a Pluralsight license? Please enter (yes) or (no).");
            string hasLicense = Console.ReadLine().ToLower();
            if (hasLicense == "yes")
            {
                newDeveloper.HasAccessToPluralsight = true;
            }
            else
            {
                newDeveloper.HasAccessToPluralsight = false;
            }
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
                    "3. Search by ID\n" +
                    "4. Main Menu");
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
                    case "4":
                        RunMenu();
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
            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"EmployeeID: {developer.ID}, \nName: {developer.Name}, \nHas Access To Pluralsight: {developer.HasAccessToPluralsight}\n");
            }
        }
        private void SearchDevelopersByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the Developer you're searching for:");
            string name = Console.ReadLine();
            Developer developer = _developerRepo.SearchDevelopersByName(name);
            if (developer != null)
            {
                Console.WriteLine($"Name: {developer.Name}, Email: {developer.Email}, Salary: {developer.Salary}, Employee ID: {developer.ID}");
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
            if (developer != null)
            {
                Console.WriteLine($"Name: {developer.Name}, Email: {developer.Email}, Salary: {developer.Salary}, Employee ID: {developer.ID}");
            }
            else
            {
                Console.WriteLine("Please enter a valid ID.");
            }
        }
        private void UpdateExistingDeveloperEntry()
        {
            Developer newDeveloper = new Developer();
            Console.Clear();
            GetListOfDevelopers();
            Console.WriteLine("\nEnter the ID of the developer you'd like to update:");
            int originalID = Convert.ToInt32(Console.ReadLine());
            Developer originalInfo = _developerRepo.SearchDevelopersByID(originalID);
            Console.WriteLine("\nPlease enter the Developer's name:");
            newDeveloper.Name = Console.ReadLine();
            Console.WriteLine("\nPlease enter the Developer's email address:");
            newDeveloper.Email = Console.ReadLine();
            Console.WriteLine("\nPlease enter the Developer's ID #:");
            string idAsString = Console.ReadLine();
            newDeveloper.ID = int.Parse(idAsString);
            Console.WriteLine("\nPlease enter the Developer's Salary:");
            string salaryAsString = Console.ReadLine();
            newDeveloper.Salary = int.Parse(salaryAsString);
            Console.WriteLine("Does this developer have a Pluralsight license? Please enter (yes) or (no).");
            string hasLicense = Console.ReadLine().ToLower();
            if (hasLicense == "yes")
            {
                newDeveloper.HasAccessToPluralsight = true;
            }
            else
            {
                newDeveloper.HasAccessToPluralsight = false;
            }
            _developerRepo.UpdateExistingDeveloperEntry(originalInfo, newDeveloper);
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
        private void SeedContent()
        {
            Developer developerSeedOne = new Developer("John Doe", "john.doe@myemail.com", 65000, 0, true);
            Developer developerSeedTwo = new Developer("Janie Rains", "janie.rains@myemail.com", 69000, 1, false);
            Developer developerSeedThree = new Developer("Dillan Groce", "dillan.groce@myemail.com", 58000, 2, true);
            Developer developerSeedFour = new Developer("Janie Rains", "janie.rains@myemail.com", 69000, 3, true);
            Developer developerSeedFive = new Developer("Severa Cox", "severa.cox@myemail.com", 100000, 4, true);
            Developer developerSeedSix = new Developer("Erick Forson", "erick.forson@myemail.com", 100000, 5, false);
            Developer developerSeedSeven = new Developer("Austin Hooker", "austin.hooker@myemail.com", 90000, 6, false);
            Developer developerSeedEight = new Developer("Sean Dwyer", "sean.dwyer@myemail.com", 90000, 7, true);
            Developer developerSeedNine = new Developer("Michael deJong", "michael.deJong@myemail.com", 69000, 8, true);
            Developer developerSeedTen = new Developer("Brandon Murphy", "brandon.murphy@myemail.com", 69000, 9, true);

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

            List<Developer> teamOne = new List<Developer>();
            teamOne.Add(developerSeedOne);
            teamOne.Add(developerSeedSix);

            List<Developer> teamTwo = new List<Developer>();
            teamTwo.Add(developerSeedTwo);
            teamTwo.Add(developerSeedSeven);

            List<Developer> teamThree = new List<Developer>();
            teamThree.Add(developerSeedThree);
            teamThree.Add(developerSeedEight);

            List<Developer> teamFour = new List<Developer>();
            teamFour.Add(developerSeedFour);
            teamFour.Add(developerSeedNine);

            List<Developer> teamFive = new List<Developer>();
            teamFive.Add(developerSeedFive);
            teamFive.Add(developerSeedTen);

            DevTeam devTeamOne = new DevTeam("Team One", 1, teamOne);
            DevTeam devTeamTwo = new DevTeam("Team Two", 2, teamTwo);
            DevTeam devTeamThree = new DevTeam("Team Three", 3, teamThree);
            DevTeam devTeamFour = new DevTeam("Team Four", 4, teamFour);
            DevTeam devTeamFive = new DevTeam("Team Five", 5, teamFive);

            _devTeamRepo.AddDevTeamToList(devTeamOne);
            _devTeamRepo.AddDevTeamToList(devTeamTwo);
            _devTeamRepo.AddDevTeamToList(devTeamThree);
            _devTeamRepo.AddDevTeamToList(devTeamFour);
            _devTeamRepo.AddDevTeamToList(devTeamFive);
        }
        public void RunDevTeamsMenu()
        {
            Console.Clear();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("You have chosen to view the DevTEAMS menu.\n" +
                "\n" +
                "1. Search DevTeams\n" +
                "2. Add a new DevTeam\n" +
                "3. Update a DevTeam\n" +
                "4. Delete a DevTeam from the system\n" +
                "5. Add developer to DevTeam\n" +
                "6. Main Menu\n" +
                "\n" +
                "Please enter a selection: ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SearchDevTeamsMenu();
                        break;
                    case "2":
                        AddDevTeamToList();
                        break;
                    case "3":
                        UpdateDevTeam();
                        break;
                    case "4":
                        DeleteDevTeam();
                        break;
                    case "5":
                        AddDevToDevTeam();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Press any key to return to the Main Menu.\n");
                        Console.ReadLine();
                        continueToRun = false;
                        RunMenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response.");
                        break;
                }
            }
        }
        private void AddDevTeamToList()
        {
            DevTeam newDevTeam = new DevTeam();
            Console.WriteLine("Please enter a name for your new DevTeam:");
            string devTeamName = Console.ReadLine();
            Console.WriteLine("Enter the team ID:");
            string devTeamIDAsString = Console.ReadLine();
            int devTeamIDAsInt = Convert.ToInt32(devTeamIDAsString);
            newDevTeam.DevTeamId = CheckDeveloperID(devTeamIDAsInt);
            newDevTeam.DevTeamName = devTeamName;
            newDevTeam.DevTeamId = devTeamIDAsInt;
            bool wasCreated = _devTeamRepo.AddDevTeamToList(newDevTeam);
            if (wasCreated == true)
            {
                Console.WriteLine("The DevTeam has been added.\n" +
                    "Press any key to return to the menu.");
                Console.ReadLine();
                RunDevTeamsMenu();
            }
            else
            {
                Console.WriteLine("Sorry, but the DevTeam could not be added.\n" +
                    "Press any key to return to the menu.");
                Console.ReadLine();
                RunDevTeamsMenu();
            }
        }
        private void SearchDevTeamsMenu()
        {
            Console.Clear();
            Console.WriteLine("Dev Teams Menu\n" +
                "\n" +
                "1. Display all DevTeams\n" +
                "2. View a DevTeam\n" +
                "\n" +
                "Please enter your selection:");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    DisplayAllDevTeams();
                    break;
                case "2":
                    DisplayIndividualTeam();
                    break;
                default:
                    Console.WriteLine("Please enter a valid response.");
                    break;
            }
        }
        private void DisplayAllDevTeams()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _devTeamRepo.GetDevTeams();
            foreach (DevTeam devTeam in listOfDevTeams)
            {
                Console.WriteLine($"DevTeam ID: {devTeam.DevTeamId}\n" +
                    $"DevTeam Name: {devTeam.DevTeamName}\n");
                foreach (Developer developer in devTeam.DevTeamMembers)
                {
                    Console.WriteLine($"Developer: {developer.Name}\n" +
                        $"ID: {developer.ID}");
                }
                Console.ReadLine();
            }
        }
        private void DisplayIndividualTeam()
        {
            Console.Clear();
            List<DevTeam> listIndividualTeam = _devTeamRepo.GetDevTeams();
            foreach (DevTeam devTeam in listIndividualTeam)
            {
                Console.WriteLine($"\nDevTeam Name: {devTeam.DevTeamName}\n" + $" ID: {devTeam.DevTeamId}");
            }
        }
        private void UpdateDevTeam()
        {
            DevTeam updatedTeam = new DevTeam();
            Console.Clear();
            DisplayIndividualTeam();
            Console.WriteLine("Enter the DevTeam ID of the team you'd like to update:");
            int originalDevTeamID = Convert.ToInt32(Console.ReadLine());
            DevTeam oldDevTeam = _devTeamRepo.GetDevTeamId(originalDevTeamID);
            Console.WriteLine("Please enter the new team ID for {0}", oldDevTeam.DevTeamName);
            updatedTeam.DevTeamId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the new name for team ID {0}", updatedTeam.DevTeamId);
            updatedTeam.DevTeamMembers = oldDevTeam.DevTeamMembers;
            _devTeamRepo.UpdateDevTeams(oldDevTeam, updatedTeam);
        }
        private void DeleteDevTeam()
        {
            Console.Clear();
            List<DevTeam> removeDevTeam = _devTeamRepo.GetDevTeams();
            DisplayIndividualTeam();
            Console.WriteLine("Enter the ID of the DevTeam you'd like you delete.");
            string teamToBeRemoved = Console.ReadLine();
            int teamToBeRemovedAsInt = Convert.ToInt32(teamToBeRemoved);
            bool wasDeleted = _devTeamRepo.RemoveDevTeamFromList(teamToBeRemovedAsInt);
            if (wasDeleted)
            {
                Console.WriteLine("\nThe team has been deleted. Press any key to return to the menu.");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nTeam {0} could not be deleted at this time. Press any key to return to the menu.", teamToBeRemoved);
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void DisplayDevsAndDevTeams()
        {
            List<Developer> displayDevs = _developerRepo.GetListOfDevelopers();
            List<DevTeam> displayDevTeams = _devTeamRepo.GetDevTeams();

            foreach (Developer developer in displayDevs)
            {
                Console.WriteLine($"\nDeveloper Name: {developer.Name}" +
                    $"\nDeveloper ID#: {developer.ID}");
            }

            foreach (DevTeam devTeam in displayDevTeams)
            {
                Console.WriteLine($"\nDevTeam Name: {devTeam.DevTeamName}" +
                $"\nDevTeam ID Number: {devTeam.DevTeamId}");

            }
        }
        private void AddDevToDevTeam()
        {
            Console.Clear();
            DisplayDevsAndDevTeams();
            List<Developer> developers = _developerRepo.GetListOfDevelopers();
            List<DevTeam> devTeams = _devTeamRepo.GetDevTeams();
            Console.WriteLine("Please enter the Developer's ID Number:");
            string userInput = Console.ReadLine();
            int userInputAsInt = Convert.ToInt32(userInput);
            Console.WriteLine("Please enter the DevTeam number to assign the Developer to:");
            string devTeam = Console.ReadLine();
            int devTeamInt = Convert.ToInt32(devTeam);
            DevTeam checkIDFirst = _devTeamRepo.GetDevTeamId(userInputAsInt);
            foreach (DevTeam devTeamID in devTeams)
            {
                if (userInputAsInt <= 30)
                {
                    if (checkIDFirst != null)
                    {
                        Console.WriteLine("Developer added to {0}", userInputAsInt);
                        _devTeamRepo.AddDevToDevTeam(userInputAsInt);
                    }
                    else
                    {
                        Console.WriteLine("ID {0} is not active.", userInputAsInt);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid ID#.");
                }
            }
        }
        public int CheckDeveloperID(int idCheck)
        {
            if (idCheck <= 30)
            {
                return idCheck;
            }
            else
            {
                Console.WriteLine("\nPlease ReEnter the Developer's ID:\n");
                string devIdAsString = Console.ReadLine();
                idCheck = Convert.ToInt32(devIdAsString);
                return idCheck;
            }
        }
    }
}
