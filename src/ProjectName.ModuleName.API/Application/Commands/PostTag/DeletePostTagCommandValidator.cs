using FluentValidation;
using Microsoft.Extensions.Logging;
using System;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class DeletePostTagCommandValidator : AbstractValidator<DeletePostTagCommand>
    {
        public DeletePostTagCommandValidator(ILogger<DeletePostTagCommandValidator> logger)
        {
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
