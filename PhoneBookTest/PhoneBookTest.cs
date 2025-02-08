using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace PhoneBookTest
{
    //TODO debug
    //TODO more check from toturials
    // TODO check get contact

    public class PhoneBookTests : IClassFixture<MySqlTestContainer>
    {
        private readonly MySqlTestContainer _container;
        private readonly PhoneBookContext _dbContext;

        public PhoneBookTests(MySqlTestContainer container)
        {
            _container = container;

            var options = new DbContextOptionsBuilder<PhoneBookContext>()
                .UseMySql(_container.MySqlContainer.GetConnectionString(),
                          new MySqlServerVersion(new Version(8, 0, 23)))
                .Options;

            _dbContext = new PhoneBookContext(options);
            _dbContext.Database.EnsureCreated();
        }

       // [Fact]
        [Theory]
        [InlineData("reza", "Rezaeian", "09129999999")]
        [InlineData("Ali", "Tabasi", "09369999999")]
        [InlineData("karim", "karimian", "09209999999")]
        public async Task CanInsertNewContact( string firstName , string lastName, string phoneNumber )
        {
            var contact = new Contact { Id = Guid.NewGuid(), firstName = firstName, lastName = lastName, phoneNumber = phoneNumber };
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();

            var savedContact = await _dbContext.Contacts.FindAsync(contact.Id);
            Assert.NotNull(savedContact);

            Assert.Equal(contact, savedContact);
        }
    }
}
