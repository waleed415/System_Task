using FluentValidation;
using System_Task.Commands.Employee;

namespace System_Task.Validator.Employee
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeCommand>
    {
        public CreateEmployeeValidator() {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.Designation).NotEmpty().MinimumLength(3).MaximumLength(200);
        }
    }
}
