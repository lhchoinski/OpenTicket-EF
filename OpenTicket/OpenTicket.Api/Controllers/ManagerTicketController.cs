using Microsoft.AspNetCore.Mvc;
using OpenTicket.Domain.Commands.Input.Ticket;
using OpenTicket.Domain.Handlers;

namespace OpenTicket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerTicketController : ControllerBase
    {
        private readonly ManagerTicketHandler _managerTicketHandler;

        public ManagerTicketController(ManagerTicketHandler managerTicketHandler)
        {
            _managerTicketHandler = managerTicketHandler;
        }

        [HttpPost]
        public async Task<IActionResult> ManageTicket(ManagerTicketCommand command)
        {
            var result = await _managerTicketHandler.TicketManagerAsync(command);
            return Ok(result);
        }
    }
}
