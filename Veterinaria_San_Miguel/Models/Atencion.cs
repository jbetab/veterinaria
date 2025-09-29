namespace VeterinariaSanMiguel.Models;

public class Atencion
{
    public int AtencionId { get; set; }   
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string? Diagnostico { get; set; }
    
    public int MascotaId { get; set; }
    public Mascota? Mascota { get; set; }

    public int? VeterinarioId { get; set; } 
    public Veterinario? Veterinario { get; set; }

    public override string ToString()
        => $"[{AtencionId}] {Fecha:yyyy-MM-dd} - " +
           $"Mascota: {Mascota?.Nombre ?? "(id:" + MascotaId + ")"} - " +
           $"Vet: {Veterinario?.Nombre ?? (VeterinarioId.HasValue ? "(id:" + VeterinarioId + ")" : "(sin)")}) - " +
           $"Dx: {Diagnostico}";
}