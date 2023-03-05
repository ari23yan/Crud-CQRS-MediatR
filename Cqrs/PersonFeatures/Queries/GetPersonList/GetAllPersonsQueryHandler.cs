using Cqrs.Context;
using Cqrs.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.PersonFeatures.Queries.GetPersonList
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonQueryModel, IEnumerable<Person>>
    {
        private readonly CqrsDbContext _context;
        public GetAllPersonsQueryHandler(CqrsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> Handle(GetAllPersonQueryModel request, CancellationToken cancellationToken)
        {
            var personList = await _context.Persons.ToListAsync();
            if (personList == null)
            {
                return null;
            }
            return personList.AsReadOnly();
        }
    }
}
