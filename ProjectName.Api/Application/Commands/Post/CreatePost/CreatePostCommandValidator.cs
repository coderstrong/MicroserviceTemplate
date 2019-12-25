using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Commands;

namespace ProjectName.Api.Application.Commands
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator(ILogger<CreatePostCommandValidator> logger)
        {
            RuleFor(command => command.Title).NotEmpty().WithMessage("No Title found");
            RuleFor(command => command.Author).NotEmpty().WithMessage("No Author found");
            RuleFor(command => command.Content).NotEmpty().WithMessage("No Content found");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
