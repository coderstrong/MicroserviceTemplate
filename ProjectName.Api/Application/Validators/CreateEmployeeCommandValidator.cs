using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectName.Api.Application.Commands;

namespace ProjectName.Api.Application.Validations
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator(ILogger<CreateEmployeeCommandValidator> logger)
        {
            RuleFor(command => command.FullName).NotEmpty().WithMessage("No FullName found");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
