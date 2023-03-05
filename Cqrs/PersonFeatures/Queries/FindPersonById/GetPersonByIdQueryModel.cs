using Cqrs.Model;
using MediatR;

namespace Cqrs.PersonFeatures.Queries.FindPersonById
{
    public class GetPersonByIdQueryModel : IRequest<Person>
    {
        public Guid Id { get; set; }

    }
}
