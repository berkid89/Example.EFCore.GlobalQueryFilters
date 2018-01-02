using Microsoft.EntityFrameworkCore;

namespace Example.EFCore.GlobalQueryFilters.Models
{
    public class ExampleContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Task> Tasks { get; set; }

        private string connectionString { get; set; }

        public ExampleContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
