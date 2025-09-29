using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Services
{
    public class VeterinarioService
    {
        private readonly VetContext _context;

        public VeterinarioService(VetContext context)
        {
            _context = context;
        }

        public void RegistrarVeterinario(string documento, string nombre, string especialidad,  string telefono)
        {   
            var vetExistente = _context.Veterinarios.FirstOrDefault(v => v.Documento == documento);
            if (vetExistente != null)
            {
                Console.WriteLine("Ya existe un veterinario con ese documento.");
                return;
            }
            
            var vet = new Veterinario { Documento = documento, Nombre = nombre, Especialidad = especialidad, Telefono = telefono };
            _context.Veterinarios.Add(vet);
            _context.SaveChanges();
            Console.WriteLine($"Veterinario {nombre} registrado.");
        }

        public void ListarVeterinarios()
        {
            var vets = _context.Veterinarios.ToList();
            Console.WriteLine("Veterinarios registrados:");
            foreach (var v in vets)
                Console.WriteLine($"[{v.VeterinarioId}] {v.Nombre} - {v.Especialidad}");
        }

        public void EditarVeterinario(int id,string? nuevoDocumento = null, string? nuevoNombre = null, string? nuevaEspecialidad = null, string? nuevoTelefono = null)
        {
            var vet = _context.Veterinarios.Find(id);
            if (vet == null)
            {
                Console.WriteLine("Veterinario no encontrado.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                vet.Nombre = nuevoNombre;

            if (!string.IsNullOrWhiteSpace(nuevaEspecialidad))
                vet.Especialidad = nuevaEspecialidad;

            if (!string.IsNullOrWhiteSpace(nuevoTelefono))
                vet.Telefono = nuevoTelefono;

            _context.SaveChanges();
            Console.WriteLine($"Veterinario {id} actualizado.");
        }


        public void EliminarVeterinario(int id)
        {
            var vet = _context.Veterinarios.Find(id);
            if (vet == null)
            {
                Console.WriteLine("Veterinario no encontrado.");
                return;
            }

            _context.Veterinarios.Remove(vet);
            _context.SaveChanges();
            Console.WriteLine($"Veterinario {id} eliminado.");
        }
    }
}