using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ProjectName.ModuleName.Domain.SeedWork;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogByIdQueryRequestValidator : AbstractValidator<GetBlogByIdQueryRequest>
    {
        public GetBlogByIdQueryRequestValidator(ILogger<GetBlogByIdQueryRequestValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}