using MediatR;
using System_Task.Responses.Employee;

namespace System_Task.Commands.Employee
{
    public class DeleteEmployeCommand : IRequest<EmployeeResponse>
    {
        public Guid Id { get; set; }
    }
}
