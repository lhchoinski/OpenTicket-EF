using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Commands.Input.Ticket
{
    public class ManagerTicketCommand 
    {
       
        public int Id { get; set; }
        public string? TechnicianDescription { get; set; }
        public DateTime? UpdatedAt { get; set; } 
        public int AssignedEmployeeId { get; set; }
        public TicketStatus Status { get; set; }
        
    }
}
