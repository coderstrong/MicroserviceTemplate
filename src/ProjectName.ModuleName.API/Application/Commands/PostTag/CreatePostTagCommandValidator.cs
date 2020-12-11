using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class CreatePostTagCommandValidator : AbstractValidator<CreatePostTagCommand>
    {
        public CreatePostTagCommandValidator(ILogger<CreatePostTagCommandValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
