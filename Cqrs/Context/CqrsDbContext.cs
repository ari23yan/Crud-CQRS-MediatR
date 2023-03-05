using Cqrs.Model;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Context
{
    public class CqrsDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public CqrsDbContext(DbContextOptions<CqrsDbContext> options)
            : base(options) { }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
