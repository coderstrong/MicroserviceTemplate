using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.API.Application.Commands
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator(ILogger<CreateBlogCommandValidator> logger)
        {
            RuleFor(command => command.Title).NotEmpty().WithMessage("No Title found");
            RuleFor(command => command.Description).NotEmpty().WithMessage("No Description found");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
