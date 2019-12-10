using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;

namespace ProjectName.Api.Application.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator(ILogger<EmployeeValidator> logger)
        {
            RuleFor(employe => employe.FirstName).NotEmpty().WithMessage("No FirstName found");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
