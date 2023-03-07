using AutoMapper;
using Cqrs.Context;
using Cqrs.Model;
using Cqrs.ValueObjects;
using MediatR;

namespace Cqrs.PersonFeatures.Command.Add.CreatePersonCommand
{
    public class CreatePersonCommandHandler : IRequestHandler<AddPersonCommandModel, Guid>
    {
        private readonly CqrsDbContext _context;
        private protected IMapper _mapper;
        public CreatePersonCommandHandler(CqrsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddPersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<AddPersonCommandModel, Person>(request);
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
