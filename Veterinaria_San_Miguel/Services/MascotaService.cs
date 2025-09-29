using Microsoft.EntityFrameworkCore;
using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Services
{
    public class MascotaService
    {
        private readonly VetContext _context;

        public MascotaService(VetContext context)
        {
            _context = context;
        }

        public void RegistrarMascota(string nombre, string especie, int clienteId)
        {
            var cliente = _context.Clientes.Find(clienteId);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            var mascota = new Mascota { Nombre = nombre, Especie = especie, ClienteId = clienteId };
            _context.Mascotas.Add(mascota);
            _context.SaveChanges();
            Console.WriteLine($"Mascota {nombre} registrada para el cliente {cliente.Nombre}.");
        }

        public void ListarMascotas()
        {
            var mascotas = _context.Mascotas.Include(m => m.Cliente).ToList();
            Console.WriteLine(" Mascotas registradas:");
            foreach (var m in mascotas)
                Console.WriteLine($"[{m.MascotaId}] {m.Nombre} ({m.Especie}) - Dueño: {m.Cliente?.Nombre}");
        }

        public void EditarMascota(int id, string nuevoNombre, string nuevaEspecie)
        {
            var mascota = _context.Mascotas.Find(id);
            if (mascota == null)
            {
                Console.WriteLine("⚠ Mascota no encontrada.");
                return;
            }

            mascota.Nombre = nuevoNombre;
            mascota.Especie = nuevaEspecie;
            _context.SaveChanges();
            Console.WriteLine($"Mascota {id} actualizada.");
        }

        public void EliminarMascota(int id)
        {
            var mascota = _context.Mascotas.Find(id);
            if (mascota == null)
            {
                Console.WriteLine("Mascota no encontrada.");
                return;
            }

            _context.Mascotas.Remove(mascota);
            _context.SaveChanges();
            Console.WriteLine($"Mascota {id} eliminada.");
        }
    }
}
