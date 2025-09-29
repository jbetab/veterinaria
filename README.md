#  Veterinaria San Miguel

Sistema de gestión de clientes, mascotas, veterinarios y atenciones médicas para una veterinaria, desarrollado en C# consola con Entity Framework Core y MySQL.

---

## 1 Descripción del proyecto
Sistema permite:

Gestión de clientes, mascotas y veterinarios (CRUD completo)

Registrar atenciones médicas y consultar historial de mascotas

Consultas avanzadas con LINQ y EF Core:

Mascotas de un cliente

Veterinario con más atenciones

Especie más atendida

Cliente con más mascotas


---

## 2 Requisitos
.NET 8 (o superior)

MySQL

Entity Framework Core

IDE recomendado: Visual Studio, Rider o VSCode

---

## 3 Configuración de la base de datos
Crear la base de datos en MySQL:
CREATE DATABASE VeterinariaSanMiguel;

Configurar cadena de conexión en VetContext.cs:
optionsBuilder.UseMySql(
"server=localhost;database=VeterinariaSanMiguel;user=root;password=tu_contraseña;",
new MySqlServerVersion(new Version(8, 0, 32))
);

Reemplaza 'tu_contraseña' por la de tu MySQL


---

## 4 Migraciones y actualización de la BD
Crear migración inicial:
dotnet ef migrations add InitialCreate

Aplicar migración:
dotnet ef database update

Para cambios futuros en los modelos:
dotnet ef migrations add NombreDeLaMigracion
dotnet ef database update


---

## 5 Seeder de datos (opcional)
Ejecuta el seeder si la BD está vacía:
using var context = new VetContext();
DbSeeder.Seed(context);

---

## 6 Instrucciones para ejecutar
Clonar el repositorio

Abrir solución en el IDE

Configurar cadena de conexión en VetContext.cs

Ejecutar el programa:
dotnet run

O desde el IDE

Navegar por el menú principal:

Gestión de Clientes

Gestión de Mascotas

Gestión de Veterinarios

Gestión de Atenciones Médicas

Historial médico de una mascota

Consultas avanzadas

Salir

---

## 7 Notas importantes
Los IDs son auto-incrementales y pueden tener huecos si se eliminan registros

Integridad de relaciones asegurada (clientes, mascotas, atenciones)

Validación mínima incluida (no se permiten atenciones sin cliente o veterinario)

Para historial médico de mascota se solicita su ID desde el menú principal
