namespace OmniReserve.Domain.Entities;

public class Room
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string RoomNumber { get; private set; } = null!;
    public string Type { get; private set; } = null!;
    public decimal PricePerNight { get; private set; }
    public bool IsAvailable { get; private set; } = true;

    // Propiedad de Navegación de Colección
    public ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();

    private Room() { }

    public Room(string roomNumber, string type, decimal pricePerNight)
    {
        RoomNumber = roomNumber;
        Type = type;
        PricePerNight = pricePerNight;
    }
}
