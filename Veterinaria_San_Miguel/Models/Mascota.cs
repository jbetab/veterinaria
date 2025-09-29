namespace VeterinariaSanMiguel.Models;

public class Mascota
{
    public int MascotaId { get; set; } 
    public string Nombre { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string? Raza { get; set; }
    public int Edad { get; set; }


    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }


    public List<Atencion> Atenciones { get; set; } = new();

    public override string ToString()
        => $"[{MascotaId}] {Nombre} ({Especie}{(Raza is null ? "" : $" - {Raza}")}) - Edad: {Edad} - Dueño: {Cliente?.Nombre ?? "(sin dueño)"}";
}