using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; 

namespace LibraryApp
{
    class LibraryApp
    {
        static void Main(string[] args)
        {
            char anotherBook = 'N';     
            string authorName;
            string title;
            int ID;
            int days;
            char checkin;
            DisplayInstructions();

            do // include the check-in here and else for check-out 
            {
                //Ask if cusomter is checking-in Y or N, then if Y or y then do the following GetInputs 
                Clear();
                Write("\n Are you checking-in?");
                Write(" (Enter Y for Yes, and N for No) ");
                checkin = char.Parse(ReadLine());
                if (checkin == 'Y' || checkin == 'y')
                    Console.WriteLine("");
                GetInputs(out authorName, out title, out ID, out days, checkin);
                Library libraryObject = new Library(authorName, title, ID, days, checkin);
                WriteLine();
                libraryObject.YourFullName = AskFor("full name");
                libraryObject.YourAddress = AskFor("address");
                libraryObject.YourPhone = AskFor("phone number");
                Clear();
                WriteLine();
                WriteLine(libraryObject);            
                Write("\n\n Would you like to check out or check in another book? (Y or N) ");
                string inValue = ReadLine();
                anotherBook = Convert.ToChar(inValue);
            }
            while ((anotherBook == 'Y') || (anotherBook == 'y')); // loop will continue to run 'till the user press N for No
        }

        // Ask user to input information for book
        static void GetInputs(out string authorName, out string title, out int ID, out int days, char checkin)
        {
            Clear();
            authorName = AskForAuthorName(); 
            title = AskForTitle();
            ID = AskForBookID();

            if ((checkin == 'Y') || (checkin == 'y')) 
                days = AskForDays();
            else
                days = 0;

        }

        public static void DisplayInstructions() // 1st output to the screen 
        {
            Console.WriteLine("\n \t \t This application will guide you through the book checkin and checkout process at our library.");
            Console.WriteLine("\n Please enter the corresponding answers to the fields below in order to check in/out a book.");
            Console.WriteLine("\n 1. Are you checking in or checking out?");
            Console.WriteLine("\n 2. What is the name of the author (Please enter the full name): ");
            Console.WriteLine("\n 3. What is the title of the book that you want to check out/in today? ");
            Console.WriteLine("\n 4. What is book ID you're searching for? ");
            Console.WriteLine("\n 5. Please tell us your full name: ");
            Console.WriteLine("\n 6. What is your address: ");
            Console.WriteLine("\n 7. What is your contact number: ");
            Console.WriteLine("\n 8. How many days ");
            Console.ReadLine();            
        }
        
        public static string AskForAuthorName()
        {
            string inValue;
            string authorName;
            Console.WriteLine("\n What is the name of the author (Please enter the full name): ");
            inValue = Console.ReadLine();
            authorName = (string)inValue;
            return authorName;
        }
        public static string AskForTitle()
        {
            string inValue;
            Console.WriteLine("\n What is the title of the book that you want to check out today? ");
            inValue = Console.ReadLine();
            return inValue; 
        }

        public static string AskFor(string yourInfo)
        {
            string inValue;
            Console.WriteLine("\n What is your {0}: ", yourInfo);
            inValue = Console.ReadLine();
            return inValue;
        }
        public static int AskForBookID()
        {
            string inValue;
            int ID;
            Console.WriteLine("\n What is the book ID? ");
            inValue = Console.ReadLine();
            ID = int.Parse(inValue);
            return ID;

        }
        public static int AskForDays()
        {
            string inValue;
            int days;
            Console.WriteLine("\n How long has it been since checked out (in days): ");
            inValue = Console.ReadLine();
            days = int.Parse(inValue);
            return days;
        }



    }
}
