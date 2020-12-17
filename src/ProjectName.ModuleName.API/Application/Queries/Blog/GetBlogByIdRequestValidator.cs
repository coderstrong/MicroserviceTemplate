using System;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogByIdRequestValidator : AbstractValidator<GetBlogByIdRequest>
    {
        public GetBlogByIdRequestValidator(ILogger<GetBlogByIdRequestValidator> logger)
        {
            RuleFor(request => request.Id).NotEqual(Guid.Empty).WithMessage("Id is empty");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
