using System_Task.Entities;
using System_Task.Repos.Interfaces;

namespace System_Task.Repos.Implementaions
{
    public class EmployeeRepo : IEmpolyeeRepo
    {
        private static List<Employee> _ = new List<Employee>();
        public EmployeeRepo()
        {
            setDummyEmployeeList();
        }
        public Employee Add(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _.Add(employee);
            return employee;
        }

        public void Delete(Guid Id)
        {
            var emp = Get(Id);
            if (emp != null)
                _.Remove(emp);
        }

        public Employee? Get(Guid Id)
        {
            return _.Find(x => x.Id.Equals(Id));
        }

        public IEnumerable<Employee> Get(string query)
        {
            if (string.IsNullOrEmpty(query))
                return _;
            return _.Where(x => x.Name.Contains(query) || x.Designation.Contains(query) || x.Designation.Contains(query));
        }

        public Employee? Update(Employee employee)
        {
            var emp = Get(employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Designation = employee.Designation;
            }
            return emp;
        }

        private void setDummyEmployeeList()
        {
            for (int i = 0; i < 20; i++)
            {
                _.Add(new Employee { Id = Guid.NewGuid(), Name = "Name" + i, Designation = "Role" + i, ForAdmin = true });
            }
        }
    }
}
