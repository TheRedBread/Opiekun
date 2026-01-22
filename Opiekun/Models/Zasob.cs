using System.ComponentModel.DataAnnotations;

namespace Opiekun.Models;


public class Zasob
{
    public Guid Id { get; set; }

    [Required, MaxLength(200)]
    public string Nazwa { get; set; } = String.Empty;

    [Required, MaxLength(100)]
    public string Kategoria {  get; set; } = String.Empty;

    [Required, Range(0, double.MaxValue)]
    public decimal Ilosc { get; set; }
    
    [Required, MaxLength(50)]
    public string Jednostka { get; set; } = String.Empty;

    [MaxLength(500)]
    public string MiejscePrzechowania { get; set; } = String.Empty;

    [Range(0, double.MaxValue)]
    public decimal MinimumIlosc { get; set; }


}
