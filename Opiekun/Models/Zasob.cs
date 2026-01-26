using System.ComponentModel.DataAnnotations;

namespace Opiekun.Models;


public class Zasob
{
    public Guid Id { get; set; }

    [Required, MaxLength(200)]
    public string Nazwa { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Kategoria {  get; set; } = string.Empty;

    [Required, Range(0, double.MaxValue)]
    public decimal Ilosc { get; set; }
    
    [Required, MaxLength(50)]
    public string Jednostka { get; set; } = string.Empty;

    [MaxLength(500)]
    public string MiejscePrzechowania { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal MinimumIlosc { get; set; }


}
