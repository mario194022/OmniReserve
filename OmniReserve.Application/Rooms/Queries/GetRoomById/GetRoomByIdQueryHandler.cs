using MediatR;

namespace OmniReserve.Application.Rooms.Queries.GetRoomById;

public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomResponseDto>
{
    public Task<RoomResponseDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        // Simulación temporal: Retornamos un DTO estático utilizando el ID solicitado
        var response = new RoomResponseDto(
            request.RoomId,
            "101",
            "Single",
            120.00m,
            true
        );

        return Task.FromResult(response);
    }
}
