using System;
using System_Task.Entities;

namespace System_Task.Repos.Interfaces
{
    public interface IEmpolyeeRepo
    {
        public Employee Add(Employee employee);
        public Employee? Update(Employee employee);
        public void Delete(Guid Id);
        public Employee? Get(Guid Id);
        public IEnumerable<Employee> Get(string query);
    }
}
