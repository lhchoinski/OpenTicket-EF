using OpenTicket.Domain.Enums;

namespace OpenTicket.Domain.Commands.Input.Ticket
{
    public class SaveTicketCommand 
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int EmployeeId { get; set; } 
        public TicketStatus? Status { get; set; } = 0;
       
    }
}
