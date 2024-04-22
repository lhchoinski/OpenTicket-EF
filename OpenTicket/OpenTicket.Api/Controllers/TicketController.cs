using Microsoft.AspNetCore.Mvc;
using OpenTicket.Domain.Commands.Input.Ticket;
using OpenTicket.Domain.Handlers;

namespace OpenTicket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketHandler _ticketHandler;

        public TicketController(TicketHandler ticketHandler)
        {
            _ticketHandler = ticketHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(SaveTicketCommand command)
        {
            var result = await _ticketHandler.SaveTicketAsync(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _ticketHandler.GetAllTicketsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _ticketHandler.GetTicketByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, UpdateTicketCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("O ID do ticket na URL não corresponde ao ID fornecido no comando.");
            }

            var result = await _ticketHandler.UpdateTicketAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var command = new DeleteTicketCommand { Id = id };
            var result = await _ticketHandler.DeleteAsync(command);
            return Ok(result);
        }
    }
}
