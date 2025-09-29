using VeterinariaSanMiguel.Models;
using VeterinariaSanMiguel.Data;

namespace VeterinariaSanMiguel.Seeders;

public static class DbSeeder
{
    public static void Seed(VetContext context)
    {
        if (context.Clientes.Any()) return; 
        
        var clientes = new List<Cliente>
        {
            new Cliente { Nombre = "JuannPérez", Email = "juan@mail.com", Telefono = "111111", Documento = "CC1001" },
            new Cliente { Nombre = "María Gómez", Email = "maria@mail.com", Telefono = "222222", Documento = "CC1002" },
            new Cliente { Nombre = "Carlos Ruiz", Email = "carlos@mail.com", Telefono = "333333", Documento = "CC1003" },
            new Cliente { Nombre = "AnabTorres", Email = "ana@mail.com", Telefono = "444444", Documento = "CC1004" },
            new Cliente { Nombre = "Pedro Sánchez", Email = "pedro@mail.com", Telefono = "555555", Documento = "CC1005" },
            new Cliente { Nombre = "Laura Martínez", Email = "laura@mail.com", Telefono = "666666", Documento = "CC1006" },
            new Cliente { Nombre = "Sofía Ramírez", Email = "sofia@mail.com", Telefono = "777777", Documento = "CC1007" },
            new Cliente { Nombre = "Diego López", Email = "diego@mail.com", Telefono = "888888", Documento = "CC1008" },
            new Cliente { Nombre = "Elena Herrera", Email = "elena@mail.com", Telefono = "999999", Documento = "CC1009" },
            new Cliente { Nombre = "Gabriel Castro", Email = "gabriel@mail.com", Telefono = "101010", Documento = "CC1010" },
            new Cliente { Nombre = "Patricia Vargas", Email = "patricia@mail.com", Telefono = "121212", Documento = "CC1011" },
            new Cliente { Nombre = "Andrés Ríos", Email = "andres@mail.com", Telefono = "131313", Documento = "CC1012" },
            new Cliente { Nombre = "Valentina Suárez", Email = "valentina@mail.com", Telefono = "141414", Documento = "CC1013" },
            new Cliente { Nombre = "Ricardo Torres", Email = "ricardo@mail.com", Telefono = "151515", Documento = "CC1014" },
            new Cliente { Nombre = "Daniela Ortega", Email = "daniela@mail.com", Telefono = "161616", Documento = "CC1015" }
        };


        var veterinarios = new List<Veterinario>
        {
            new Veterinario { Nombre = "Carlos López", Telefono = "3001111111", Documento = "CC2001", Especialidad = "Perros" },
            new Veterinario { Nombre = "Mariana Martínez",  Telefono = "3002222222", Documento = "CC2002", Especialidad = "Gatos" },
            new Veterinario { Nombre = "Javier Fernández",  Telefono = "3003333333", Documento = "CC2003", Especialidad = "Aves" },
            new Veterinario { Nombre = "Lucía Ramírez", Telefono = "3004444444", Documento = "CC4200", Especialidad = "Exóticos" }, // Documento opcional
            new Veterinario { Nombre = "Andrés Sánchez", Telefono = "3005555555", Documento = "CC2005", Especialidad = "General" }
        };


        var mascotas = new List<Mascota>
        {
            new Mascota { Nombre = "Firulais", Especie = "Perro", Cliente = clientes[0] },
            new Mascota { Nombre = "Michi", Especie = "Gato", Cliente = clientes[0] },
            new Mascota { Nombre = "Rocky", Especie = "Perro", Cliente = clientes[1] },
            new Mascota { Nombre = "Luna", Especie = "Gato", Cliente = clientes[2] },
            new Mascota { Nombre = "Paco", Especie = "Loro", Cliente = clientes[2] },
            new Mascota { Nombre = "Nala", Especie = "Gato", Cliente = clientes[3] },
            new Mascota { Nombre = "Max", Especie = "Perro", Cliente = clientes[4] },
            new Mascota { Nombre = "Toby", Especie = "Perro", Cliente = clientes[5] },
            new Mascota { Nombre = "Kiwi", Especie = "Loro", Cliente = clientes[6] },
            new Mascota { Nombre = "Bella", Especie = "Gato", Cliente = clientes[7] },
            new Mascota { Nombre = "Simba", Especie = "Perro", Cliente = clientes[8] },
            new Mascota { Nombre = "Coco", Especie = "Conejo", Cliente = clientes[9] },
            new Mascota { Nombre = "Rex", Especie = "Perro", Cliente = clientes[10] },
            new Mascota { Nombre = "Chispas", Especie = "Gato", Cliente = clientes[11] },
            new Mascota { Nombre = "Daisy", Especie = "Perro", Cliente = clientes[12] },
            new Mascota { Nombre = "Thor", Especie = "Perro", Cliente = clientes[13] },
            new Mascota { Nombre = "Pelusa", Especie = "Gato", Cliente = clientes[14] }
        };
        
        var atenciones = new List<Atencion>
        {
            new Atencion { Mascota = mascotas[0], Veterinario = veterinarios[0], Diagnostico = "Vacunación" },
            new Atencion { Mascota = mascotas[0], Veterinario = veterinarios[0], Diagnostico = "Chequeo anual" },
            new Atencion { Mascota = mascotas[0], Veterinario = veterinarios[4], Diagnostico = "Problema dental" },

            new Atencion { Mascota = mascotas[1], Veterinario = veterinarios[1], Diagnostico = "Desparasitación" },
            new Atencion { Mascota = mascotas[1], Veterinario = veterinarios[1], Diagnostico = "Revisión general" },

            new Atencion { Mascota = mascotas[2], Veterinario = veterinarios[0], Diagnostico = "Control general" },
            new Atencion { Mascota = mascotas[2], Veterinario = veterinarios[0], Diagnostico = "Vacunación" },

            new Atencion { Mascota = mascotas[3], Veterinario = veterinarios[1], Diagnostico = "Chequeo" },
            new Atencion { Mascota = mascotas[3], Veterinario = veterinarios[4], Diagnostico = "Dolor estomacal" },
            new Atencion { Mascota = mascotas[3], Veterinario = veterinarios[1], Diagnostico = "Vacunación" },

            new Atencion { Mascota = mascotas[4], Veterinario = veterinarios[2], Diagnostico = "Ala dañada" },
            new Atencion { Mascota = mascotas[4], Veterinario = veterinarios[2], Diagnostico = "Chequeo de recuperación" },

            new Atencion { Mascota = mascotas[5], Veterinario = veterinarios[1], Diagnostico = "Chequeo" },
            new Atencion { Mascota = mascotas[6], Veterinario = veterinarios[0], Diagnostico = "Vacuna antirrábica" },
            new Atencion { Mascota = mascotas[7], Veterinario = veterinarios[4], Diagnostico = "Revisión dental" },
            new Atencion { Mascota = mascotas[8], Veterinario = veterinarios[2], Diagnostico = "Problemas en el ala" },
            new Atencion { Mascota = mascotas[9], Veterinario = veterinarios[1], Diagnostico = "Revisión general" },
            new Atencion { Mascota = mascotas[10], Veterinario = veterinarios[0], Diagnostico = "Fractura" },
            new Atencion { Mascota = mascotas[11], Veterinario = veterinarios[3], Diagnostico = "Chequeo exótico" },
            new Atencion { Mascota = mascotas[12], Veterinario = veterinarios[0], Diagnostico = "Vacunación" },
            new Atencion { Mascota = mascotas[13], Veterinario = veterinarios[1], Diagnostico = "Chequeo" },
            new Atencion { Mascota = mascotas[14], Veterinario = veterinarios[4], Diagnostico = "Infección leve" }
        };

        context.Clientes.AddRange(clientes);
        context.Veterinarios.AddRange(veterinarios);
        context.Mascotas.AddRange(mascotas);
        context.Atenciones.AddRange(atenciones);

        context.SaveChanges();
    }
}
