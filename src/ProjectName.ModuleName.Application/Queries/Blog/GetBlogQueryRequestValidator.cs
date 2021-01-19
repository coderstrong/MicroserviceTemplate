using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.ModuleName.Application.Queries
{
    public class GetBlogQueryRequestValidator : AbstractValidator<GetBlogQueryRequest>
    {
        public GetBlogQueryRequestValidator(ILogger<GetBlogQueryRequestValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}