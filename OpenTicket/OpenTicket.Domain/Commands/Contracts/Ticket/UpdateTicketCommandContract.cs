using Flunt.Validations;
using OpenTicket.Domain.Commands.Input.Ticket;

namespace OpenTicket.Domain.Commands.Contracts.Ticket
{
    public class UpdateTicketCommandContract : Contract<SaveTicketCommand>
    {
        public UpdateTicketCommandContract(UpdateTicketCommand command)
        {
            Requires().IsNotNullOrEmpty(command.Id.ToString(), "Id", "Id é obrigatório");
            Requires().IsGreaterThan(command.Id, 0, "Id", "Id deve ser maior que 0");

            if (command.Title != null)
                Requires().AreNotEquals(command.Title.Trim(), string.Empty, "Nome", "Nome não pode ser somente um espaço");


        }
    }
}
