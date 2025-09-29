namespace VeterinariaSanMiguel.Models;

public class Cliente
{
    public int ClienteId { get; set; }
    public string Documento { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Email { get; set; }


    public List<Mascota> Mascotas { get; set; } = new();

    public override string ToString()
        => $"[{ClienteId}] {Nombre} - Tel: {Telefono ?? "(sin)"} - Email: {Email ?? "(sin)"} - Mascotas: {Mascotas.Count}";
}