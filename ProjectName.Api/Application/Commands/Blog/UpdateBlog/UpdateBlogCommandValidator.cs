using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.Api.Application.Commands
{
    public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator(ILogger<UpdateBlogCommandValidator> logger)
        {
            RuleFor(command => command.Id).NotNull().WithMessage("Id is Required")
                .GreaterThanOrEqualTo(0).WithMessage("Id invaild");
            RuleFor(command => command.Title).NotEmpty().WithMessage("No Title found");
            RuleFor(command => command.Description).NotEmpty().WithMessage("No Description found");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
