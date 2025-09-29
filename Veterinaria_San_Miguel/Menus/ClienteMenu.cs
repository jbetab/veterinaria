using VeterinariaSanMiguel.Services;
using VeterinariaSanMiguel.Data;

namespace VeterinariaSanMiguel.Menus
{
    public static class ClienteMenu
    {
        public static void Mostrar(VetContext context)
        {
            var service = new ClienteService(context);

            bool volver = false;
            while (!volver)
            {
                Console.WriteLine("=== Gestión de Clientes ===");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Listar clientes");
                Console.WriteLine("3. Editar cliente");
                Console.WriteLine("4. Eliminar cliente");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Documento:");
                        var documento = Console.ReadLine() ?? "";
                        
                        Console.Write("Ingrese nombre: ");
                        var nombre = Console.ReadLine() ?? "";

                        Console.Write("Ingrese email: ");
                        var email = Console.ReadLine() ?? "";

                        Console.Write("Ingrese teléfono: ");
                        var telefono = Console.ReadLine() ?? "";

                        service.RegistrarCliente(documento, nombre, email, telefono);
                        Console.ReadLine();
                        break;

                    case "2":
                        service.ListarClientes();
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("Ingrese ID del cliente a editar: ");
                        int idEditar = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Nuevo nombre (Enter para mantener): ");
                        var nuevoNombre = Console.ReadLine();

                        Console.Write("Nuevo email (Enter para mantener): ");
                        var nuevoEmail = Console.ReadLine();

                        Console.Write("Nuevo teléfono (Enter para mantener): ");
                        var nuevoTelefono = Console.ReadLine();

                        service.EditarCliente(idEditar, nuevoNombre, nuevoEmail, nuevoTelefono);
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Write("Ingrese ID del cliente a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine() ?? "0");

                        service.EliminarCliente(idEliminar);
                        Console.ReadLine();
                        break;

                    case "0":
                        volver = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
