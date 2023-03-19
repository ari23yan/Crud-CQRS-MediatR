using Cqrs.Context;
using Cqrs.Model;
using Cqrs.ReadRepositories;
using MediatR;

namespace Cqrs.PersonFeatures.Queries.FindPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQueryModel, Person>
    {
        //private readonly CqrsDbContext _context;
        private readonly ReadPersonRepository _readPerson;
        public GetPersonByIdQueryHandler(ReadPersonRepository readPerson)
        {
            _readPerson = readPerson;
        }

        public async Task<Person> Handle(GetPersonByIdQueryModel request, CancellationToken cancellationToken)
        {
            //var person = _context.Persons.Where(a => a.Id == request.Id).FirstOrDefault();
            var person =  await _readPerson.GetByPersonIdAsync(request.Id);
            if (person == null) return null;
            return person;
        }
    }
}
