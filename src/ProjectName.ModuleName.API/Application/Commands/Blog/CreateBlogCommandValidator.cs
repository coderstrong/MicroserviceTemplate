using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator(ILogger<CreateBlogCommandValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
