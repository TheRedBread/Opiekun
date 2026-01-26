namespace Opiekun.Models.Dtos;

public class ZasobDTO
{
    public Guid Id { get; set; }
    public string Nazwa { get; set; } = string.Empty;
    public string Kategoria {  get; set; } = string.Empty;
    public decimal Ilosc { get; set; }
    public string Jednostka { get; set; } = string.Empty;
    public string MiejscePrzechowania { get; set; } = string.Empty;

    public bool CzyNiskiStan { get; set; }
    public decimal MinimumIlosc { get; set; }


}
