namespace VeterinariaSanMiguel.Models;

public class Veterinario
{
    public int VeterinarioId { get; set; }
    public string? Documento { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Especialidad { get; set; }
    public string? Telefono { get; set; }
    public List<Atencion> Atenciones { get; set; } = new();

    public override string ToString() => $"[{VeterinarioId}] {Nombre} - Esp: {Especialidad ?? "(gen)"} - Atenciones: {Atenciones.Count}";
}