using Cqrs.Model;
using MediatR;

namespace Cqrs.PersonFeatures.Queries.GetPersonList
{
    public class GetAllPersonQueryModel: IRequest<IEnumerable<Person>>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
