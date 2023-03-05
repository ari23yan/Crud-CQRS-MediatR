using MediatR;

namespace Cqrs.PersonFeatures.Command.Delete.DeletePersonByIdCommand
{
    public class DeletePersonCommandModel:IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
