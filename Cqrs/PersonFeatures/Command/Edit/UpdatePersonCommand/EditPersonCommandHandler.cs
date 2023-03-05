using Cqrs.Context;
using MediatR;

namespace Cqrs.PersonFeatures.Command.Edit.UpdatePersonCommand
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommandModel, Guid>
    {
        private readonly CqrsDbContext _context;
        public EditPersonCommandHandler(CqrsDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(EditPersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = _context.Persons.Where(a => a.Id == request.Id).FirstOrDefault();
            if (person == null)
            {
                return default;
            }
            else
            {
                person.Name = request.Name;
                person.Family = request.Family;
                person.NationalCode = request.NationalCode;
                person.MobileNumber = request.MobileNumber;
                person.Email = request.Email;
                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
                return person.Id;
            }
        }
    }
}
