using Microsoft.EntityFrameworkCore;
using Project0.DataAccess;
using Project0.Interface.View.Menu;
using System;

namespace Project0.Interface
{
    public class Program
    {
        static DbContextOptions<Project0Context> options = null;

        static void Main(string[] args)
        {
            ConfigDatabase();
            MainMenu.ShowMainMenu();
        }

        private static void ConfigDatabase()
        {
            var connectionString = SecretDatabaseAccess.SecretString;

            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(connectionString);
            options = optionsBuilder.Options;
        }
    }
}
