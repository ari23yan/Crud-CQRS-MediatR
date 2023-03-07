using FluentValidation;

namespace Cqrs.PersonFeatures.Command.Delete.DeletePersonByIdCommand
{
    public class DeletePersonCommandValidator: AbstractValidator<DeletePersonCommandModel>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
