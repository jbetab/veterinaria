using System;
using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Services;

namespace VeterinariaSanMiguel.Menus
{
    public static class MenuPrincipal
    {
        public static void Mostrar()
        {
            using var context = new VetContext();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("===  Veterinaria San Miguel  ===");
                Console.WriteLine("1. Gestión de Clientes");
                Console.WriteLine("2. Gestión de Mascotas");
                Console.WriteLine("3. Gestión de Veterinarios");
                Console.WriteLine("4. Gestión de Atenciones Médicas");
                Console.WriteLine("5. Historial Médico de Mascota");
                Console.WriteLine("6. Consultas Avanzadas");
                Console.WriteLine("0. Salir");
                Console.Write("\nSeleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ClienteMenu.Mostrar(context);
                        break;
                    case "2":
                        MascotaMenu.Mostrar(context);
                        break;
                    case "3":
                        VeterinarioMenu.Mostrar();
                        break;
                    case "4":
                        AtencionMenu.Mostrar();
                        break;
                    case "5":
                        Console.Write("Ingrese el ID de la mascota: ");
                        if (int.TryParse(Console.ReadLine(), out int idMascota))
                        {
                            var atencionService = new AtencionService(context);
                            atencionService.HistorialMedicoDeMascota(idMascota);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Console.WriteLine("\nPresione Enter para continuar...");
                        Console.ReadLine();
                        break;
                    case "6":
                        ConsultasMenu.Mostrar();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, presione Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
