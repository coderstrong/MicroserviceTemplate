using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.API.Application.Commands
{
    public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
    {
        public DeleteBlogCommandValidator(ILogger<DeleteBlogCommandValidator> logger)
        {
            RuleFor(command => command.Id).NotNull().WithMessage("Id is Required");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
