using MediatR;
using OmniReserve.Domain.Entities;

namespace OmniReserve.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
{
    public Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        // Instanciamos el objeto Room del Dominio usando los datos del comando
        var room = new Room(request.RoomNumber, request.Type, request.PricePerNight);

        // Retornamos el ID generado (a futuro se persistirá mediante EF Core)
        return Task.FromResult(room.Id);
    }
}
