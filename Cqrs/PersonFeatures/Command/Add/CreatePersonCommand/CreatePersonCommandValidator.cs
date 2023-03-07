using Cqrs.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.PersonFeatures.Command.Add.CreatePersonCommand
{
    public class CreatePersonCommandValidator: AbstractValidator<AddPersonCommandModel>
    {
        private readonly CqrsDbContext _context;

        public CreatePersonCommandValidator(CqrsDbContext cqrsDbContext)
        {
            _context = cqrsDbContext;
            RuleFor(v => v.Email)
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.")
                .EmailAddress().WithMessage("The Email Format Is not Correct.")
                .NotEmpty().WithMessage("The Email Cant Be Null");


            RuleFor(v=>v.MobileNumber).NotEmpty().WithMessage("The Email Cant Be Null");
        }

        public  async Task<bool> BeUniqueTitle(string email, CancellationToken cancellationToken)
        {
            return  await _context.Persons
                .AllAsync(l => l.Email != email, cancellationToken);
        }

    }
}
