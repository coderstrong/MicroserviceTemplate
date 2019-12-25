using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Commands;

namespace ProjectName.Api.Application.Commands
{
    public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
    {
        public DeleteBlogCommandValidator(ILogger<DeleteBlogCommandValidator> logger)
        {
            RuleFor(command => command.Id).NotNull().WithMessage("Id is Required")
                .GreaterThanOrEqualTo(0).WithMessage("Id invaild");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
