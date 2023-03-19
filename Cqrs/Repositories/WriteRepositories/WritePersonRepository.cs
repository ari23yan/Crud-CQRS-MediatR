using Cqrs.Context;
using Cqrs.Model;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Repositories.WriteRepositories
{
    public class WritePersonRepository
    {
        private readonly CqrsDbContext _db;
        public WritePersonRepository( CqrsDbContext cqrsDb)
        {
            _db = cqrsDb;
        }
        public async Task AddMovieAsync(Person person, CancellationToken cancellationToken = default)
        {
            await _db.Persons.AddAsync(person, cancellationToken);
        }

        public  Task<Person> GetMovieByIdAsync(Guid personId, CancellationToken cancellationToken = default)
        {
             return  _db.Persons.FirstOrDefaultAsync(c => c.Id == personId, cancellationToken);
        }

        public void DeleteMovie(Person person)
        {
            _db.Persons.Remove(person);
        }
    }
}
