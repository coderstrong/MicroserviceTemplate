using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class UpdatePostTagCommandValidator : AbstractValidator<UpdatePostTagCommand>
    {
        public UpdatePostTagCommandValidator(ILogger<UpdatePostTagCommandValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
