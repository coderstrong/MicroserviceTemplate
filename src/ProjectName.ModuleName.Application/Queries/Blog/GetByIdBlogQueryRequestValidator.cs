using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.ModuleName.Application.Queries
{
    public class GetBlogByIdQueryRequestValidator : AbstractValidator<GetBlogByIdQueryRequest>
    {
        public GetBlogByIdQueryRequestValidator(ILogger<GetBlogByIdQueryRequestValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}