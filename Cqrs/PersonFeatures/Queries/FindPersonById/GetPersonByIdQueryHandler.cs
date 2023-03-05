using Cqrs.Context;
using Cqrs.Model;
using MediatR;

namespace Cqrs.PersonFeatures.Queries.FindPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQueryModel, Person>
    {
        private readonly CqrsDbContext _context;
        public GetPersonByIdQueryHandler(CqrsDbContext context)
        {
            _context = context;
        }

        public async Task<Person> Handle(GetPersonByIdQueryModel request, CancellationToken cancellationToken)
        {
            var person = _context.Persons.Where(a => a.Id == request.Id).FirstOrDefault();
            if (person == null) return null;
            return person;
        }
    }
}
