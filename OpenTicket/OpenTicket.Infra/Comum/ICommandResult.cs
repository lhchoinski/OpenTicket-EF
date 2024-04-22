namespace OpenTicket.Infra.Comum
{
    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
