using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .WithMessage("Page must br informed");

            RuleFor(x => x.Count)
                .GreaterThan(0)
                .WithMessage("Size must be Greater than 1")
                .NotNull()
                .WithMessage("Size must br informed");
        }
    }
}
