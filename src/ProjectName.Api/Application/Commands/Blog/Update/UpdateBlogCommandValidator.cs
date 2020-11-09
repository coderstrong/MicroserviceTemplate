using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.API.Application.Commands
{
    public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator(ILogger<UpdateBlogCommandValidator> logger)
        {
            RuleFor(command => command.Id).Null().WithMessage("Id is Required").Empty().WithMessage("Id invaild");
            RuleFor(command => command.Title).NotEmpty().WithMessage("No Title found");
            RuleFor(command => command.Description).NotEmpty().WithMessage("No Description found");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
