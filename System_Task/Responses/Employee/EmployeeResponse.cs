namespace System_Task.Responses.Employee
{
    public class EmployeeResponse
    {
        public EmployeeResponse()
        {
            Name= string.Empty;
            Designation = string.Empty;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
    }
}
