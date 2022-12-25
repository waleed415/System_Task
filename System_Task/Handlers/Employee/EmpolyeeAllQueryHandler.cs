using MediatR;
using System_Task.Commands.Employee;
using System_Task.Mappers;
using System_Task.Queries.Employee;
using System_Task.Repos.Interfaces;
using System_Task.Responses.Employee;

namespace System_Task.Handlers.Employee
{
    public class EmpolyeeAllQueryHandler : IRequestHandler<EmployeeAllQuery, List<EmployeeResponse>>
    {
        private readonly IEmpolyeeRepo _empRepo;
        public EmpolyeeAllQueryHandler(IEmpolyeeRepo repo)
        {
            _empRepo = repo;
        }
        public async Task<List<EmployeeResponse>> Handle(EmployeeAllQuery request, CancellationToken cancellationToken)
        {
            var emp = _empRepo.Get(request.query);
            if (!request.ForAdmin)
                emp = emp.Where(x => !x.ForAdmin);
            var res = EmployeeMapper.Mapper().Map<List<EmployeeResponse>>(emp);
            return await Task.FromResult(res);
        }
    }
}
