using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator(ILogger<UpdateBlogCommandValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
