using Microsoft.EntityFrameworkCore;
using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Models;

namespace VeterinariaSanMiguel.Services
{
    public class ClienteService
    {
        private readonly VetContext _context;

        public ClienteService(VetContext context)
        {
            _context = context;
        }


        public void RegistrarCliente(string documento, string nombre, string email, string telefono)
        {
            var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Documento == documento);
            if (clienteExistente != null)
            {
                Console.WriteLine("Ya existe un cliente con ese documento.");
                return;
            }
            
            var cliente = new Cliente
            {
                Documento = documento,
                Nombre = nombre,
                Email = email,
                Telefono = telefono
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            Console.WriteLine("Cliente registrado con éxito.\n");
        }
        
        public void ListarClientes()
        {
            var clientes = _context.Clientes
                .Include(c => c.Mascotas)
                .ToList();

            if (!clientes.Any())
            {
                Console.WriteLine("No hay clientes registrados.\n");
                return;
            }

            Console.WriteLine("Lista de clientes:");
            foreach (var c in clientes)
            {
                Console.WriteLine($"[{c.ClienteId}] {c.Nombre} - Doc: {c.Documento} - Correo: {c.Email} - Tel: {c.Telefono} (Mascotas: {c.Mascotas.Count})");
            }
            Console.WriteLine();
        }
        
        public void EditarCliente(int id, string? nuevoNombre = null, string? nuevoEmail = null, string? nuevoTelefono = null)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.\n");
                return;
            }

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                cliente.Nombre = nuevoNombre;

            if (!string.IsNullOrWhiteSpace(nuevoEmail))
                cliente.Email = nuevoEmail;

            if (!string.IsNullOrWhiteSpace(nuevoTelefono))
                cliente.Telefono = nuevoTelefono;

            _context.SaveChanges();
            Console.WriteLine("Cliente editado correctamente.\n");
        }
        
        public void EliminarCliente(int id)
        {
            var cliente = _context.Clientes
                .Include(c => c.Mascotas)
                .FirstOrDefault(c => c.ClienteId == id);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.\n");
                return;
            }

            if (cliente.Mascotas.Any())
            {
                Console.WriteLine("No se puede eliminar un cliente con mascotas registradas.\n");
                return;
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            Console.WriteLine("Cliente eliminado con éxito.\n");
        }
    }
}
