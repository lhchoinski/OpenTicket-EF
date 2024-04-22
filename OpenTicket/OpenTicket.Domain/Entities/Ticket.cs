using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Entities
{
    public class Ticket
    {
        public Ticket(string title, string description, DateTime createdAt, DateTime? updatedAt, int employeeId, TicketStatus? status)
        {
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            EmployeeId = employeeId;
            Status = status;
        }

        public Ticket(string title, string description, string? technicianDescription, DateTime createdAt, DateTime? updatedAt, int employeeId, int? assignedEmployeeId, TicketStatus? status)
        {
            Title = title;
            Description = description;
            TechnicianDescription = technicianDescription;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            EmployeeId = employeeId;
            AssignedEmployeeId = assignedEmployeeId;
            Status = status;
        }

        public Ticket(int id, string title, string description, string? technicianDescription, DateTime createdAt, DateTime? updatedAt, int employeeId, int? assignedEmployeeId, TicketStatus? status)
        {
            Id = id;
            Title = title;
            Description = description;
            TechnicianDescription = technicianDescription;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            EmployeeId = employeeId;
            AssignedEmployeeId = assignedEmployeeId;
            Status = status;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? TechnicianDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }
        public Employee? AssignedEmployee { get; set; }
        public int? AssignedEmployeeId { get; set; }
        public TicketStatus? Status { get; set; }

    }
}
