using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Opiekun.Models.Dtos;
using Opiekun.Services;

namespace Opiekun.Controllers;

[Route("api/zasoby")]
[ApiController]
[Authorize]
public class ZasobyApiController : ControllerBase
{
    private readonly IZasobyService _zasobyService;

    public ZasobyApiController(IZasobyService zasobyService)
    {
        _zasobyService = zasobyService;
    }

    // GET: api/zasoby
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ZasobDTO>>> GetZasoby()
    {
        var zasoby = await _zasobyService.GetAllZasoby();
        return Ok(zasoby);
    }

    // GET: api/zasoby/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ZasobDTO>> GetZasob(Guid id)
    {
        var zasob = await _zasobyService.GetZasobById(id);

        if (zasob == null)
            return NotFound();

        return Ok(zasob);
    }

    // GET: api/zasoby/search?query=kot
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ZasobDTO>>> SearchZasoby([FromQuery] string query)
    {
        var results = await _zasobyService.SearchZasobyAsync(query);

        return Ok(results);
    }

    // POST: api/zasoby
    [HttpPost]
    public async Task<ActionResult<ZasobDTO>> CreateZasob([FromBody] CreateZasobDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var created = await _zasobyService.CreateZasobAsync(dto);

        return CreatedAtAction(
            nameof(GetZasob),           // GET /api/zasoby/{id}
            new { id = created.Id },    // {id} do GET
                created );              // odpowiedź

    }

    // PUT: api/zasoby/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<ZasobDTO>> UpdateZasob(Guid id, [FromBody] UpdateZasobDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var updated = await _zasobyService.UpdateZasobAsync(id, dto);

        if (!updated) return NotFound();

        return NoContent();

    }

    // DELETE: api/zasoby/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<ZasobDTO>> DeleteZasob(Guid id)
    {
        var deleted = await _zasobyService.DeleteZasobAsync(id);

        if (!deleted) return NotFound();

        return NoContent();

    }

    // Get api/zasoby/niskistan?kategoria=karma&includeAll=true
    [HttpGet("niskistan")]
    public async Task<ActionResult<IEnumerable<ZasobDTO>>> InsufficientZasoby([FromQuery] string? kategoria, [FromQuery] bool includeAll)
    {
        var results = await _zasobyService.GetInsufficientZasoby(kategoria, includeAll);
        return Ok(results);
    }



}
