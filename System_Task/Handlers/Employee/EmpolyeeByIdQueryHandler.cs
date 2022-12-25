using MediatR;
using System_Task.Commands.Employee;
using System_Task.Mappers;
using System_Task.Queries.Employee;
using System_Task.Repos.Interfaces;
using System_Task.Responses.Employee;

namespace System_Task.Handlers.Employee
{
    public class EmpolyeeByIdQueryHandler : IRequestHandler<EmployeeGetByIdQuery, EmployeeResponse>
    {
        private readonly IEmpolyeeRepo _empRepo;
        public EmpolyeeByIdQueryHandler(IEmpolyeeRepo repo)
        {
            _empRepo = repo;
        }
        public async Task<EmployeeResponse> Handle(EmployeeGetByIdQuery request, CancellationToken cancellationToken)
        {
            var emp = _empRepo.Get(request.Id);
            var res = EmployeeMapper.Mapper().Map<EmployeeResponse>(emp);
            return await Task.FromResult(res);
        }
    }
}
