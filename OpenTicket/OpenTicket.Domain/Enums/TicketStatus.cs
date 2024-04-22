using System.ComponentModel;

namespace OpenTicket.Domain.Enums
{
    public enum TicketStatus
    {
        [Description("Open")]
        Open = 0,
        [Description("InProgress")]
        InProgress = 1,
        [Description("Resolved")]
        Resolved = 2
    }
}
