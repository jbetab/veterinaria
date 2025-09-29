using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus
{
    public static class MascotaMenu
    {
        public static void Mostrar(VetContext context)
        {
            var service = new MascotaService(context);

            bool volver = false;
            while (!volver)
            {
                Console.WriteLine("=== Gestión de Mascotas ===");
                Console.WriteLine("1. Registrar mascota");
                Console.WriteLine("2. Listar mascotas");
                Console.WriteLine("3. Editar mascota");
                Console.WriteLine("4. Eliminar mascota");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese nombre de la mascota: ");
                        var nombre = Console.ReadLine() ?? "";

                        Console.Write("Ingrese especie: ");
                        var especie = Console.ReadLine() ?? "";

                        Console.Write("Ingrese ID del cliente dueño: ");
                        int clienteId = int.Parse(Console.ReadLine() ?? "0");

                        service.RegistrarMascota(nombre, especie, clienteId);
                        Console.ReadLine();
                        break;

                    case "2":
                        service.ListarMascotas();
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("Ingrese ID de la mascota a editar: ");
                        int idEditar = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Nuevo nombre (Enter para mantener): ");
                        var nuevoNombre = Console.ReadLine();

                        Console.Write("Nueva especie (Enter para mantener): ");
                        var nuevaEspecie = Console.ReadLine();
                        
                        service.EditarMascota(idEditar, nuevoNombre, nuevaEspecie);
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Write("Ingrese ID de la mascota a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine() ?? "0");

                        service.EliminarMascota(idEliminar);
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
