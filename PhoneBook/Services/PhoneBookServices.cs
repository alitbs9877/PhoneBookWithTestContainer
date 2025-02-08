using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Data;
using PhoneBook.Models;
using System;
using System.Linq;

namespace PhoneBook.Services
{
    public class PhoneBookService
    {
        public void AddContact(string firstName, string lastName, string phoneNumber)
        {
            //TODO debug

            //TODO add contact by repeated contact
            using var context = new PhoneBookContext();
            var contact = new Contact { Id = Guid.NewGuid(), firstName = firstName, lastName = lastName, phoneNumber = phoneNumber };
            var existedContact = context.Contacts.FirstOrDefault(c => (c.firstName == firstName && c.lastName == lastName));
            if (existedContact != null && contact.Equals(existedContact))
            {

                Console.WriteLine("contact existed");
                return;
            }
            context.Contacts.Add(contact);
            context.SaveChanges();
            Console.WriteLine("contact added");
        }
        //TODO get  cintact by name  => Done
        public Contact GetContactByPhone(string phoneNumber)
        {
            using var context = new PhoneBookContext();
            return context.Contacts.FirstOrDefault(c => c.phoneNumber == phoneNumber);
        }

        public Contact GetContactByFullName(string firstName , string lastName)
        {
            using var context = new PhoneBookContext();
            return context.Contacts.FirstOrDefault(c => (c.firstName == firstName &&  c.lastName == lastName) );
        }
    }
}
