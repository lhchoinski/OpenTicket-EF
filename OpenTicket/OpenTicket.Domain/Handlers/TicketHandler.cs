using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Commands.Output;
using OpenTicket.Domain.Commands.Input.Ticket;
using OpenTicket.Infra.Comum;
using OpenTicket.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace OpenTicket.Domain.Handlers
{
    public class TicketHandler
    {
        private readonly AppDataContext _context;

        public TicketHandler(AppDataContext context)
        {
            _context = context;
        }

        public async Task<ICommandResult> SaveTicketAsync(SaveTicketCommand command)
        {
            try
            {
                var ticket = new Ticket(
                    command.Title,
                    command.Description,
                    command.CreatedAt = DateTime.Now,
                    command.UpdatedAt = DateTime.Now,
                    command.EmployeeId,
                    command.Status = 0
                );

                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new TicketCommandResult(false, "Erro ao salvar o ticket: " + ex.Message);
            }

            return new TicketCommandResult(true, "Ticket inserido com sucesso");
        }

        public async Task<ICommandResult> UpdateTicketAsync(UpdateTicketCommand command)
        {
            var ticket = await _context.Tickets.FindAsync(command.Id);
            if (ticket == null)
            {
                return new TicketCommandResult(false, "Ticket não encontrado");
            }

            ticket.Title = command.Title;
            ticket.Description = command.Description;
            ticket.TechnicianDescription = command.TechnicianDescription;
            ticket.UpdatedAt = DateTime.UtcNow;
            ticket.EmployeeId = command.EmployeeId;
            ticket.AssignedEmployeeId = command.AssignedEmployeeId;
            ticket.Status = command.Status;

            await _context.SaveChangesAsync();

            return new TicketCommandResult(true, "Ticket atualizado com sucesso");
        }

        public async Task<ICommandResult> DeleteAsync(DeleteTicketCommand command)
        {
            var ticket = await _context.Tickets.FindAsync(command.Id);
            if (ticket == null)
            {
                return new TicketCommandResult(false, "Ticket não encontrado");
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return new TicketCommandResult(true, "Ticket deletado com sucesso");
        }
        public async Task<ICommandResult> GetAllTicketsAsync()
        {
            var ticket = await _context.Tickets.ToListAsync();
            return new EmployeeCommandResult(true, "Lista de tickets recuperada com sucesso", ticket);
        }

        public async Task<ICommandResult> GetTicketByIdAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return new EmployeeCommandResult(false, "Ticket não encontrado");
            }

            return new EmployeeCommandResult(true, "Ticket encontrado com sucesso", ticket);
        }
    }
}
