using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Entities
{
    public class Employee
    {
        public Employee(int id, string name, string email, string department, EmployeeType employeeType)
        {
            Id = id;
            Name = name;
            Email = email;
            Department = department;
            EmployeeType = employeeType;
        }

        public Employee(string name, string email, string department, EmployeeType employeeType)
        {
            Name = name;
            Email = email;
            Department = department;
            EmployeeType = employeeType;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public EmployeeType EmployeeType { get; set; }

    }
}
