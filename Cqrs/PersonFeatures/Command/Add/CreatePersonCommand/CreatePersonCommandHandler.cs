using Cqrs.Context;
using Cqrs.Model;
using MediatR;

namespace Cqrs.PersonFeatures.Command.Add.CreatePersonCommand
{
    public class CreatePersonCommandHandler : IRequestHandler<AddPersonCommandModel, Guid>
    {
        private readonly CqrsDbContext _context;
        public CreatePersonCommandHandler(CqrsDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddPersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Family = request.Family,
                MobileNumber = request.MobileNumber,
                NationalCode = request.NationalCode,
                Password = request.Password
            };
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
