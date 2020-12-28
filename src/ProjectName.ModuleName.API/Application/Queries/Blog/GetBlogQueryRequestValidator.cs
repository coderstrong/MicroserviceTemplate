using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ProjectName.ModuleName.Domain.SeedWork;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogQueryRequestValidator : AbstractValidator<GetBlogQueryRequest>
    {
        public GetBlogQueryRequestValidator(ILogger<GetBlogQueryRequestValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}