using Microsoft.EntityFrameworkCore;
using System;
using SistemaWebEmpleado.Models;

using System.Reflection.Emit;

namespace SistemaWebEmpleado.Data
{
    public class EmpleadoContext: DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasData(
               new Empleado
               {
                   EmpleadoId = 1,
                   Nombre = "Gaston",
                   Apellido = "Migone",
                   DNI = "37000000",
                   Legajo = "AA12345",
                   Titulo = "Ingeniero"
               },
               new Empleado
               {
                   EmpleadoId = 2,
                   Nombre = "Gabriela",
                   Apellido = "Giles",
                   DNI = "40000000",
                   Legajo = "AA55555",
                   Titulo = "Profesora"
               });

        }
    }
}
