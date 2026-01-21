using Microsoft.IdentityModel.Tokens;
using Opiekun.Models;
using Opiekun.Models.Dtos;

namespace Opiekun.Mapping;

public static class ZasobyMapping
{
    public static ZasobDTO toDto(this Zasob zasob)
    {
        var Dto = new ZasobDTO
        {
            Id = zasob.Id,
            Nazwa = zasob.Nazwa,
            Kategoria = zasob.Kategoria,
            Ilosc = zasob.Ilosc,
            Jednostka = zasob.Jednostka,
            MiejscePrzechowania = zasob.MiejscePrzechowania
        };
        return Dto;
    }
    public static Zasob toEntity(this CreateZasobDTO CreateDTO)
    {
        var zasob = new Zasob
        {
            Nazwa = CreateDTO.Nazwa,
            Kategoria = CreateDTO.Kategoria,
            Ilosc = CreateDTO.Ilosc,
            Jednostka = CreateDTO.Jednostka,
            MiejscePrzechowania = CreateDTO.MiejscePrzechowania
        };
        return zasob;
    }

    public static void UpdateFromDto(this Zasob zasob, UpdateZasobDTO dto)
    {
        
        if (!dto.Nazwa.IsNullOrEmpty()) 
            zasob.Nazwa = dto.Nazwa!;

        if (!dto.Kategoria.IsNullOrEmpty()) 
            zasob.Kategoria = dto.Kategoria!;
        
        if (dto.Ilosc.HasValue)
            zasob.Ilosc = dto.Ilosc.Value;

        if (!dto.Jednostka.IsNullOrEmpty())
                zasob.Jednostka = dto.Jednostka!;

        if (!dto.MiejscePrzechowania.IsNullOrEmpty())
            zasob.MiejscePrzechowania = dto.MiejscePrzechowania!;
    }

}
