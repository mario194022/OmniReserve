using Microsoft.EntityFrameworkCore;
using OmniReserve.Application.Common.Interfaces;
using OmniReserve.Domain.Entities;

namespace OmniReserve.Infrastructure.Persistence.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Room room)
    {
        // EF Core trackea la Entidad
        await _context.Rooms.AddAsync(room);
        
        // ¡Crucial! Confirma (Commit) a la base de datos real
        await _context.SaveChangesAsync();
    }

    public async Task<Room?> GetByIdAsync(Guid id)
    {
        // Se conecta a PostgreSQL para obtener o retornar nulo
        return await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Room?> SearchByNumberAsync(string roomNumber)
    {
        // Solución Segura: EF Core extrae 'roomNumber' y lo parametriza automáticamente (@p0)
        return await _context.Rooms
            .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
    }

    public async Task<List<Room>> GetRoomsByTypeRawAsync(string roomType)
    {
        // 100% Seguro.
        // La sintaxis Interpolada ($"") en FromSql es desarmada por el compilador de C# 
        // y enviada a la DB como "SELECT * FROM \"Rooms\" WHERE \"Type\" = @p0"
        
        return await _context.Rooms
            .FromSql($"SELECT * FROM \"Rooms\" WHERE \"Type\" = {roomType}")
            .ToListAsync();
    }
}
