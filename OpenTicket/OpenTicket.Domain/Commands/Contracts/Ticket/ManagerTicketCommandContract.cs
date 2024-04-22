using Flunt.Validations;
using OpenTicket.Domain.Commands.Input.Ticket;

namespace OpenTicket.Domain.Commands.Contracts.Ticket
{
    public class ManagerTicketCommandContract : Contract<ManagerTicketCommand>
    {
        public ManagerTicketCommandContract(ManagerTicketCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id é obrigatório");
            Requires().IsGreaterThan(command.Id, 0, "Id", "Id deve ser maior que 0");

            if (command.Status != null)
                Requires().AreNotEquals(command.Status.CompareTo, string.Empty, "Status", "Você deve alterar o status do ticket");
        }
    }
}
