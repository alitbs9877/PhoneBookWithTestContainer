using System;
using PhoneBook.Services;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PhoneBookService();

            while (true)
            {
                Console.WriteLine("add contact -> press 1");
                Console.WriteLine("search contact by number -> press 2");
                Console.WriteLine("search contact by first_name and last_name -> press 3");
                Console.WriteLine("exit -> press q");
                Console.Write(" : ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write(" first name : ");
                        string firstName = Console.ReadLine();
                        Console.Write("last name :");
                        string lastName = Console.ReadLine();
                        Console.Write("phone number :");
                        string phoneNumber = Console.ReadLine();

                        service.AddContact(firstName, lastName, phoneNumber);
                        break;

                    case "2":
                        Console.Write("phone number :");
                        string searchPhone = Console.ReadLine();
                        var contact = service.GetContactByPhone(searchPhone);
                        if (contact != null)
                        {
                            Console.WriteLine($"name : {contact.firstName},last name :{contact.lastName},phone number : {contact.phoneNumber}");
                        }
                        else
                        {
                            Console.WriteLine("not existed");
                        }
                        break;

                    case "3":
                        Console.Write("name : ");
                        string searchFirstName = Console.ReadLine();
                        Console.Write("last name :");
                        string searchLastName = Console.ReadLine();
                        contact = service.GetContactByFullName(searchFirstName, searchLastName);
                        if (contact != null)
                        {
                            Console.WriteLine($"name : {contact.firstName},last name :{contact.lastName},phone number : {contact.phoneNumber}");
                        }
                        else
                        {
                            Console.WriteLine("not existed");
                        }
                        return;

                    case "q":
                        Console.WriteLine("dar panah hagh <('''') ");
                        return;

                    default:
                        Console.WriteLine("invalid");
                        break;
                }
            }
        }
    }

}