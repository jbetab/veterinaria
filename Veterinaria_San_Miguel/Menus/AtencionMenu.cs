
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus
{
    public static class AtencionMenu
    {
        public static void Mostrar()
        {
            var service = new AtencionService(new Data.VetContext());

            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Atenciones Médicas ===");
                Console.WriteLine("1. Registrar atención médica");
                Console.WriteLine("2. Listar atenciones médicas");
                Console.WriteLine("3. Editar atención médica");
                Console.WriteLine("4. Eliminar atención médica");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Fecha (yyyy-MM-dd) (Enter para usar fecha actual): ");
                        var fechaInput = Console.ReadLine();

                        Console.Write("Diagnóstico: ");
                        var diagnostico = Console.ReadLine() ?? "";

                        Console.Write("ID de la mascota: ");
                        if (!int.TryParse(Console.ReadLine(), out int mascotaId))
                        {
                            Console.WriteLine("ID de mascota inválido.");
                            Console.ReadLine();
                            break;
                        }

                        Console.Write("ID del veterinario: ");
                        if (!int.TryParse(Console.ReadLine(), out int veterinarioId))
                        {
                            Console.WriteLine("ID de veterinario inválido.");
                            Console.ReadLine();
                            break;
                        }

                        if (string.IsNullOrWhiteSpace(fechaInput))
                        {

                            service.RegistrarAtencion(mascotaId, veterinarioId, diagnostico);
                        }
                        else if (DateTime.TryParse(fechaInput, out DateTime fecha))
                        {
                            service.RegistrarAtencion(fecha, diagnostico, mascotaId, veterinarioId);
                        }
                        else
                        {
                            Console.WriteLine("Formato de fecha inválido.");
                        }

                        Console.WriteLine("\nPresione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "2":
                        service.ListarAtenciones();
                        Console.WriteLine("\nPresione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("ID de la atención a editar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEditar))
                        {
                            Console.Write("Nueva fecha (Enter para omitir): ");
                            var fechaStr = Console.ReadLine();
                            DateTime? nuevaFecha = null;
                            if (!string.IsNullOrWhiteSpace(fechaStr) && DateTime.TryParse(fechaStr, out var fechaNueva))
                            {
                                nuevaFecha = fechaNueva;
                            }

                            Console.Write("Nuevo diagnóstico (Enter para omitir): ");
                            var nuevoDx = Console.ReadLine();

                            service.EditarAtencion(idEditar, nuevaFecha, nuevoDx);

                            Console.WriteLine("\nPresione Enter para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                            Console.ReadLine();
                        }
                        break;

                    case "4":
                        Console.Write("ID de la atención a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEliminar))
                        {
                            service.EliminarAtencion(idEliminar);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Console.WriteLine("\nPresione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "0":
                        volver = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}