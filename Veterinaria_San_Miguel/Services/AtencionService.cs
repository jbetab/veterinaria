using Microsoft.EntityFrameworkCore;
using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Services
{
    public class AtencionService
    {
        private readonly VetContext _context;

        public AtencionService(VetContext context)
        {
            _context = context;
        }


        public void RegistrarAtencion(DateTime fecha, string diagnostico, int mascotaId, int vetId)
        {
            var mascota = _context.Mascotas.Find(mascotaId);
            var vet = _context.Veterinarios.Find(vetId);

            if (mascota == null || vet == null)
            {
                Console.WriteLine("Mascota o veterinario no encontrado.");
                return;
            }

            var atencion = new Atencion
            {
                Fecha = fecha,
                Diagnostico = diagnostico,
                MascotaId = mascotaId,
                VeterinarioId = vetId
            };

            _context.Atenciones.Add(atencion);
            _context.SaveChanges();
            Console.WriteLine($"Atención registrada para {mascota.Nombre} con {vet.Nombre}.");
        }

        public void RegistrarAtencion(int mascotaId, int vetId, string diagnostico)
        {
            RegistrarAtencion(DateTime.Now, diagnostico, mascotaId, vetId);
        }

        public void ListarAtenciones()
        {
            var atenciones = _context.Atenciones
                .Include(a => a.Mascota)
                .Include(a => a.Veterinario)
                .ToList();

            Console.WriteLine("Atenciones médicas:");
            foreach (var a in atenciones)
                Console.WriteLine($"[{a.AtencionId}] {a.Fecha:yyyy-MM-dd} - {a.Mascota?.Nombre} ({a.Veterinario?.Nombre}) - Dx: {a.Diagnostico}");
        }

        public void EditarAtencion(int id, DateTime? nuevaFecha = null, string? nuevoDiagnostico = null)
        {
            var atencion = _context.Atenciones.Find(id);

            if (atencion == null)
            {
                Console.WriteLine("Atención no encontrada.\n");
                return;
            }

            if (nuevaFecha.HasValue)
                atencion.Fecha = nuevaFecha.Value;

            if (!string.IsNullOrWhiteSpace(nuevoDiagnostico))
                atencion.Diagnostico = nuevoDiagnostico;

            _context.SaveChanges();
            Console.WriteLine("Atención editada correctamente.\n");
        }

        public void EliminarAtencion(int id)
        {
            var atencion = _context.Atenciones.Find(id);
            if (atencion == null)
            {
                Console.WriteLine("Atención no encontrada.");
                return;
            }

            _context.Atenciones.Remove(atencion);
            _context.SaveChanges();
            Console.WriteLine($"Atención {id} eliminada.");
        }

        public void HistorialMedicoDeMascota(int mascotaId)
        {
            var historial = _context.Atenciones
                .Include(a => a.Veterinario)
                .Where(a => a.MascotaId == mascotaId)
                .ToList();

            if (!historial.Any())
            {
                Console.WriteLine("No hay atenciones registradas para esta mascota.");
                return;
            }

            Console.WriteLine($"Historial médico de mascota {mascotaId}:");
            foreach (var a in historial)
                Console.WriteLine($"{a.Fecha:yyyy-MM-dd} - {a.Diagnostico} (Vet: {a.Veterinario?.Nombre})");
        }
    }
}