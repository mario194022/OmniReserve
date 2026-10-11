using OmniReserve.Domain.ValueObjects;

namespace OmniReserve.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public EmailAddress Email { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string Role { get; private set; } = "Customer";

    // Propiedad de Navegación de Colección
    public ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();

    private User() { }

    public User(EmailAddress email, string firstName, string lastName, string passwordHash, string role = "Customer")
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
        Role = role;
    }
}
