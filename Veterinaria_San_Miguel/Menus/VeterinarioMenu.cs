using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus
{
    public static class VeterinarioMenu
    {
        public static void Mostrar()
        {
            var service = new VeterinarioService(new Data.VetContext());

            bool volver = false;
            while (!volver)
            {
                Console.WriteLine("=== Gestión de Veterinarios ===");
                Console.WriteLine("1. Registrar veterinario");
                Console.WriteLine("2. Listar veterinarios");
                Console.WriteLine("3. Editar veterinario");
                Console.WriteLine("4. Eliminar veterinario");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Documento: ");
                        var documento = Console.ReadLine() ?? "";
                        Console.Write("Nombre: ");
                        var nombre = Console.ReadLine() ?? "";
                        Console.Write("Especialidad: ");
                        var especialidad = Console.ReadLine() ?? "";
                        Console.Write("Teléfono: ");
                        var telefono = Console.ReadLine() ?? "";
                        service.RegistrarVeterinario(documento, nombre, especialidad, telefono);
                        Console.ReadLine();
                        break;

                    case "2":
                        service.ListarVeterinarios();
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("ID del veterinario a editar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEditar))
                        {
                            Console.Write("Nuevo Documento (Enter para omitir: ");
                            var nuevoDocumento = Console.ReadLine() ?? "";
                            Console.Write("Nuevo nombre (Enter para omitir): ");
                            var nuevoNombre = Console.ReadLine();
                            Console.Write("Nueva especialidad (Enter para omitir): ");
                            var nuevaEspecialidad = Console.ReadLine();
                            Console.Write("Nuevo teléfono (Enter para omitir): ");
                            var nuevoTelefono = Console.ReadLine();

                            service.EditarVeterinario(idEditar, nuevoDocumento, nuevoNombre, nuevaEspecialidad, nuevoTelefono);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Write("ID del veterinario a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEliminar))
                        {
                            service.EliminarVeterinario(idEliminar);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
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
