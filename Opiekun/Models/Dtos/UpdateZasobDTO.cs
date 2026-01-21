namespace Opiekun.Models.Dtos;

public class UpdateZasobDTO
{
    public string? Nazwa { get; set; } = String.Empty;
    public string? Kategoria { get; set; } = String.Empty;
    public decimal? Ilosc { get; set; }
    public string? Jednostka { get; set; } = String.Empty;
    public string? MiejscePrzechowania { get; set; } = String.Empty;

}
