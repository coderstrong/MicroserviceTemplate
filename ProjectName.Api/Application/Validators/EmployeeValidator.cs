using FluentValidation;
using Microsoft.Extensions.Logging;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator(ILogger<EmployeeValidator> logger)
        {
            RuleFor(employe => employe.Title).NotEmpty().WithMessage("No Title found");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
