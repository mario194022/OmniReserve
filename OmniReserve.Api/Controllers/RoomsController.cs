using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmniReserve.Application.Rooms.Commands.CreateRoom;

namespace OmniReserve.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly ISender _sender;

    public RoomsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
    {
        // Se envía el objeto a MediatR, este buscará a su Handler
        var roomId = await _sender.Send(command);

        // Se retorna HTTP 200 OK incluyendo la data en formato JSON automáticamente
        return Ok(roomId);
    }
}
