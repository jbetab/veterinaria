using Microsoft.EntityFrameworkCore;
using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Data;

public class VetContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Veterinario> Veterinarios { get; set; }
    public DbSet<Atencion> Atenciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "server=localhost;port=3306;user=root;password=Junio07#;database=VeterinariaSanMiguel";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Mascotas)
            .WithOne(m => m.Cliente)
            .HasForeignKey(m => m.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Mascota>()
            .HasMany(m => m.Atenciones)
            .WithOne(a => a.Mascota)
            .HasForeignKey(a => a.MascotaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Veterinario>()
            .HasMany(v => v.Atenciones)
            .WithOne(a => a.Veterinario)
            .HasForeignKey(a => a.VeterinarioId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}