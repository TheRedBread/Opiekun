using Microsoft.AspNetCore.Mvc;
using Opiekun.Models.Dtos;

namespace Opiekun.Services;

public interface IZasobyService
{
    Task<IEnumerable<ZasobDTO>> GetAllZasoby();
    Task<ZasobDTO?> GetZasobById(Guid id);

    Task<IEnumerable<ZasobDTO>> SearchZasobyAsync(string query);

    Task<ZasobDTO> CreateZasobAsync(CreateZasobDTO dto);

    Task<bool> UpdateZasobAsync(Guid id, UpdateZasobDTO dto);
    Task<bool> DeleteZasobAsync(Guid id);

    Task<IEnumerable<ZasobDTO>> GetInsufficientZasoby(string? kategoria, bool includeAll);

}
