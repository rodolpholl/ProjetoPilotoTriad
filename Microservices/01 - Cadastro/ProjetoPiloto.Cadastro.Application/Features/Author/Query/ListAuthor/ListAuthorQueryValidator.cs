using FluentValidation;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Query.ListAuthor
{
    public class ListAuthorQueryValidator : AbstractValidator<ListAuthorQuery>
    {
        public ListAuthorQueryValidator()
        {
            RuleFor(x => x.Index)
                .GreaterThan(0)
                .WithMessage("Page mnust be Greater than 1")
                .NotNull()
                .WithMessage("Page must be informed");

            RuleFor(x => x.Count)
                .GreaterThan(0)
                .WithMessage("Size must be Greater than 1")
                .NotNull()
                .WithMessage("Size must be informed");
        }
    }
}
