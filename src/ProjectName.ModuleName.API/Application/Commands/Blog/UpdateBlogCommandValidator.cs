using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using ProjectName.ModuleName.Domain.SeedWork;

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
