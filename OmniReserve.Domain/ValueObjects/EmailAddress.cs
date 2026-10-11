namespace OmniReserve.Domain.ValueObjects;

// Obligatorio el uso de record para garantizar igualdad estructural e inmutabilidad
public record EmailAddress
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        // Reglas de autovalidación de negocio
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("El email no puede estar vacío.");
        }

        if (!value.Contains("@"))
        {
            throw new ArgumentException("El email debe contener un formato válido.");
        }

        Value = value;
    }

    // Opcional: Sobrescribir ToString para facilitar la lectura en consola
    public override string ToString() => Value;
}
