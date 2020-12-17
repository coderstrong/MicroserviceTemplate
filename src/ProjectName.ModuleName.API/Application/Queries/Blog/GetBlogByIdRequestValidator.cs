using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogByIdRequestValidator : AbstractValidator<GetBlogByIdRequest>
    {
        public GetBlogByIdRequestValidator(ILogger<GetBlogByIdRequestValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
