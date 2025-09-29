using VeterinariaSanMiguel.Service;

namespace VeterinariaSanMiguel.Menus
{
    public static class ConsultasMenu
    {
        public static void Mostrar()
        {
            var service = new ConsultasAvanzadasService(new Data.VetContext());

            bool volver = false;
            while (!volver)
            {
                Console.WriteLine("=== Consultas Avanzadas ===");
                Console.WriteLine("1. Mascotas de un cliente");
                Console.WriteLine("2. Veterinario con más atenciones");
                Console.WriteLine("3. Especie más atendida");
                Console.WriteLine("4. Cliente con más mascotas");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del cliente: ");
                        var nombreCliente = Console.ReadLine();
                        service.MascotasDeCliente(nombreCliente!);
                        Console.ReadLine();
                        break;

                    case "2":
                        service.VeterinarioConMasAtenciones();
                        Console.ReadLine();
                        break;

                    case "3":
                        service.EspecieMasAtendida();
                        Console.ReadLine();
                        break;

                    case "4":
                        service.ClienteConMasMascotas();
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
