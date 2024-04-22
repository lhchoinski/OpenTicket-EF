using System.ComponentModel;

namespace OpenTicket.Domain.Enums
{
    public enum EmployeeType
    {
        [Description("Client")]
        Client = 1,
        [Description("technician")]
        Technician = 2,
        [Description("Administrator")]
        Administrator = 3
    }
}
