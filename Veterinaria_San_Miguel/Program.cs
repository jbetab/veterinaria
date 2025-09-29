using VeterinariaSanMiguel.Data;
using VeterinariaSanMiguel.Seeders;
using VeterinariaSanMiguel.Menus;

class Program
{
    static void Main()
    {
        using var context = new VetContext();

        Console.WriteLine("Probando conexión con la base de datos...\n");
        
        DbSeeder.Seed(context);
        Console.WriteLine("Seeder ejecutado (si la BD estaba vacía).\n");
        
        MenuPrincipal.Mostrar();
    }
}