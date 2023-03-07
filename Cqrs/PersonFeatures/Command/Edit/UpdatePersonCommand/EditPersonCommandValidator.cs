using Cqrs.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.PersonFeatures.Command.Edit.UpdatePersonCommand
{
    public class EditPersonCommandValidator : AbstractValidator<EditPersonCommandModel>
    {
        private readonly CqrsDbContext _Context;
        public EditPersonCommandValidator(CqrsDbContext cqrsDbContext)
        {
            _Context = cqrsDbContext;
            RuleFor(v => v.MobileNumber)
                .NotEmpty().WithMessage("the mobile value  cant be nul")
                .MaximumLength(12).WithMessage("the Mobile cant be more than 12 number ");

            RuleFor(v => v.NationalCode)
             .NotEmpty().WithMessage("the NationalCode value  cant be nul")
              .MaximumLength(10).WithMessage("the NationalCode cant be more than 10 number ");


            RuleFor(v => v.Email)
      .NotEmpty().WithMessage("the Email value  cant be nul")
      .MustAsync(EmailNeddBeUniqe).WithMessage("The Email Must be Uniqe");
    

        }

        public async Task<bool> EmailNeddBeUniqe(string email, CancellationToken cancellationToken)
        {
            return await _Context.Persons
        .AllAsync(l => l.Email != email, cancellationToken);
        }
    }
}
