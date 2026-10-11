namespace OmniReserve.Domain.Entities;

public class Reservation
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid RoomId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CheckInDate { get; private set; }
    public DateTime CheckOutDate { get; private set; }
    public decimal TotalPrice { get; private set; }
    public string Status { get; private set; } = "Pending";

    // Propiedades de Navegación Simples
    public Room Room { get; private set; } = null!;
    public User User { get; private set; } = null!;

    private Reservation() { }

    public Reservation(Guid roomId, Guid userId, DateTime checkInDate, DateTime checkOutDate, decimal totalPrice)
    {
        RoomId = roomId;
        UserId = userId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        TotalPrice = totalPrice;
    }
}
