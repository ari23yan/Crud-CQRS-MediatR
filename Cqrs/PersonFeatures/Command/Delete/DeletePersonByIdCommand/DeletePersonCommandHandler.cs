using Cqrs.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.PersonFeatures.Command.Delete.DeletePersonByIdCommand
{
    public class DeletePersonCommandHandler: IRequestHandler<DeletePersonCommandModel, Guid>
    {
        private readonly CqrsDbContext _context;
        public DeletePersonCommandHandler(CqrsDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeletePersonCommandModel request, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (person == null) return default;
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return person.Id;
        }
    }
}
