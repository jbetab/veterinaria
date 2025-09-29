using VeterinariaSanMiguel.Data;

namespace VeterinariaSanMiguel.Service
{
    public class ConsultasAvanzadasService
    {
        private readonly VetContext _context;

        public ConsultasAvanzadasService(VetContext context)
        {
            _context = context;
        }

        public void MascotasDeCliente(string nombreCliente)
        {
            var mascotas = _context.Clientes
                .Where(c => c.Nombre == nombreCliente)
                .SelectMany(c => c.Mascotas)
                .ToList();

            Console.WriteLine($"Mascotas de {nombreCliente}:");
            foreach (var m in mascotas)
                Console.WriteLine($"- {m.Nombre} ({m.Especie})");
        }

        public void VeterinarioConMasAtenciones()
        {
            var vet = _context.Atenciones
                .GroupBy(a => a.Veterinario)
                .OrderByDescending(g => g.Count())
                .Select(g => new { Veterinario = g.Key.Nombre, TotalAtenciones = g.Count() })
                .FirstOrDefault();

            Console.WriteLine($"Veterinario con más atenciones: {vet.Veterinario} ({vet.TotalAtenciones} atenciones)");
        }

        public void EspecieMasAtendida()
        {
            var especie = _context.Atenciones
                .GroupBy(a => a.Mascota.Especie)
                .OrderByDescending(g => g.Count())
                .Select(g => new { Especie = g.Key, TotalAtenciones = g.Count() })
                .FirstOrDefault();

            Console.WriteLine($"Especie más atendida: {especie.Especie} ({especie.TotalAtenciones} atenciones)");
        }

        public void ClienteConMasMascotas()
        {
            var cliente = _context.Clientes
                .OrderByDescending(c => c.Mascotas.Count)
                .Select(c => new { Cliente = c.Nombre, TotalMascotas = c.Mascotas.Count })
                .FirstOrDefault();

            Console.WriteLine($"Cliente con más mascotas: {cliente.Cliente} ({cliente.TotalMascotas} mascotas)");
        }
    }
}
