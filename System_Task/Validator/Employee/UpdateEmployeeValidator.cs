using FluentValidation;
using System_Task.Commands.Employee;

namespace System_Task.Validator.Employee
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeCommand>
    {
        public UpdateEmployeeValidator() {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.Designation).NotEmpty().MinimumLength(3).MaximumLength(200);
        }
    }
}
