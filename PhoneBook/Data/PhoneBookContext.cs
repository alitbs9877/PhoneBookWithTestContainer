using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.Models;

namespace PhoneBook.Data
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public PhoneBookContext()
        {
        }
        public PhoneBookContext(DbSet<Contact> contacts)
        {
            Contacts = contacts;
        }

        public PhoneBookContext(DbContextOptions contacts) : base(contacts)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23)) );
        }
    }
}
