using Opiekun.Models.Dtos;
using Opiekun.Models;

namespace Opiekun.Services;

public interface IZasobyService
{
    /// <summary>
    /// Returns all <see cref="Zasob"/> entities as <see cref="ZasobDTO"/>
    /// </summary>
    Task<IEnumerable<ZasobDTO>> GetAllZasoby();

    /// <summary>
    /// Returns a <see cref="Zasob"/> entity as a <see cref="ZasobDTO"/>
    /// </summary>
    /// <param name="id">The Zasob id</param>
    Task<ZasobDTO?> GetZasobById(Guid id);

    /// <summary>
    /// Searches <see cref="Zasob"/> entities by name, category, or description
    /// containing the query
    /// </summary>
    /// <param name="query">text</param>
    Task<IEnumerable<ZasobDTO>> SearchZasobyAsync(string query);

    /// <summary>
    /// Creates a new <see cref="Zasob"/> entity using the provided data
    /// </summary>
    /// <param name="dto">The data used to create the resource</param>
    Task<ZasobDTO> CreateZasobAsync(CreateZasobDTO dto);

    /// <summary>
    /// Updates an existing <see cref="Zasob"/> entity with the provided data
    /// </summary>
    /// <param name="id">The identifier of the resource to update</param>
    /// <param name="dto">The updated data.</param>
    Task<bool> UpdateZasobAsync(Guid id, UpdateZasobDTO dto);

    /// <summary>
    /// Deletes the <see cref="Zasob"/> entity with id
    /// </summary>
    /// <param name="id">The identifier of the resource to delete</param>
    Task<bool> DeleteZasobAsync(Guid id);

    /// <summary>
    /// Returns <see cref="Zasob"/> entities whose
    /// <see cref="Zasob.Ilosc"/> is &lt; <see cref="Zasob.MinimumIlosc"/>.
    /// </summary>
    /// <param name="kategoria">
    /// Filters results where <see cref="Zasob.Kategoria"/>
    /// contains the value
    /// </param>
    /// <param name="includeAll">
    /// If true, returns all entities despite quantity
    /// </param>
    Task<IEnumerable<ZasobDTO>> GetInsufficientZasoby(string? kategoria, bool includeAll);

}
