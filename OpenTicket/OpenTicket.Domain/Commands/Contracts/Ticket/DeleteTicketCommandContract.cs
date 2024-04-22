using Flunt.Validations;
using OpenTicket.Domain.Commands.Input.Ticket;

namespace OpenTicket.Domain.Commands.Contracts.Ticket
{
    public class DeleteTicketCommandContract : Contract<DeleteTicketCommand>
    {
        public DeleteTicketCommandContract(DeleteTicketCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id é obrigatório");
            Requires().IsGreaterThan(command.Id, 0, "Id", "Id deve ser maior que 0.");
        }
    }
}
