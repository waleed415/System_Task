using MediatR;
using System_Task.Responses.Employee;

namespace System_Task.Commands.Employee
{
    public class CreateEmployeCommand : IRequest<EmployeeResponse>
    {
        public CreateEmployeCommand()
        {
            Name= string.Empty;
            Designation= string.Empty;
        }
        public string Name { get; set; }
        public string Designation { get; set; }
    }
}
