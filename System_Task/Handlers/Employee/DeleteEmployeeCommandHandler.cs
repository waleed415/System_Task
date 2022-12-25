using AutoMapper.Execution;
using MediatR;
using System_Task.Commands.Employee;
using System_Task.Mappers;
using System_Task.Repos.Interfaces;
using System_Task.Responses.Employee;

namespace System_Task.Handlers.Employee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeCommand, EmployeeResponse>
    {
        private readonly IEmpolyeeRepo _empolyeeRepo;
        public DeleteEmployeeCommandHandler(IEmpolyeeRepo empolyeeRepo)
        {
            _empolyeeRepo= empolyeeRepo;
        }
        public async Task<EmployeeResponse> Handle(DeleteEmployeCommand request, CancellationToken cancellationToken)
        {
           
            _empolyeeRepo.Delete(request.Id);
            return await Task.FromResult(new EmployeeResponse());
        }
    }
}
