using AutoMapper.Execution;
using MediatR;
using System_Task.Commands.Employee;
using System_Task.Mappers;
using System_Task.Repos.Interfaces;
using System_Task.Responses.Employee;

namespace System_Task.Handlers.Employee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeCommand, EmployeeResponse>
    {
        private readonly IEmpolyeeRepo _empolyeeRepo;
        public CreateEmployeeCommandHandler(IEmpolyeeRepo empolyeeRepo)
        {
            _empolyeeRepo= empolyeeRepo;
        }
        public async Task<EmployeeResponse> Handle(CreateEmployeCommand request, CancellationToken cancellationToken)
        {
            var emp = EmployeeMapper.Mapper().Map<Entities.Employee>(request);
            emp = _empolyeeRepo.Add(emp);
            var response = EmployeeMapper.Mapper().Map<EmployeeResponse>(emp);
            return await Task.FromResult(response);
        }
    }
}
