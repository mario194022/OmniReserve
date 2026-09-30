using OmniReserve.Domain.Enums;

namespace OmniReserve.Domain.Entities;

public class Room
{
    public Guid Id { get; private set; }
    public string RoomNumber { get; private set; }
    public RoomType Type { get; private set; }
    public decimal PricePerNight { get; private set; }
    public bool IsAvailable { get; private set; }

    public Room(string roomNumber, RoomType type, decimal pricePerNight)
    {
        Id = Guid.NewGuid();
        RoomNumber = !string.IsNullOrWhiteSpace(roomNumber) ? roomNumber : throw new ArgumentNullException(nameof(roomNumber));
        Type = type;
        PricePerNight = pricePerNight >= 0 ? pricePerNight : throw new ArgumentException("Price cannot be negative.", nameof(pricePerNight));
        IsAvailable = true; // Por defecto
    }

    public void MarkAsUnavailable()
    {
        IsAvailable = false;
    }

    public void MarkAsAvailable()
    {
        IsAvailable = true;
    }
}
