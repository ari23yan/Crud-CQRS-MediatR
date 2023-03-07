using AutoMapper;
using Cqrs.Model;
using Cqrs.PersonFeatures.Command.Add.CreatePersonCommand;
using Cqrs.PersonFeatures.Command.Edit.UpdatePersonCommand;

namespace Cqrs.Profiles
{
    public class PersonProfile:Profile
    {

        public PersonProfile()
        {
            CreateMap<Person, AddPersonCommandModel>().ReverseMap();
            //CreateMap<Person, EditPersonCommandModel>().ReverseMap().ForAllMembers(opt => opt.Condition(src => src != null));
        }
    }
}
