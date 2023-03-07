using Cqrs.Model;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Context
{
    public class CqrsDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public CqrsDbContext(DbContextOptions<CqrsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().OwnsOne(c => c.Addres);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
