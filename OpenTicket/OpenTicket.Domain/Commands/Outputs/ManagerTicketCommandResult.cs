using OpenTicket.Infra.Comum;

namespace OpenTicket.Domain.Commands.Output
{
    public class ManagerTicketCommandResult : ICommandResult
    {
        public bool Success { get; }
        public string Message { get; }

        // Construtor para sucesso
        public ManagerTicketCommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        // Construtor para falha com mensagens de erro
        public ManagerTicketCommandResult(bool success, string message, IEnumerable<string> errors)
        {
            Success = success;
            Message = message;
        }
    }
}
