using Cqrs.Context;
using Cqrs.Model;
using Cqrs.ReadRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.PersonFeatures.Queries.GetPersonList
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonQueryModel, IEnumerable<Person>>
    {
        private readonly ReadPersonRepository _readPerson;

        public GetAllPersonsQueryHandler(ReadPersonRepository readPerson)
        {
            _readPerson = readPerson;
        }
        public async Task<IEnumerable<Person>> Handle(GetAllPersonQueryModel request, CancellationToken cancellationToken)
        {
            //var personList = await _context.Persons.ToListAsync();
            var personList = await _readPerson.GetAllAsync();
            if (personList == null)
            {
                return null;
            }
            return personList.AsReadOnly();
        }
    }
}
