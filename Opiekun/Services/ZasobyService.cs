using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Opiekun.Data;
using Opiekun.Mapping;
using Opiekun.Models.Dtos;

namespace Opiekun.Services;

public class ZasobyService : IZasobyService
{
    private readonly OpiekunDbContext _context;

    public ZasobyService(OpiekunDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ZasobDTO>> GetAllZasoby()
    {
        var zasoby = await _context.Zasoby.ToListAsync();
        var dto = zasoby.Select(z => z.toDto()).ToList();
        return dto;
    }

    public async Task<ZasobDTO?> GetZasobById(Guid id)
    {
        var zasob = await _context.Zasoby
            .FirstOrDefaultAsync(z => z.Id == id);

        return zasob?.toDto();
    }

    public async Task<IEnumerable<ZasobDTO>> SearchZasobyAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query)) return await GetAllZasoby();

        query = query.ToLower();

        var zasoby = await _context.Zasoby
            .Where(z =>
                z.Nazwa.ToLower().Contains(query) ||
                z.Kategoria.ToLower().Contains(query) ||
                z.MiejscePrzechowania.ToLower().Contains(query))
            .ToListAsync();

        return zasoby.Select(z => z.toDto()).ToList();
    }

    public async Task<ZasobDTO> CreateZasobAsync(CreateZasobDTO dto)
    {
        var zasob = dto.toEntity();

        _context.Add(zasob);
        await _context.SaveChangesAsync();

        return zasob.toDto();

    }

    public async Task<bool> UpdateZasobAsync(Guid id, UpdateZasobDTO dto)
    {
        var zasob = await _context.Zasoby.FirstOrDefaultAsync(z => z.Id == id);
        if (zasob == null) return false;

        zasob.UpdateFromDto(dto);

        await _context.SaveChangesAsync();

        return true;

    }

    public async Task<bool> DeleteZasobAsync(Guid id)
    {
        var zasob = await _context.Zasoby.FirstOrDefaultAsync(z => z.Id == id);
        if (zasob == null) return false;

        _context.Zasoby.Remove(zasob);
        await _context.SaveChangesAsync();

        return true;

    }
}
