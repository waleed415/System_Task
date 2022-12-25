using MediatR;
using System_Task.Responses.Employee;

namespace System_Task.Queries.Employee
{
    public class EmployeeGetByIdQuery : IRequest<EmployeeResponse>
    {
        public Guid Id { get; set; }
    }
}
