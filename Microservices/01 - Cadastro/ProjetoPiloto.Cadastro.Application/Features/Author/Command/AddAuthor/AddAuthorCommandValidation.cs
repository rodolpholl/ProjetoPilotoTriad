using FluentValidation;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor
{
    public class AddAuthorCommandValidation : AbstractValidator<AddAuthorCommand>
    {
        public AddAuthorCommandValidation()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage("{FirstName} must be informed.")
                .MinimumLength(3)
                .WithMessage("{FirstName} must have more than 3 characters.")
                .MaximumLength(150)
                .WithMessage("{FirstName} must have less than 150 characters");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .WithMessage("{LastName} must be informed.")
                .MinimumLength(3)
                .WithMessage("{LastName} must have more than 3 characters.")
                .MaximumLength(150)
                .WithMessage("{LastName} must have less than 150 characters");

            RuleFor(p => p.Alias)
                .MinimumLength(3)
                .WithMessage("{LastName} must have more than 3 characters.")
                .MaximumLength(150)
                .WithMessage("{LastName} must have less than 150 characters");
        }
    }
}
