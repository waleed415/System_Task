using MediatR;
using System_Task.Responses.Employee;

namespace System_Task.Commands.Employee
{
    public class UpdateEmployeCommand : IRequest<EmployeeResponse>
    {
        public UpdateEmployeCommand()
        {
            Name = string.Empty;
            Designation = string.Empty;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
    }
}
