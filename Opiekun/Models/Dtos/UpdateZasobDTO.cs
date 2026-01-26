namespace Opiekun.Models.Dtos;

public class UpdateZasobDTO
{
    public string? Nazwa { get; set; } = string.Empty;
    public string? Kategoria { get; set; } = string.Empty;
    public decimal? Ilosc { get; set; }
    public string? Jednostka { get; set; } = string.Empty;
    public Guid? MiejscePrzechowaniaId { get; set; }
    public decimal? MinimumIlosc { get; set; }
    public typZasobu? TypZasobu { get; set; }

}
