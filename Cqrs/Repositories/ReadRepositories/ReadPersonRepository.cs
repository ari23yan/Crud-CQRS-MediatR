using Cqrs.Model;
using Cqrs.ReadRepositories.Common;
using MongoDB.Driver;

namespace Cqrs.ReadRepositories
{
    public class ReadPersonRepository : BaseReadRepository<Person>
    {
        public ReadPersonRepository(IMongoDatabase db) : base(db)
        {
        }
            public Task<Person> GetByPersonIdAsync(Guid personId, CancellationToken cancellationToken = default)
            {
                return base.FirstOrDefaultAsync(person => person.Id == personId, cancellationToken);
            }

            public Task<Person> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
            {
                return base.FirstOrDefaultAsync(person => person.Email == email, cancellationToken);
            }

            public Task DeleteByPersonIdAsync(Guid personId, CancellationToken cancellationToken = default)
            {
                return base.DeleteAsync(m => m.Id == personId, cancellationToken);
            }
        }
    }
