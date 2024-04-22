using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Commands.Input.Employee
{
    public class SaveEmployeeCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public EmployeeType EmployeeType { get; set; }

    }
}
