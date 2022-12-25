namespace System_Task.Entities
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Designation = string.Empty;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public bool ForAdmin{ get; set; }
    }
}
