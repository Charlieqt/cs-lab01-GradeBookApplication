using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do?");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command.StartsWith("create"))
                CreateCommand(command);
            else if (command.StartsWith("load"))
                LoadCommand(command);
            else if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        public static void CreateCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Create requires a name.");
                return;
            }
            var name = parts[1];
            BaseGradeBook gradeBook = new BaseGradeBook(name);
            Console.WriteLine("Created gradebook {0}.", name);
            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void LoadCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Load requires a name.");
                return;
            }
            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void HelpCommand()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("  create 'Name' 'Type' - Creates a new gradebook where 'Name' is the name of the gradebook and 'Type' is what type of grading it should use.");
            Console.WriteLine("  list                - Lists all of the gradebooks.");
            Console.WriteLine("  delete 'Name'       - Deletes the gradebook with the given name.");
            Console.WriteLine("  quit                - Quits the program.");
            Console.WriteLine("  help                - Displays this message.");
        }

        private static BaseGradeBook CreateCommand(string[] parts)
        {
            if (parts.Length != 3)
            {
                Console.WriteLine("Command not valid, Create requires a name and type of gradebook.");
                return null;
            }

            string name = parts[1];
            string type = parts[2].ToLower();

            if (type == "standard")
            {
                return new StandardGradeBook(name);
            }
            else if (type == "ranked")
            {
                return new RankedGradeBook(name);
            }
            else
            {
                Console.WriteLine($"{type} is not a supported type of gradebook, please try again.");
                return null;
            }
        }
    }
}
