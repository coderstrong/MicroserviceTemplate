using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator(ILogger<EmployeeValidator> logger)
        {
            RuleFor(employe => employe.Id).NotEmpty().WithMessage("No orderId found");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
