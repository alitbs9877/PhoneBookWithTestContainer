using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;
using Testcontainers.MySql;
//TODO debug
//using Testcontainers.Builders;
//using Testcontainers.Containers;
using Xunit;


namespace PhoneBookTest
{
    //TODO more check from toturials
    public class MySqlTestContainer : IAsyncLifetime
    {
        public MySqlContainer MySqlContainer { get; private set; }

        public async Task InitializeAsync()
        {
            //TODO debug

            //MySqlContainer = new ContainerBuilder<MySqlContainer>()
            //    .ConfigureDatabaseConfiguration("root", "testdb", "password")
            //    .Build();

            MySqlContainer = new MySqlBuilder()
            .WithImage("mysql:latest")
            .WithDatabase("testdb")
            .WithUsername("testuser")
            .WithPassword("testpassword")
            .Build();

            await MySqlContainer.StartAsync();
        }

        public async Task DisposeAsync()
        {
            await MySqlContainer.StopAsync();
        }
    }
}
