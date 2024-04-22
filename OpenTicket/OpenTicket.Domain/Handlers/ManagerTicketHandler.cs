using OpenTicket.Infra.Comum;
using OpenTicket.Domain.Commands.Output;
using OpenTicket.Domain.Commands.Input.Ticket;
using OpenTicket.Data.Context;

namespace OpenTicket.Domain.Handlers
{
    public class ManagerTicketHandler
    {
        private readonly AppDataContext _context;

        public ManagerTicketHandler(AppDataContext context)
        {
            _context = context;
        }

        public async Task<ICommandResult> TicketManagerAsync(ManagerTicketCommand command)
        {
            
            var ticket = await _context.Tickets.FindAsync(command.Id);
            if (ticket == null)
            {
                return new ManagerTicketCommandResult(false, "Ticket não encontrado");
            }

            ticket.TechnicianDescription = command.TechnicianDescription;
            ticket.AssignedEmployeeId = command.AssignedEmployeeId;
            ticket.UpdatedAt = DateTime.UtcNow;
            ticket.Status = command.Status;

            
            await _context.SaveChangesAsync();

            return new ManagerTicketCommandResult(true, "Ticket atualizado com sucesso");
        }
    }
}
