using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.ModuleName.Application.Commands
{
    public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
    {
        public DeleteBlogCommandValidator(ILogger<DeleteBlogCommandValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}