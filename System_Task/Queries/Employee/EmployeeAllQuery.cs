using MediatR;
using System_Task.Responses.Employee;

namespace System_Task.Queries.Employee
{
    public class EmployeeAllQuery : IRequest<List<EmployeeResponse>>
    {
        public EmployeeAllQuery()
        {
            query = string.Empty;
        }
        public string query { get; set; }
        public bool ForAdmin { get; set; }
    }
}
