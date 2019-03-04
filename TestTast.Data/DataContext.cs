using Microsoft.EntityFrameworkCore;
using TestTask.Common.Abstract;
using TestTask.Common.Entities;

namespace TestTast.Data
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext(DbContextOptions option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(c => c.Id);

        }
        public void EnsureCreated()
        {
            Database.EnsureCreated();
        }

    }
}
