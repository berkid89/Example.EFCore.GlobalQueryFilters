using Example.EFCore.GlobalQueryFilters.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Example.EFCore.GlobalQueryFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            using (var db = new ExampleContext(config["ConnectionString"]))
            {
                var aceWithActiveTasks = db.Students.Include("Tasks")
                    .FirstOrDefault(p => p.Name == "Ace");

                Console.WriteLine("\nAce's ACTIVE tasks:");

                foreach (var task in aceWithActiveTasks.Tasks)
                {
                    Console.WriteLine(task.Title);
                }

                var aceWithAllTasks = db.Students.Include("Tasks")
                    .IgnoreQueryFilters() //Disable global query filters
                    .FirstOrDefault(p => p.Name == "Ace");

                Console.WriteLine("\nAce's ALL tasks:");

                foreach (var task in aceWithAllTasks.Tasks)
                {
                    Console.WriteLine(task.Title);
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
