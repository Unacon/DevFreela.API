using DevFreela.Application.Commands.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o comentário.");

            RuleFor(c => c.Content)
                .MaximumLength(255)
                .WithMessage("Comentário deve conter no máximo 255 caracteres.");

            RuleFor(p => p.IdProject)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o projeto.");

            RuleFor(p => p.IdUser)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o usuário.");

        }
    }
}
