using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_1
{
    class Program
    {
        PhoneBook phoneBook = new PhoneBook();

        static void Main(string[] args)
        {
            Program program = new Program();
            bool running = true;
            while (running)
            {
                showMenu();

                int menuOption;
                if (tryReadInteger(1, 4, out menuOption))
                {
                    switch (menuOption)
                    {
                        case 1:
                            program.addContact();
                            break;
                        case 2:
                            program.listContacts();
                            break;
                        case 3:
                            program.searchContact();
                            break;
                        case 4:
                            running = false;
                            Console.WriteLine("Bye!");
                            break;
                    }
                }

                Console.WriteLine();
            }
        }

        private void addContact()
        {
            Contact c = new Contact();
            Console.Write("Name: ");
            c.Name = Console.ReadLine();
            Console.Write("Phone: ");
            c.Phone = Console.ReadLine();
            phoneBook.AddFirst(c);
            Console.WriteLine("New contact added");
        }

        private void listContacts()
        {
            listContacts(phoneBook);
        }

        private static void listContacts(IEnumerable<Contact> contacts)
        {
            foreach(Contact c in contacts)
            {
                Console.WriteLine("name: {0}, phone: {1}", c.Name, c.Phone);
            }
        }

        private void searchContact()
        {
            Console.Write("Name: ");
            string searchTerm = Console.ReadLine();

            var found = phoneBook.Where(c => c.Name.Contains(searchTerm));
            listContacts(found);
        }

        private static bool tryReadInteger(int min, int max, out int value)
        {
            Console.Write("Choose (integer from {0} to {1}): ", min, max);
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out value) && value >= min && value <= max)
            {
                return true;
            }
            else
            {
                Console.WriteLine("invalid input");
                return false;
            }
        }

        private static void showMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add new contact");
            Console.WriteLine("2. List contacts");
            Console.WriteLine("3. Search contact");
            Console.WriteLine("4. Exit");
        }
    }
}
