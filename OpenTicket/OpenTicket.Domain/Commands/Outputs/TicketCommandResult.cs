using OpenTicket.Infra.Comum;

namespace OpenTicket.Domain.Commands.Output
{
    public class TicketCommandResult : ICommandResult
    {
        public bool Success { get; }
        public string Message { get; }


        // Construtor para sucesso
        public TicketCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        // Construtor para falha com mensagens de erro
        public TicketCommandResult(bool success, string message, IEnumerable<string> errors)
        {
            Success = success;
            Message = message;

        }
    }
}
